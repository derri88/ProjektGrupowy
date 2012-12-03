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
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Location = new System.Drawing.Point(12, 10);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(33, 13);
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
            this.Haslo.Location = new System.Drawing.Point(12, 49);
            this.Haslo.Name = "Haslo";
            this.Haslo.Size = new System.Drawing.Size(36, 13);
            this.Haslo.TabIndex = 3;
            this.Haslo.Text = "Hasło";
            // 
            // LoginOK
            // 
            this.LoginOK.Location = new System.Drawing.Point(12, 91);
            this.LoginOK.Name = "LoginOK";
            this.LoginOK.Size = new System.Drawing.Size(94, 28);
            this.LoginOK.TabIndex = 4;
            this.LoginOK.Text = "OK";
            this.LoginOK.UseVisualStyleBackColor = true;
            this.LoginOK.Click += new System.EventHandler(this.LoginOK_Click);
            // 
            // LoginAnuluj
            // 
            this.LoginAnuluj.Location = new System.Drawing.Point(112, 91);
            this.LoginAnuluj.Name = "LoginAnuluj";
            this.LoginAnuluj.Size = new System.Drawing.Size(94, 28);
            this.LoginAnuluj.TabIndex = 5;
            this.LoginAnuluj.Text = "Anuluj";
            this.LoginAnuluj.UseVisualStyleBackColor = true;
            this.LoginAnuluj.Click += new System.EventHandler(this.LoginAnuluj_Click);
            // 
            // LoginRemind
            // 
            this.LoginRemind.Location = new System.Drawing.Point(12, 125);
            this.LoginRemind.Name = "LoginRemind";
            this.LoginRemind.Size = new System.Drawing.Size(194, 32);
            this.LoginRemind.TabIndex = 6;
            this.LoginRemind.Text = "Przypomnij hasło";
            this.LoginRemind.UseVisualStyleBackColor = true;
            this.LoginRemind.Click += new System.EventHandler(this.LoginRemind_Click);
            // 
            // HasloBox
            // 
            this.HasloBox.Location = new System.Drawing.Point(12, 65);
            this.HasloBox.Name = "HasloBox";
            this.HasloBox.PasswordChar = '*';
            this.HasloBox.Size = new System.Drawing.Size(194, 20);
            this.HasloBox.TabIndex = 2;
            // 
            // Logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 165);
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
    }
}