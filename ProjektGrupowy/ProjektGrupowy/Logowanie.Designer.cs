namespace ProjektGrupowy
{
    partial class Logowanie
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
            this.Login = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.Haslo = new System.Windows.Forms.Label();
            this.LoginOK = new System.Windows.Forms.Button();
            this.LoginAnuluj = new System.Windows.Forms.Button();
            this.LoginRemind = new System.Windows.Forms.Button();
            this.HasloBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Login.Location = new System.Drawing.Point(9, 9);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(41, 16);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(12, 26);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(194, 20);
            this.LoginBox.TabIndex = 1;
            // 
            // Haslo
            // 
            this.Haslo.AutoSize = true;
            this.Haslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Haslo.Location = new System.Drawing.Point(9, 61);
            this.Haslo.Name = "Haslo";
            this.Haslo.Size = new System.Drawing.Size(47, 16);
            this.Haslo.TabIndex = 3;
            this.Haslo.Text = "Hasło";
            // 
            // LoginOK
            // 
            this.LoginOK.Location = new System.Drawing.Point(12, 103);
            this.LoginOK.Name = "LoginOK";
            this.LoginOK.Size = new System.Drawing.Size(94, 28);
            this.LoginOK.TabIndex = 4;
            this.LoginOK.Text = "OK";
            this.LoginOK.UseVisualStyleBackColor = true;
            this.LoginOK.Click += new System.EventHandler(this.LoginOK_Click);
            // 
            // LoginAnuluj
            // 
            this.LoginAnuluj.Location = new System.Drawing.Point(112, 103);
            this.LoginAnuluj.Name = "LoginAnuluj";
            this.LoginAnuluj.Size = new System.Drawing.Size(94, 28);
            this.LoginAnuluj.TabIndex = 5;
            this.LoginAnuluj.Text = "Anuluj";
            this.LoginAnuluj.UseVisualStyleBackColor = true;
            this.LoginAnuluj.Click += new System.EventHandler(this.LoginAnuluj_Click);
            // 
            // LoginRemind
            // 
            this.LoginRemind.Location = new System.Drawing.Point(12, 137);
            this.LoginRemind.Name = "LoginRemind";
            this.LoginRemind.Size = new System.Drawing.Size(194, 32);
            this.LoginRemind.TabIndex = 6;
            this.LoginRemind.Text = "Przypomnij hasło";
            this.LoginRemind.UseVisualStyleBackColor = true;
            this.LoginRemind.Click += new System.EventHandler(this.LoginRemind_Click);
            // 
            // HasloBox
            // 
            this.HasloBox.Location = new System.Drawing.Point(12, 77);
            this.HasloBox.Name = "HasloBox";
            this.HasloBox.PasswordChar = '*';
            this.HasloBox.Size = new System.Drawing.Size(194, 20);
            this.HasloBox.TabIndex = 2;
            this.HasloBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HasloBox_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::ProjektGrupowy.Properties.Resources.ajax_loader__1_;
            this.pictureBox1.Location = new System.Drawing.Point(86, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 171);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HasloBox);
            this.Controls.Add(this.LoginRemind);
            this.Controls.Add(this.LoginAnuluj);
            this.Controls.Add(this.LoginOK);
            this.Controls.Add(this.Haslo);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.Login);
            this.Name = "Logowanie";
            this.Text = "Logowanie";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Logowanie_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Label Haslo;
        private System.Windows.Forms.Button LoginOK;
        private System.Windows.Forms.Button LoginAnuluj;
        private System.Windows.Forms.Button LoginRemind;
        private System.Windows.Forms.TextBox HasloBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}