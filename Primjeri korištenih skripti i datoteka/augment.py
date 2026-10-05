import albumentations as A
import cv2
import os
from pathlib import Path

transform = A.Compose([
    A.HorizontalFlip(p=0.5),
    A.RandomBrightnessContrast(brightness_limit=0.2, contrast_limit=0.2, p=0.5),
    A.Rotate(limit=15, p=0.5),
    A.Blur(blur_limit=3, p=0.2),
    A.RandomScale(scale_limit=0.2, p=0.3),
    A.GaussNoise(p=0.2),
], bbox_params=A.BboxParams(format='yolo', label_fields=['class_labels']))

input_images = 'images/'
input_labels = 'labels/'
output_images = 'augmented_images/'
output_labels = 'augmented_labels/'

os.makedirs(output_images, exist_ok=True)
os.makedirs(output_labels, exist_ok=True)

image_extensions = ['.jpg', '.jpeg', '.png', '.JPG', '.JPEG', '.PNG']

for img_file in os.listdir(input_images):
    if not any(img_file.endswith(ext) for ext in image_extensions):
        continue
    
    image = cv2.imread(os.path.join(input_images, img_file))
    base_name = Path(img_file).stem
    
    label_file = os.path.join(input_labels, base_name + '.txt')
    bboxes = []
    class_labels = []
    
    with open(label_file, 'r') as f:
        for line in f.readlines():
            parts = line.strip().split()
            class_labels.append(int(parts[0]))
            bboxes.append([float(x) for x in parts[1:5]])
    
    for i in range(9):
        augmented = transform(image=image, bboxes=bboxes, class_labels=class_labels)
        
        output_img_path = os.path.join(output_images, f'{base_name}_aug_{i}.jpg')
        cv2.imwrite(output_img_path, augmented['image'])
        
        output_label_path = os.path.join(output_labels, f'{base_name}_aug_{i}.txt')
        with open(output_label_path, 'w') as f:
            for cls, bbox in zip(augmented['class_labels'], augmented['bboxes']):
                f.write(f"{cls} {bbox[0]} {bbox[1]} {bbox[2]} {bbox[3]}\n")

print(f"Augmentation complete! Generated {len(os.listdir(output_images))} images.")
