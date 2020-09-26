namespace idemery.Remoot.Forms
{
    partial class FormCast
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
            this.Desktop = new idemery.Remoot.ClientHelper.Desktop();
            this.SuspendLayout();
            // 
            // Desktop
            // 
            this.Desktop.BackColor = System.Drawing.Color.Black;
            this.Desktop.CompressionLevel = Aced.Compression.AcedCompressionLevel.Normal;
            this.Desktop.DebugInfo = null;
            this.Desktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Desktop.EnableDebug = false;
            this.Desktop.Location = new System.Drawing.Point(0, 0);
            this.Desktop.Name = "Desktop";
            this.Desktop.Size = new System.Drawing.Size(800, 450);
            this.Desktop.TabIndex = 0;
            // 
            // FormCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Desktop);
            this.Name = "FormCast";
            this.Text = "FormCast";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCast_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public ClientHelper.Desktop Desktop;
    }
}