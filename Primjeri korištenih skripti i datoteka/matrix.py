from pathlib import Path
from ultralytics import YOLO


ROOT = Path(r"C:\Bojan Kojčinović\SEDMI TRENING").resolve()
RUN_NAME = "y26x_1280_coslr"

WEIGHTS = ROOT / "runs" / RUN_NAME / "weights" / "best.pt"
DATA_YAML = ROOT / "data.yml"

OUT_PROJECT = ROOT / "test_eval_outputs"
OUT_NAME = "confusion_matrix_test_y26x_1280_coslr"

IMGSZ = 1280
CONF = 0.001
IOU = 0.7
DEVICE = 0


def main():
    assert WEIGHTS.exists(), f"Missing weights: {WEIGHTS}"
    assert DATA_YAML.exists(), f"Missing data.yml: {DATA_YAML}"

    print("[INFO] Using weights:", WEIGHTS)
    print("[INFO] Using data yaml:", DATA_YAML)

    model = YOLO(str(WEIGHTS))

    metrics = model.val(
        data=str(DATA_YAML),
        split="test",              # VAŽNO: koristi test split
        imgsz=IMGSZ,
        conf=CONF,
        iou=IOU,
        device=DEVICE,
        plots=True,                # spremi confusion matrix i ostale grafove
        project=str(OUT_PROJECT),
        name=OUT_NAME,
        exist_ok=True
    )

    print("[INFO] Test evaluation finished.")
    print("[INFO] Output folder:", OUT_PROJECT / OUT_NAME)

    try:
        print("[INFO] mAP50-95:", metrics.box.map)
        print("[INFO] mAP50:", metrics.box.map50)
    except Exception:
        pass


if __name__ == "__main__":
    main()