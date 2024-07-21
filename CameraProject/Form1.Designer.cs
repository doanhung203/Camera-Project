namespace CameraProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            buttonStopRecording = new Button();
            buttonStartRecording = new Button();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(186, 782);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(153, 28);
            comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(186, 861);
            button1.Name = "button1";
            button1.Size = new Size(143, 39);
            button1.TabIndex = 2;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(425, 861);
            button2.Name = "button2";
            button2.Size = new Size(143, 39);
            button2.TabIndex = 3;
            button2.Text = "Tako Photo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1080, 861);
            button3.Name = "button3";
            button3.Size = new Size(143, 39);
            button3.TabIndex = 4;
            button3.Text = "Stop";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "image name | *.jpg";
            // 
            // buttonStopRecording
            // 
            buttonStopRecording.Location = new Point(868, 861);
            buttonStopRecording.Name = "buttonStopRecording";
            buttonStopRecording.Size = new Size(143, 39);
            buttonStopRecording.TabIndex = 5;
            buttonStopRecording.Text = "StopRecording";
            buttonStopRecording.UseVisualStyleBackColor = true;
            buttonStopRecording.Click += buttonStopRecording_Click_1;
            // 
            // buttonStartRecording
            // 
            buttonStartRecording.Location = new Point(653, 861);
            buttonStartRecording.Name = "buttonStartRecording";
            buttonStartRecording.Size = new Size(143, 39);
            buttonStartRecording.TabIndex = 6;
            buttonStartRecording.Text = "StartRecording";
            buttonStartRecording.UseVisualStyleBackColor = true;
            buttonStartRecording.Click += buttonStartRecording_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(63, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1528, 667);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(1331, 861);
            button4.Name = "button4";
            button4.Size = new Size(143, 39);
            button4.TabIndex = 7;
            button4.Text = "Quit";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1632, 1007);
            Controls.Add(button4);
            Controls.Add(buttonStartRecording);
            Controls.Add(buttonStopRecording);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private SaveFileDialog saveFileDialog1;
        private Button buttonStopRecording;
        private Button buttonStartRecording;
        private PictureBox pictureBox1;
        private Button button4;
    }
}
