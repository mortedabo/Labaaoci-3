using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;


namespace Lab3
{
    public partial class Form1 : Form
    {
        private Mat originalImage;
        private Mat processedImage;
        private OpenCvSharp.Point[][] detectedContours;
        private PictureBox pictureBoxSelected;
        private Tesseract.TesseractEngine ocrEngine;
        private VideoCapture capture;
        private Mat frame;
        private Timer timer;
        private CascadeClassifier faceCascade;
        private bool faceMaskEnabled = false;
        private Mat lastFrame;

        public Form1()
        {
            InitializeComponent();
            pictureBoxResult.MouseClick += pictureBoxResult_MouseClick;
            ocrEngine = new Tesseract.TesseractEngine(
        @"./tessdata",
        "rus+eng",
        Tesseract.EngineMode.Default
    );
            faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");
        }
        private void pictureBoxResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (detectedContours == null || originalImage == null)
                return;

           
            var pb = pictureBoxResult;

            float imageWidth = originalImage.Width;
            float imageHeight = originalImage.Height;

            float boxWidth = pb.Width;
            float boxHeight = pb.Height;

            float scaleX = imageWidth / boxWidth;
            float scaleY = imageHeight / boxHeight;

            
            int imgX = (int)(e.X * scaleX);
            int imgY = (int)(e.Y * scaleY);

            foreach (var c in detectedContours)
            {
                Rect r = Cv2.BoundingRect(c);

                if (imgX >= r.X && imgX <= r.X + r.Width &&
                    imgY >= r.Y && imgY <= r.Y + r.Height)
                {
                    Mat roi = new Mat(originalImage, r);

                    pictureBoxSelected.Image = BitmapConverter.ToBitmap(roi);

                    labelStatus.Text = $"Область выбрана: {r.Width}x{r.Height}";

                    MessageBox.Show("ROI выбрано");

                    return;
                }
            }

            labelStatus.Text = "Клик мимо области";
        }
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Выберите изображение";
            openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                originalImage = Cv2.ImRead(openFileDialog.FileName);

                if (originalImage.Empty())
                {
                    labelStatus.Text = "Ошибка загрузки изображения";
                    return;
                }

               
                pictureBoxOriginal.Image = BitmapConverter.ToBitmap(originalImage);

                
                pictureBoxResult.Image = null;
                processedImage = null;

                
                labelStatus.Text = "Изображение загружено";
            }
        }
        private void btnDetectTextRegions_Click(object sender, EventArgs e)
        {
            if (originalImage == null || originalImage.Empty())
            {
                labelStatus.Text = "Сначала загрузите изображение";
                return;
            }

            labelStatus.Text = "Поиск текстовых областей...";

            Mat result = originalImage.Clone();

            Mat gray = new Mat();
            Cv2.CvtColor(originalImage, gray, ColorConversionCodes.BGR2GRAY);

            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(5, 5), 0);

            Mat binary = new Mat();
            Cv2.Threshold(
                gray,
                binary,
                0,
                255,
                ThresholdTypes.BinaryInv | ThresholdTypes.Otsu
            );

            Mat kernel = Cv2.GetStructuringElement(
                MorphShapes.Rect,
                new OpenCvSharp.Size(25, 5)
            );

            Cv2.MorphologyEx(binary, binary, MorphTypes.Close, kernel);

            Cv2.FindContours(
                binary,
                out OpenCvSharp.Point[][] contours,
                out HierarchyIndex[] hierarchy,
                RetrievalModes.External,
                ContourApproximationModes.ApproxSimple
            );

            foreach (var contour in contours)
            {
                Rect rect = Cv2.BoundingRect(contour);

                if (rect.Width > 30 && rect.Height > 10)
                {
                    Cv2.Rectangle(result, rect, Scalar.Red, 2);
                }
            }

            processedImage = result;
            pictureBoxResult.Image = BitmapConverter.ToBitmap(result);

            labelStatus.Text = "Текстовые области найдены";
            detectedContours = contours;
        }

        private void pictureBoxResult_Click(object sender, EventArgs e)
        {
            if (processedImage == null || processedImage.Empty())
                return;

           
        }

        private void btnRecognizeText_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBoxSelected.Image == null)
                {
                    labelStatus.Text = "Сначала выберите область";
                    return;
                }

                Bitmap bmp = new Bitmap(pictureBoxSelected.Image);

                var pix = Tesseract.PixConverter.ToPix(bmp);

                using (var page = ocrEngine.Process(pix))
                {
                    string text = page.GetText();

                    MessageBox.Show(text, "Распознанный текст");

                    labelStatus.Text = "OCR завершён";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            capture = new VideoCapture(0); 
            frame = new Mat();

            timer = new Timer();
            timer.Interval = 30; 
            timer.Tick += Timer_Tick;
            timer.Start();

            labelStatus.Text = "Камера запущена";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (capture == null || !capture.IsOpened())
                    return;

                capture.Read(frame);

                if (frame == null || frame.Empty())
                    return;
                lastFrame?.Dispose();
                lastFrame = frame.Clone();

                Mat result = frame.Clone();

                
                Mat gray = new Mat();
                Cv2.CvtColor(result, gray, ColorConversionCodes.BGR2GRAY);

                // Поиск лиц
                Rect[] faces = faceCascade.DetectMultiScale(
                    gray,
                    1.1,
                    5,
                    HaarDetectionTypes.ScaleImage,
                    new OpenCvSharp.Size(30, 30)
                );

                foreach (var face in faces)
                {
                    
                    if (faceMaskEnabled)
                    {
                        Mat faceRegion = new Mat(result, face);

                        Mat blurred = new Mat();

                        Cv2.GaussianBlur(
                            faceRegion,
                            blurred,
                            new OpenCvSharp.Size(99, 99),
                            30
                        );

                        blurred.CopyTo(faceRegion);
                    }

                    
                    Cv2.Rectangle(
                        result,
                        face,
                        Scalar.Green,
                        2
                    );

                    
                    Cv2.PutText(
                        result,
                        "Face",
                        new OpenCvSharp.Point(face.X, face.Y - 5),
                        HersheyFonts.HersheySimplex,
                        0.6,
                        Scalar.Green,
                        2
                    );
                }

                pictureBoxResult.Image?.Dispose();
                pictureBoxResult.Image = BitmapConverter.ToBitmap(result);

                labelStatus.Text = $"Найдено лиц: {faces.Length}";
            }
            catch (Exception ex)
            {
                timer?.Stop();

                MessageBox.Show(
                    ex.Message,
                    "Ошибка обработки видео"
                );
            }
        }
        private void btnFaceMask_Click(object sender, EventArgs e)
        {
            faceMaskEnabled = !faceMaskEnabled;

            if (faceMaskEnabled)
            {
                labelStatus.Text = "Маски включены";
                btnFaceMask.Text = "Убрать маски";
            }
            else
            {
                labelStatus.Text = "Маски выключены";
                btnFaceMask.Text = "Маски на лица";
            }
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            timer?.Stop();
            capture?.Release();
            frame?.Dispose();

            labelStatus.Text = "Камера остановлена";
        }

        private void btnVideoOCR_Click(object sender, EventArgs e)
        {
            try
            {
                if (lastFrame == null || lastFrame.Empty())
                {
                    MessageBox.Show("Кадр с камеры отсутствует");
                    return;
                }

                Mat gray = new Mat();

                Cv2.CvtColor(
                    lastFrame,
                    gray,
                    ColorConversionCodes.BGR2GRAY
                );

                Cv2.Threshold(
                    gray,
                    gray,
                    0,
                    255,
                    ThresholdTypes.Binary | ThresholdTypes.Otsu
                );

                Bitmap bmp = BitmapConverter.ToBitmap(gray);

                using (var pix = Tesseract.PixConverter.ToPix(bmp))
                {
                    using (var page = ocrEngine.Process(pix))
                    {
                        string text = page.GetText();

                        txtVideoText.Text = text;

                        labelStatus.Text =
                            "Текст с видеопотока получен";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}