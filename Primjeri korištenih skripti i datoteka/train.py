from ultralytics import YOLO
from pathlib import Path

ROOT = Path(r"C:\Bojan Kojčinović\SEDMI TRENING").resolve() #Primjer putanje do direktorija gdje se nalaze potrebne datoteke
DATA = ROOT / "data.yml" #Putanja do yml datoteke gdje je opisana struktura skupa podataka i definirane klase 


def main():
    assert ROOT.exists(), f"ROOT not found: {ROOT}"
    assert DATA.exists(), f"Dataset YAML not found: {DATA}"

    model = YOLO("yolo26x.pt") # Odabir pretrained modela iz ultralytics biblioteke

    results = model.train( #Odabir hiperparametara treninga
        data=str(DATA),
        epochs=120,
        imgsz=1280,
        batch=4,
        device=0,
        workers=8,
        patience=25,
        close_mosaic=10,
        cos_lr=True,
        mixup=0.1,
        copy_paste=0.1,
        project=str(ROOT / "runs"),
        name="y26x_1280_coslr_augv1",
        pretrained=True,
        seed=0,
    )

    save_dir = Path(results.save_dir)
    metrics_file = save_dir / "final_metrics.txt"

    precision = None
    recall = None
    map50 = None
    map95 = None

    try:
        if hasattr(results, "box") and results.box is not None:
            precision = results.box.mp
            recall = results.box.mr
            map50 = results.box.map50
            map95 = results.box.map
    except Exception as e:
        error_msg = str(e)
    else:
        error_msg = None

    with open(metrics_file, "w", encoding="utf-8") as f:
        f.write(f"model: yolo26x.pt\n")
        f.write(f"data: {DATA}\n")
        f.write(f"save_dir: {save_dir}\n\n")
        f.write("Final validation metrics\n")
        f.write("========================\n")
        if precision is not None:
            f.write(f"precision: {precision:.6f}\n")
            f.write(f"recall: {recall:.6f}\n")
            f.write(f"mAP50: {map50:.6f}\n")
            f.write(f"mAP50-95: {map95:.6f}\n")
        else:
            f.write("Metrics could not be extracted from results object.\n")
            if error_msg:
                f.write(f"error: {error_msg}\n")

    print(f"[OK] Final metrics saved to: {metrics_file}")


if __name__ == "__main__":
    main()