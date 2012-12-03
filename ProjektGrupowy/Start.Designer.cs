namespace ProjektGrupowy
{
    partial class Start
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
            this.Logowanie = new System.Windows.Forms.Button();
            this.Gosc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Logowanie
            // 
            this.Logowanie.Location = new System.Drawing.Point(12, 27);
            this.Logowanie.Name = "Logowanie";
            this.Logowanie.Size = new System.Drawing.Size(132, 46);
            this.Logowanie.TabIndex = 0;
            this.Logowanie.Text = "Logowanie";
            this.Logowanie.UseVisualStyleBackColor = true;
            this.Logowanie.Click += new System.EventHandler(this.Logowanie_Click);
            // 
            // Gosc
            // 
            this.Gosc.Location = new System.Drawing.Point(172, 27);
            this.Gosc.Name = "Gosc";
            this.Gosc.Size = new System.Drawing.Size(132, 46);
            this.Gosc.TabIndex = 1;
            this.Gosc.Text = "Wejdź jako gość";
            this.Gosc.UseVisualStyleBackColor = true;
            this.Gosc.Click += new System.EventHandler(this.Gosc_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 91);
            this.Controls.Add(this.Gosc);
            this.Controls.Add(this.Logowanie);
            this.Name = "Start";
            this.Text = "Start";
            
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Logowanie;
        private System.Windows.Forms.Button Gosc;
    }
}

