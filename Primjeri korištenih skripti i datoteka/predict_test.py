from pathlib import Path
from ultralytics import YOLO

ROOT = Path(r"C:\Bojan Kojčinović\SEDMI TRENING").resolve()
RUN_NAME = "y26x_1280_coslr"

WEIGHTS = ROOT / "runs" / RUN_NAME / "weights" / "best.pt"
TEST_IMAGES = ROOT / "test" / "images"

OUT_PROJECT = ROOT / "pred_outputs"
OUT_NAME = "test_visualization_y26x_1280_coslr"

CONF = 0.25
IOU = 0.7
DEVICE = 0


def main():
    assert WEIGHTS.exists(), f"Missing weights: {WEIGHTS}"
    assert TEST_IMAGES.exists(), f"Missing test images: {TEST_IMAGES}"

    print("[INFO] Using weights:", WEIGHTS)
    print("[INFO] Test images folder:", TEST_IMAGES)

    model = YOLO(str(WEIGHTS))

    results = model.predict(
        source=str(TEST_IMAGES),   # cijeli test/images folder
        conf=CONF,
        iou=IOU,
        save=True,                 # spremi slike s bboxovima
        save_txt=False,            # promijeni na True ako želiš i txt predikcije
        project=str(OUT_PROJECT),  # root output folder
        name=OUT_NAME,             
        device=DEVICE
    )

    try:
        print("[INFO] Saved to:", results[0].save_dir)
    except Exception:
        print("[INFO] Prediction finished.")


if __name__ == "__main__":
    main()