using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Emgu.CV;
using Emgu.CV.Structure;

namespace EmguCvDetectFace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image<Bgr, Byte> ImageFrame;
        private CascadeClassifier _cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        Image InputImg;
        string filePath = "";

        private void picImageFace_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFile.FileName;
                    string fileName = Path.GetFileName(openFile.FileName);
                    //InputImg = Image.FromFile(openFile.FileName);
                    InputImg = AutoResizeImage(openFile.FileName);
                    //ImageFrame = new Image<Bgr, byte>(openFile.FileName);
                    //ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
                    ImageFrame = new Bitmap(InputImg).ToImage<Bgr,byte>();
                    picImageFace.Image = ImageFrame.AsBitmap();
                }
                else
                {
                    MessageBox.Show("No file selected.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Image AutoResizeImage(string url)
        {
            var InputImg = Image.FromFile(url);
            ImageFrame = new Bitmap(InputImg).ToImage<Bgr, byte>();
            Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
            var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);

            if (faces.Length > 0)
            {
                Bitmap BmpInput = grayframe.ToBitmap();
                Bitmap ExtractedFace;
                Graphics FaceCanvas;

                foreach (var face in faces)
                {
                    ImageFrame.Draw(face, new Bgr(Color.Blue), 4);
                    ExtractedFace = new Bitmap(face.Width, face.Height);
                    FaceCanvas = Graphics.FromImage(ExtractedFace);

                    FaceCanvas.DrawImage(BmpInput, 0, 0, face, GraphicsUnit.Pixel);
                    int w = face.Width;
                    int h = face.Height;
                    int x = face.X;
                    int y = face.Y;

                    int r = Math.Max(250, 250) / 2;
                    int centerx = x + w / 2;
                    int centery = y + h / 2;
                    int nx = (int)(centerx - r);
                    int ny = (int)(centery - r);
                    int nr = (int)(r * 5);


                    double zoomFactor = (double)197 / (double)face.Width;
                    Size newSize = new Size((int)(InputImg.Width * zoomFactor), (int)(InputImg.Height * zoomFactor));
                    Bitmap bmp = new Bitmap(InputImg, newSize);
                    return (Image)bmp;
                }


            }
            return InputImg;
        }

        private void DetectFaces()
        {
            try
            {
                Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>().Clone();
                _cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_default.xml");
                Rectangle[] faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                if (faces.Length > 0)
                {
                    Bitmap BmpInput = grayframe.ToBitmap();
                    Bitmap ExtractedFace;
                    Graphics FaceCanvas;

                    foreach (var face in faces)
                    {
                        ImageFrame.Draw(face, new Bgr(Color.Blue), 4);
                        ExtractedFace = new Bitmap(face.Width, face.Height);
                        FaceCanvas = Graphics.FromImage(ExtractedFace);
                        FaceCanvas.DrawImage(BmpInput, 0, 0, face, GraphicsUnit.Pixel);
                        if (face.Width < 100) { return; }
                        int w = face.Width;
                        int h = face.Height;
                        int x = face.X;
                        int y = face.Y;

                        int r = Math.Max(250, 250) / 2;
                        int centerx = x + w / 2;
                        int centery = y + h / 2;
                        int nx = (int)(centerx - r);
                        int ny = (int)(centery - r);
                        int nr = (int)(r * 5);


                        double zoomFactor = (double)197 / (double)face.Width;
                        Size newSize = new Size((int)(InputImg.Width * zoomFactor), (int)(InputImg.Height * zoomFactor));
                        Bitmap bmp = new Bitmap(InputImg, newSize);
                        picDetectFace.Image = (Image)bmp;
                        var imgextract = CropImage(picDetectFace.Image, nx + 4, ny - 25, 248, 340);
                        picDetectFace.Image = imgextract;
                    }

                    picImageFace.Image = ImageFrame.AsBitmap();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public  Bitmap CropImage(Image source, int x, int y, int width, int height)
        {
            Rectangle crop = new Rectangle(x, y, width, height);
            string cropFileName = "";
            string cropFilePath = "";
            string fileName = ""; 
            if (File.Exists(filePath))
            {
                 fileName = Path.GetFileName(filePath);

            }
            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            //cropFileName = "crop_" + fileName;
            //cropFilePath = Path.Combine(Path.GetDirectoryName(filePath),"DetectCrop", cropFileName);
            string folderCropPath = Path.Combine(Path.GetDirectoryName(filePath), "DetectCrop");
            if (!Directory.Exists(folderCropPath))
            {
                Directory.CreateDirectory(folderCropPath);
            }
            cropFilePath = Path.Combine(folderCropPath, fileName);
            bmp.Save(cropFilePath);
            return bmp;
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            DetectFaces();
        }
    }
}
