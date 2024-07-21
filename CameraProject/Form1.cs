using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace CameraProject
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        private VideoWriter videoWriter;
        private bool isRecording = false;
        private string videoFileName;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize filterInfoCollection and populate comboBox1 with available video devices
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                comboBox1.Items.Add(device.Name);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; // Select the first camera by default
            }
            else
            {
                MessageBox.Show("No video devices found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.Start();
            }
            else
            {
                MessageBox.Show("Please select a video source from the list.");
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                pictureBox1.Invoke((MethodInvoker)delegate
                {
                    pictureBox1.Image = bitmap;
                });

                if (isRecording)
                {
                    using (Mat mat = BitmapToMat(bitmap))
                    {
                        videoWriter.Write(mat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error capturing frame: " + ex.Message);
            }
        }

        private Mat BitmapToMat(Bitmap bitmap)
        {
            Mat mat = new Mat(bitmap.Height, bitmap.Width, DepthType.Cv8U, 3);
            System.Drawing.Imaging.BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* src = (byte*)bitmapData.Scan0;
                for (int y = 0; y < bitmap.Height; y++)
                {
                    byte* dest = (byte*)mat.DataPointer + y * mat.Step;
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        dest[x * 3] = src[x * 3 + 2]; // B
                        dest[x * 3 + 1] = src[x * 3 + 1]; // G
                        dest[x * 3 + 2] = src[x * 3]; // R
                    }
                }
            }
            bitmap.UnlockBits(bitmapData);
            return mat;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopVideoCaptureDevice();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            StopVideoCaptureDevice();
        }

        private void StopVideoCaptureDevice()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();
            }
            if (isRecording)
            {
                StopRecording();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:\\Users\\hung\\OneDrive\\Pictures\\Saved Pictures";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void StopRecording()
        {
            if (isRecording)
            {
                isRecording = false;
                videoWriter.Dispose();
            }
        }

        private void buttonStartRecording_Click_1(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                saveFileDialog1.Filter = "AVI Files (*.avi)|*.avi|MP4 Files (*.mp4)|*.mp4";
                saveFileDialog1.InitialDirectory = "C:\\Users\\hung\\OneDrive\\Pictures\\Saved Pictures";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    videoFileName = saveFileDialog1.FileName;
                    // Extract the codec from the file extension
                    string fileExtension = System.IO.Path.GetExtension(videoFileName).ToLower();
                    int codec = fileExtension == ".mp4" ? FourCC.H264 : FourCC.MJPG;

                    videoWriter = new VideoWriter(videoFileName, codec, 25, new Size(pictureBox1.Width, pictureBox1.Height), true);
                    isRecording = true;
                }
            }
            else
            {
                MessageBox.Show("Please start the camera first.");
            }
        }

        private void buttonStopRecording_Click_1(object sender, EventArgs e)
        {
            if (isRecording)
            {
                StopRecording();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public static class FourCC
    {
        public const int MJPG = 1196444237; // "MJPG" FourCC
        public const int XVID = 1145656920; // "XVID" FourCC
        public const int H264 = 875967075;  // "H264" FourCC (for MP4)
        // Add other FourCC codes as needed
    }
}
