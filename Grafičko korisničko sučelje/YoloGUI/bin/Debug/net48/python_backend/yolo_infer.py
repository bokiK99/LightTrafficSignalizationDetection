"""
yolo_infer.py
-------------
Python backend za YOLO detekciju prometne signalizacije.
Poziva se iz C# WinForms aplikacije putem Process.Start().

Korištenje:
    python yolo_infer.py --mode image --input "putanja/slika.jpg" --output "putanja/rezultat.jpg" --model "putanja/best.pt" [--conf 0.25] [--iou 0.45]
    python yolo_infer.py --mode video --input "putanja/video.mp4" --output "putanja/rezultat.mp4" --model "putanja/best.pt" [--conf 0.25] [--iou 0.45]

Izlaz (stdout):
    JSON s rezultatima detekcije ili porukom o grešci.
"""

import argparse
import json
import sys
import os
import traceback

def run_image_inference(model, input_path, output_path, conf, iou):
    """Pokreće inference na jednoj slici i sprema rezultat."""
    results = model.predict(
        source=input_path,
        conf=conf,
        iou=iou,
        save=False,
        verbose=False
    )

    result = results[0]

    # Nacrtaj bounding boxeve i spremi sliku
    annotated = result.plot()

    import cv2
    cv2.imwrite(output_path, annotated)

    # Pripremi JSON s detaljima detekcija
    detections = []
    for box in result.boxes:
        cls_id = int(box.cls[0].item())
        cls_name = model.names[cls_id]
        conf_val = float(box.conf[0].item())
        xyxy = box.xyxy[0].tolist()
        detections.append({
            "class_id": cls_id,
            "class_name": cls_name,
            "confidence": round(conf_val, 4),
            "bbox": {
                "x1": round(xyxy[0], 1),
                "y1": round(xyxy[1], 1),
                "x2": round(xyxy[2], 1),
                "y2": round(xyxy[3], 1)
            }
        })

    return {
        "status": "ok",
        "mode": "image",
        "input": input_path,
        "output": output_path,
        "total_detections": len(detections),
        "detections": detections
    }


def run_video_inference(model, input_path, output_path, conf, iou):
    """
    Rastavi video na okvire, primijeni YOLO, spoji nazad u MP4.
    Koristi OpenCV za dekodiranje i enkodiranje.
    """
    import cv2

    cap = cv2.VideoCapture(input_path)
    if not cap.isOpened():
        raise ValueError(f"Ne mogu otvoriti video: {input_path}")

    fps        = cap.get(cv2.CAP_PROP_FPS) or 25.0
    width      = int(cap.get(cv2.CAP_PROP_FRAME_WIDTH))
    height     = int(cap.get(cv2.CAP_PROP_FRAME_HEIGHT))
    total_frames = int(cap.get(cv2.CAP_PROP_FRAME_COUNT))

    fourcc = cv2.VideoWriter_fourcc(*"mp4v")
    out    = cv2.VideoWriter(output_path, fourcc, fps, (width, height))

    frame_idx        = 0
    total_detections = 0

    while True:
        ret, frame = cap.read()
        if not ret:
            break

        results = model.predict(
            source=frame,
            conf=conf,
            iou=iou,
            save=False,
            verbose=False
        )

        annotated = results[0].plot()
        out.write(annotated)
        total_detections += len(results[0].boxes)
        frame_idx += 1

        # Ispiši napredak na stderr (C# može ga čitati ako želi)
        if frame_idx % 30 == 0 or frame_idx == total_frames:
            progress = int((frame_idx / max(total_frames, 1)) * 100)
            print(f"PROGRESS:{progress}", file=sys.stderr, flush=True)

    cap.release()
    out.release()

    return {
        "status": "ok",
        "mode": "video",
        "input": input_path,
        "output": output_path,
        "frames_processed": frame_idx,
        "total_detections": total_detections,
        "fps": fps,
        "resolution": f"{width}x{height}"
    }


def main():
    parser = argparse.ArgumentParser(description="YOLO inference backend")
    parser.add_argument("--mode",   required=True, choices=["image", "video"],
                        help="Tip ulaza: image ili video")
    parser.add_argument("--input",  required=True, help="Putanja do ulaznog fajla")
    parser.add_argument("--output", required=True, help="Putanja za izlazni fajl")
    parser.add_argument("--model",  required=True, help="Putanja do best.pt modela")
    parser.add_argument("--conf",   type=float, default=0.25,
                        help="Prag pouzdanosti (default: 0.25)")
    parser.add_argument("--iou",    type=float, default=0.45,
                        help="IoU prag za NMS (default: 0.45)")
    args = parser.parse_args()

    # Provjeri postoje li ulazni fajlovi
    if not os.path.isfile(args.input):
        print(json.dumps({"status": "error", "message": f"Ulazni fajl ne postoji: {args.input}"}))
        sys.exit(1)
    if not os.path.isfile(args.model):
        print(json.dumps({"status": "error", "message": f"Model ne postoji: {args.model}"}))
        sys.exit(1)

    try:
        from ultralytics import YOLO
        model = YOLO(args.model)

        if args.mode == "image":
            result_data = run_image_inference(model, args.input, args.output, args.conf, args.iou)
        else:
            result_data = run_video_inference(model, args.input, args.output, args.conf, args.iou)

        print(json.dumps(result_data, ensure_ascii=False))
        sys.exit(0)

    except Exception as e:
        error_data = {
            "status": "error",
            "message": str(e),
            "traceback": traceback.format_exc()
        }
        print(json.dumps(error_data, ensure_ascii=False))
        sys.exit(1)


if __name__ == "__main__":
    main()
