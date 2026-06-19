using System.Windows.Forms;

namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnStopCamera = new System.Windows.Forms.Button();
            this.btnFaceMask = new System.Windows.Forms.Button();
            this.btnFaceDetect = new System.Windows.Forms.Button();
            this.btnVideoOCR = new System.Windows.Forms.Button();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.btnDetectTextRegions = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.videoTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxSelected = new System.Windows.Forms.PictureBox();
            this.txtVideoText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(20, 119);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(450, 400);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 0;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Location = new System.Drawing.Point(520, 119);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(450, 400);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResult.TabIndex = 1;
            this.pictureBoxResult.TabStop = false;
            this.pictureBoxResult.Click += new System.EventHandler(this.pictureBoxResult_Click);
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelControls.Controls.Add(this.btnStopCamera);
            this.panelControls.Controls.Add(this.btnFaceMask);
            this.panelControls.Controls.Add(this.btnFaceDetect);
            this.panelControls.Controls.Add(this.btnVideoOCR);
            this.panelControls.Controls.Add(this.btnStartCamera);
            this.panelControls.Controls.Add(this.btnDetectTextRegions);
            this.panelControls.Controls.Add(this.btnLoadImage);
            this.panelControls.Location = new System.Drawing.Point(20, 10);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(960, 90);
            this.panelControls.TabIndex = 2;
            // 
            // btnStopCamera
            // 
            this.btnStopCamera.Location = new System.Drawing.Point(774, 49);
            this.btnStopCamera.Name = "btnStopCamera";
            this.btnStopCamera.Size = new System.Drawing.Size(120, 32);
            this.btnStopCamera.TabIndex = 10;
            this.btnStopCamera.Text = "Стоп";
            this.btnStopCamera.UseVisualStyleBackColor = true;
            this.btnStopCamera.Click += new System.EventHandler(this.btnStopCamera_Click);
            // 
            // btnFaceMask
            // 
            this.btnFaceMask.Location = new System.Drawing.Point(556, 27);
            this.btnFaceMask.Name = "btnFaceMask";
            this.btnFaceMask.Size = new System.Drawing.Size(120, 35);
            this.btnFaceMask.TabIndex = 9;
            this.btnFaceMask.Text = "Маски на лица";
            this.btnFaceMask.UseVisualStyleBackColor = true;
            this.btnFaceMask.Click += new System.EventHandler(this.btnFaceMask_Click);
            // 
            // btnFaceDetect
            // 
            this.btnFaceDetect.Location = new System.Drawing.Point(420, 27);
            this.btnFaceDetect.Name = "btnFaceDetect";
            this.btnFaceDetect.Size = new System.Drawing.Size(130, 35);
            this.btnFaceDetect.TabIndex = 8;
            this.btnFaceDetect.Text = "Обнаружение лиц";
            this.btnFaceDetect.UseVisualStyleBackColor = true;
            // 
            // btnVideoOCR
            // 
            this.btnVideoOCR.Location = new System.Drawing.Point(294, 25);
            this.btnVideoOCR.Name = "btnVideoOCR";
            this.btnVideoOCR.Size = new System.Drawing.Size(120, 35);
            this.btnVideoOCR.TabIndex = 7;
            this.btnVideoOCR.Text = "Текст с видео";
            this.btnVideoOCR.UseVisualStyleBackColor = true;
            this.btnVideoOCR.Click += new System.EventHandler(this.btnVideoOCR_Click);
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Location = new System.Drawing.Point(774, 8);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(120, 35);
            this.btnStartCamera.TabIndex = 5;
            this.btnStartCamera.Text = "Захват камеры";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // btnDetectTextRegions
            // 
            this.btnDetectTextRegions.Location = new System.Drawing.Point(160, 25);
            this.btnDetectTextRegions.Name = "btnDetectTextRegions";
            this.btnDetectTextRegions.Size = new System.Drawing.Size(120, 35);
            this.btnDetectTextRegions.TabIndex = 4;
            this.btnDetectTextRegions.Text = "Поиск текста";
            this.btnDetectTextRegions.UseVisualStyleBackColor = true;
            this.btnDetectTextRegions.Click += new System.EventHandler(this.btnDetectTextRegions_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(10, 25);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(140, 35);
            this.btnLoadImage.TabIndex = 3;
            this.btnLoadImage.Text = "Загрузить изображение";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelStatus.Location = new System.Drawing.Point(20, 540);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(50, 17);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Готово";
            // 
            // pictureBoxSelected
            // 
            this.pictureBoxSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSelected.Location = new System.Drawing.Point(520, 530);
            this.pictureBoxSelected.Name = "pictureBoxSelected";
            this.pictureBoxSelected.Size = new System.Drawing.Size(300, 69);
            this.pictureBoxSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelected.TabIndex = 0;
            this.pictureBoxSelected.TabStop = false;
            // 
            // txtVideoText
            // 
            this.txtVideoText.Location = new System.Drawing.Point(520, 605);
            this.txtVideoText.Multiline = true;
            this.txtVideoText.Name = "txtVideoText";
            this.txtVideoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVideoText.Size = new System.Drawing.Size(300, 50);
            this.txtVideoText.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 679);
            this.Controls.Add(this.txtVideoText);
            this.Controls.Add(this.pictureBoxSelected);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обработка изображений и виде";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.panelControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnFaceDetect;
        private System.Windows.Forms.Button btnVideoOCR;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.Button btnDetectTextRegions;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnFaceMask;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Timer videoTimer;
        private Button btnStopCamera;
        private TextBox txtVideoText;
    }
}

