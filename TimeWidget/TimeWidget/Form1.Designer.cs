namespace TimeWidget
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
            this.DayOfTheWeekLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DayOfTheWeekLabel
            // 
            this.DayOfTheWeekLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DayOfTheWeekLabel.Font = new System.Drawing.Font("TS Remarker", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DayOfTheWeekLabel.ForeColor = System.Drawing.Color.White;
            this.DayOfTheWeekLabel.Location = new System.Drawing.Point(0, 9);
            this.DayOfTheWeekLabel.Name = "DayOfTheWeekLabel";
            this.DayOfTheWeekLabel.Size = new System.Drawing.Size(311, 72);
            this.DayOfTheWeekLabel.TabIndex = 0;
            this.DayOfTheWeekLabel.Text = "Saturday";
            this.DayOfTheWeekLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DayOfTheWeekLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.DayOfTheWeekLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.DayOfTheWeekLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.UpdateTime);
            // 
            // TimeLabel
            // 
            this.TimeLabel.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLabel.ForeColor = System.Drawing.Color.White;
            this.TimeLabel.Location = new System.Drawing.Point(0, 73);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(311, 39);
            this.TimeLabel.TabIndex = 1;
            this.TimeLabel.Text = "17:00:00";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 166);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.DayOfTheWeekLabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DayOfTheWeekLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label TimeLabel;
    }
}

