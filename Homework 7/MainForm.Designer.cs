namespace Homework_7
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerRecover = new System.Windows.Forms.Timer(this.components);
            this.timerCount = new System.Windows.Forms.Timer(this.components);
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.btnControl = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelHighScore = new System.Windows.Forms.Label();
            this.pbComplete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // timerRecover
            // 
            this.timerRecover.Interval = 1000;
            this.timerRecover.Tick += new System.EventHandler(this.timerRecover_Tick);
            // 
            // timerCount
            // 
            this.timerCount.Interval = 1000;
            this.timerCount.Tick += new System.EventHandler(this.timerCount_Tick);
            // 
            // pbDeck
            // 
            this.pbDeck.BackColor = System.Drawing.Color.Transparent;
            this.pbDeck.Image = global::Homework_7.Properties.Resources.Deck;
            this.pbDeck.Location = new System.Drawing.Point(0, 0);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(350, 430);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeck.TabIndex = 0;
            this.pbDeck.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.ForeColor = System.Drawing.Color.Black;
            this.labelScore.Location = new System.Drawing.Point(400, 180);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(110, 12);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "目前分數 : 等待中 ...";
            // 
            // btnControl
            // 
            this.btnControl.Location = new System.Drawing.Point(415, 380);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(75, 23);
            this.btnControl.TabIndex = 3;
            this.btnControl.TabStop = false;
            this.btnControl.Text = "開始";
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.ForeColor = System.Drawing.Color.Black;
            this.labelTime.Location = new System.Drawing.Point(400, 205);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(113, 12);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "經過時間 : 等待中 ... ";
            // 
            // labelHighScore
            // 
            this.labelHighScore.AutoSize = true;
            this.labelHighScore.BackColor = System.Drawing.Color.Transparent;
            this.labelHighScore.ForeColor = System.Drawing.Color.Yellow;
            this.labelHighScore.Location = new System.Drawing.Point(400, 35);
            this.labelHighScore.Name = "labelHighScore";
            this.labelHighScore.Size = new System.Drawing.Size(110, 12);
            this.labelHighScore.TabIndex = 0;
            this.labelHighScore.Text = "最高紀錄 : 等待中 ...";
            // 
            // pbComplete
            // 
            this.pbComplete.BackColor = System.Drawing.Color.Transparent;
            this.pbComplete.Image = global::Homework_7.Properties.Resources.Win;
            this.pbComplete.Location = new System.Drawing.Point(385, 80);
            this.pbComplete.Name = "pbComplete";
            this.pbComplete.Size = new System.Drawing.Size(135, 65);
            this.pbComplete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbComplete.TabIndex = 5;
            this.pbComplete.TabStop = false;
            this.pbComplete.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Homework_7.Properties.Resources.FormBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(550, 427);
            this.Controls.Add(this.pbComplete);
            this.Controls.Add(this.labelHighScore);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pbDeck);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Homework 7";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbComplete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerRecover;
        private System.Windows.Forms.Timer timerCount;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelHighScore;
        public System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.PictureBox pbComplete;
    }
}

