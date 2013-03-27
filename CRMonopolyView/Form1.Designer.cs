namespace CRMonopolyView
{
    partial class SpeelBordUI
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
            this.RunPlayerRun = new System.Windows.Forms.Button();
            this.tbStappen = new System.Windows.Forms.TextBox();
            this.tbCurrentPosition = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RunPlayerRun
            // 
            this.RunPlayerRun.Location = new System.Drawing.Point(792, 26);
            this.RunPlayerRun.Name = "RunPlayerRun";
            this.RunPlayerRun.Size = new System.Drawing.Size(94, 47);
            this.RunPlayerRun.TabIndex = 1;
            this.RunPlayerRun.Text = "Loop";
            this.RunPlayerRun.UseVisualStyleBackColor = true;
            this.RunPlayerRun.Click += new System.EventHandler(this.RunPlayerRun_Click);
            // 
            // tbStappen
            // 
            this.tbStappen.Location = new System.Drawing.Point(797, 92);
            this.tbStappen.Name = "tbStappen";
            this.tbStappen.Size = new System.Drawing.Size(88, 20);
            this.tbStappen.TabIndex = 2;
            // 
            // tbCurrentPosition
            // 
            this.tbCurrentPosition.Location = new System.Drawing.Point(798, 133);
            this.tbCurrentPosition.Name = "tbCurrentPosition";
            this.tbCurrentPosition.ReadOnly = true;
            this.tbCurrentPosition.Size = new System.Drawing.Size(88, 20);
            this.tbCurrentPosition.TabIndex = 3;
            // 
            // SpeelBordUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 723);
            this.Controls.Add(this.tbCurrentPosition);
            this.Controls.Add(this.tbStappen);
            this.Controls.Add(this.RunPlayerRun);
            this.Name = "SpeelBordUI";
            this.Text = "Monopoly";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunPlayerRun;
        private System.Windows.Forms.TextBox tbStappen;
        private System.Windows.Forms.TextBox tbCurrentPosition;
    }
}

