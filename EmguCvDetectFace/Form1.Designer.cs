namespace EmguCvDetectFace
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImageFace = new System.Windows.Forms.PictureBox();
            this.picDetectFace = new System.Windows.Forms.PictureBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnDetect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImageFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetectFace)).BeginInit();
            this.SuspendLayout();
            // 
            // picImageFace
            // 
            this.picImageFace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImageFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImageFace.Location = new System.Drawing.Point(-5, 46);
            this.picImageFace.Name = "picImageFace";
            this.picImageFace.Size = new System.Drawing.Size(415, 231);
            this.picImageFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImageFace.TabIndex = 0;
            this.picImageFace.TabStop = false;
            this.picImageFace.Click += new System.EventHandler(this.picImageFace_Click);
            // 
            // picDetectFace
            // 
            this.picDetectFace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDetectFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDetectFace.Location = new System.Drawing.Point(432, 46);
            this.picDetectFace.Name = "picDetectFace";
            this.picDetectFace.Size = new System.Drawing.Size(356, 231);
            this.picDetectFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDetectFace.TabIndex = 0;
            this.picDetectFace.TabStop = false;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(-5, 17);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(258, 17);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(75, 23);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.picDetectFace);
            this.Controls.Add(this.picImageFace);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picImageFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetectFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImageFace;
        private System.Windows.Forms.PictureBox picDetectFace;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnDetect;
    }
}

