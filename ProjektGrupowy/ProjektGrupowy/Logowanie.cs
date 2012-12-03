using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjektGrupowy
{
    public partial class Logowanie : Form
    {

        public Logowanie()
        {
            InitializeComponent();
        }

        private void Logowanie_Closing(object sender, EventArgs e)
        {
            Program.Start1.Show();
        }

        private void LoginOK_Click(object sender, EventArgs e)
        {
            Panel Panel = new Panel();
            Panel.Show();
            Program.Start1.Hide();
            this.Close();
        }

        private void LoginAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.Start1.Show();
        }

        private void LoginRemind_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasło wysłane");
            this.Close();
            Program.Start1.Show();
        }

        private void Logowanie_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

    }
}
