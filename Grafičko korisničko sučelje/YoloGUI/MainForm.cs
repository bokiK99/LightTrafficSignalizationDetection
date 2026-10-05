using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace YoloGUI
{
    public partial class MainForm : Form
    {
        // ─── Konstante ────────────────────────────────────────────────────────
        private static readonly string PythonExe  = @"C:\Users\bokib\miniconda3\envs\annotation\python.exe";
        private static readonly string ScriptPath = @"D:\yolo_gui_project\YoloGUI\Files\yolo_infer.py";
        private static readonly string FilesDir   = @"D:\yolo_gui_project\YoloGUI\Files";
        private static readonly string OutputDir  = @"D:\yolo_gui_project\YoloGUI\Output";

        // ─── State ────────────────────────────────────────────────────────────
        private string _inputPath    = string.Empty;
        private string _outputPath   = string.Empty;
        private string _modelPath    = string.Empty;
        private bool   _isProcessing = false;
        private string _currentMode  = "image";

        public MainForm()
        {
            InitializeComponent();
            SetupUI();
        }

        // =====================================================================
        //  INICIJALIZACIJA
        // =====================================================================
        private void SetupUI()
        {
            Directory.CreateDirectory(OutputDir);
            RefreshModelList();
            nudConf.Value = 0.25m;
            nudIou.Value  = 0.45m;
            UpdateStatusLabel("Spreman.", Color.Green);
            btnRun.Enabled = false;
        }

        // Puni ComboBox s .pt fajlovima iz FilesDir
        private void RefreshModelList()
        {
            cmbModel.Items.Clear();
            if (!Directory.Exists(FilesDir)) return;

            var models = Directory.GetFiles(FilesDir, "*.pt")
                                  .Select(Path.GetFileName)
                                  .ToArray();
            cmbModel.Items.AddRange(models);

            if (cmbModel.Items.Count > 0)
                cmbModel.SelectedIndex = 0;
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModel.SelectedItem == null) return;
            string modelName = cmbModel.SelectedItem.ToString();
            _modelPath = Path.Combine(FilesDir, modelName);

            // Ažuriraj output putanju ako je već odabran ulaz
            UpdateOutputPath();
            UpdateOutputDirLabel();
        }

        // =====================================================================
        //  ODABIR ULAZNOG FAJLA
        // =====================================================================
        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            if (rbImage.Checked) BrowseInputImage();
            else                 BrowseInputVideo();
        }

        private void BrowseInputImage()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title  = "Odaberi sliku";
                dlg.Filter = "Slike (*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.tif;*.webp|Svi fajlovi (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _inputPath = dlg.FileName;
                    txtInputPath.Text = _inputPath;
                    _currentMode = "image";
                    AutoSetOutputName();
                    PreviewInputImage();
                    btnRun.Enabled = cmbModel.SelectedItem != null;
                }
            }
        }

        private void BrowseInputVideo()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title  = "Odaberi video";
                dlg.Filter = "Video fajlovi (*.mp4;*.avi;*.mov;*.mkv)|*.mp4;*.avi;*.mov;*.mkv|Svi fajlovi (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _inputPath = dlg.FileName;
                    txtInputPath.Text = _inputPath;
                    _currentMode = "video";
                    AutoSetOutputName();
                    pictureBoxPreview.Image = null;
                    lblPreview.Text = "Video odabran: " + Path.GetFileName(_inputPath);
                    btnRun.Enabled = cmbModel.SelectedItem != null;
                }
            }
        }

        // =====================================================================
        //  IZLAZNI FAJL — output/ImeModela/ImeUlaza_detected.ext
        // =====================================================================
        private void AutoSetOutputName()
        {
            if (string.IsNullOrEmpty(_inputPath)) return;
            string ext  = _currentMode == "image" ? ".jpg" : ".mp4";
            string name = Path.GetFileNameWithoutExtension(_inputPath) + "_detected" + ext;
            txtOutputName.Text = name;
            UpdateOutputPath();
        }

        private void UpdateOutputPath()
        {
            string modelSubfolder = GetModelSubfolder();
            string name = txtOutputName.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;
            string dir = Path.Combine(OutputDir, modelSubfolder);
            _outputPath = Path.Combine(dir, name);
            UpdateOutputDirLabel();
        }

        private void UpdateOutputDirLabel()
        {
            string modelSubfolder = GetModelSubfolder();
            string dir = Path.Combine(OutputDir, modelSubfolder);
            lblOutputDirValue.Text = dir;
        }

        // Vraća ime modela bez ekstenzije (npr. "best" za "best.pt")
        // Ako model nije odabran, vraća prazan string
        private string GetModelSubfolder()
        {
            if (cmbModel.SelectedItem == null) return string.Empty;
            return Path.GetFileNameWithoutExtension(cmbModel.SelectedItem.ToString());
        }

        private void txtOutputName_TextChanged(object sender, EventArgs e)
        {
            string name = txtOutputName.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;
            string ext = _currentMode == "image" ? ".jpg" : ".mp4";
            if (!name.EndsWith(".jpg",  StringComparison.OrdinalIgnoreCase) &&
                !name.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                !name.EndsWith(".png",  StringComparison.OrdinalIgnoreCase) &&
                !name.EndsWith(".mp4",  StringComparison.OrdinalIgnoreCase))
            {
                name = Path.GetFileNameWithoutExtension(name) + ext;
            }
            UpdateOutputPath();
        }

        // =====================================================================
        //  POMOĆNE METODE
        // =====================================================================
        private void PreviewInputImage()
        {
            try
            {
                using (var tmp = new Bitmap(_inputPath))
                    pictureBoxPreview.Image = new Bitmap(tmp);
                lblPreview.Text = Path.GetFileName(_inputPath);
            }
            catch { lblPreview.Text = "Preview nije dostupan."; }
        }

        private void UpdateStatusLabel(string text, Color color)
        {
            if (InvokeRequired) { Invoke(new Action(() => UpdateStatusLabel(text, color))); return; }
            lblStatus.Text      = text;
            lblStatus.ForeColor = color;
        }

        private void AppendLog(string text)
        {
            if (InvokeRequired) { Invoke(new Action(() => AppendLog(text))); return; }
            txtLog.AppendText(text + Environment.NewLine);
            txtLog.ScrollToCaret();
        }

        // =====================================================================
        //  POKRETANJE INFERENCE
        // =====================================================================
        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;

            if (cmbModel.SelectedItem == null)
            { MessageBox.Show("Odaberi model!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (!File.Exists(_modelPath))
            { MessageBox.Show("Odabrani model nije pronađen!\n" + _modelPath, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (!File.Exists(ScriptPath))
            { MessageBox.Show("Python skripta nije pronađena!\n" + ScriptPath, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (!File.Exists(_inputPath))
            { MessageBox.Show("Ulazni fajl nije odabran!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (string.IsNullOrWhiteSpace(txtOutputName.Text.Trim()))
            { MessageBox.Show("Upiši ime izlaznog fajla!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // Kreiraj output subfolder za ovaj model
            string outputSubdir = Path.GetDirectoryName(_outputPath);
            Directory.CreateDirectory(outputSubdir);

            _isProcessing     = true;
            btnRun.Enabled    = false;
            progressBar.Style = ProgressBarStyle.Marquee;
            txtLog.Clear();

            double conf = (double)nudConf.Value;
            double iou  = (double)nudIou.Value;

            UpdateStatusLabel("Procesiranje...", Color.DarkOrange);
            AppendLog($"[{DateTime.Now:HH:mm:ss}] Pokretanje inference...");
            AppendLog($"  Model  : {_modelPath}");
            AppendLog($"  Ulaz   : {_inputPath}");
            AppendLog($"  Izlaz  : {_outputPath}");
            AppendLog($"  Mode   : {_currentMode}");
            AppendLog($"  Conf   : {conf}  |  IoU: {iou}");
            AppendLog("─────────────────────────────────────");

            string jsonResult = await Task.Run(() => RunPythonScript(conf, iou));

            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 0;
            _isProcessing     = false;
            btnRun.Enabled    = true;

            ProcessResult(jsonResult);
        }

        private string RunPythonScript(double conf, double iou)
        {
            string args = string.Format(
                "\"{0}\" --mode {1} --input \"{2}\" --output \"{3}\" --model \"{4}\" --conf {5} --iou {6}",
                ScriptPath, _currentMode, _inputPath, _outputPath, _modelPath,
                conf.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture),
                iou.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture));

            var psi = new ProcessStartInfo
            {
                FileName               = PythonExe,
                Arguments              = args,
                UseShellExecute        = false,
                RedirectStandardOutput = true,
                RedirectStandardError  = true,
                CreateNoWindow         = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding  = Encoding.UTF8
            };

            var sb_out = new StringBuilder();
            var sb_err = new StringBuilder();

            using (var p = new Process { StartInfo = psi })
            {
                p.OutputDataReceived += (s, ev) => { if (ev.Data != null) sb_out.AppendLine(ev.Data); };
                p.ErrorDataReceived  += (s, ev) =>
                {
                    if (ev.Data == null) return;
                    if (ev.Data.StartsWith("PROGRESS:"))
                    {
                        if (int.TryParse(ev.Data.Substring(9), out int pct))
                        {
                            int v = Math.Min(pct, 100);
                            if (InvokeRequired) Invoke(new Action(() => progressBar.Value = v));
                            else progressBar.Value = v;
                            AppendLog($"  Napredak: {pct}%");
                        }
                    }
                    else sb_err.AppendLine(ev.Data);
                };
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();
            }

            string stderr = sb_err.ToString().Trim();
            if (!string.IsNullOrEmpty(stderr)) AppendLog("[Python stderr]\n" + stderr);
            return sb_out.ToString().Trim();
        }

        private void ProcessResult(string jsonResult)
        {
            AppendLog("─────────────────────────────────────");

            if (string.IsNullOrEmpty(jsonResult))
            {
                UpdateStatusLabel("Greška: Python nije vratio izlaz.", Color.Red);
                AppendLog("[ERROR] Prazan odgovor Python skripte.");
                return;
            }

            try
            {
                var result = JObject.Parse(jsonResult);

                if ((string)result["status"] == "error")
                {
                    UpdateStatusLabel("Greška pri inference!", Color.Red);
                    AppendLog("[ERROR] " + (string)result["message"]);
                    var tb = result["traceback"];
                    if (tb != null && tb.Type != JTokenType.Null) AppendLog("[Traceback]\n" + (string)tb);
                    return;
                }

                int total = (int)result["total_detections"];
                UpdateStatusLabel($"Gotovo! Ukupno detekcija: {total}", Color.Green);
                AppendLog("[OK] Detekcija završena.");
                AppendLog($"  Ukupno objekata: {total}");

                if (_currentMode == "image" && result["detections"] != null)
                {
                    AppendLog("  Detalji:");
                    foreach (var det in result["detections"])
                        AppendLog(string.Format("    [{0}] {1}  conf={2}  bbox=({3},{4})-({5},{6})",
                            (int)det["class_id"], (string)det["class_name"],
                            ((double)det["confidence"]).ToString("0.###"),
                            (int)det["bbox"]["x1"], (int)det["bbox"]["y1"],
                            (int)det["bbox"]["x2"], (int)det["bbox"]["y2"]));
                }
                else if (_currentMode == "video")
                {
                    AppendLog($"  Obrađeno okvira : {(int)result["frames_processed"]}");
                    AppendLog($"  FPS             : {(double)result["fps"]}");
                    AppendLog($"  Rezolucija      : {(string)result["resolution"]}");
                }

                AppendLog($"  Izlaz spremljen : {_outputPath}");

                if (_currentMode == "image" && File.Exists(_outputPath))
                    ShowOutputImage();

                var dlgRes = MessageBox.Show(
                    $"Inference završen!\n\nPronađeno {total} objekt(a).\n\nOtvori izlazni fajl?",
                    "Gotovo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlgRes == DialogResult.Yes)
                    Process.Start(new ProcessStartInfo(_outputPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                UpdateStatusLabel("Greška pri parsiranju rezultata.", Color.Red);
                AppendLog("[ERROR] " + ex.Message);
                AppendLog("[Raw]\n" + jsonResult);
            }
        }

        private void ShowOutputImage()
        {
            try
            {
                tabControl.SelectedTab = tabPreview;
                using (var tmp = new Bitmap(_outputPath))
                    pictureBoxResult.Image = new Bitmap(tmp);
                lblResultPreview.Text = "Rezultat: " + Path.GetFileName(_outputPath);
            }
            catch { }
        }

        private void rbImage_CheckedChanged(object sender, EventArgs e) { if (rbImage.Checked) _currentMode = "image"; }
        private void rbVideo_CheckedChanged(object sender, EventArgs e) { if (rbVideo.Checked) _currentMode = "video"; }
        private void btnClearLog_Click(object sender, EventArgs e)      { txtLog.Clear(); }
        private void txtInputPath_TextChanged(object sender, EventArgs e) { }
    }
}
