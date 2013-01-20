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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }


        private void Logowanie_Click(object sender, EventArgs e)
        {
            Logowanie Logowanie = new Logowanie();
            Logowanie.Show();
            this.Hide();
        }

        private void Gosc_Click(object sender, EventArgs e)
        {
            Panel Panel = new Panel();
            Program.Start1.Hide();

            Panel.MOcenyList.Clear();
            Panel.MOcenyGroup.Enabled = false;
            Panel.DaneGroup.Enabled = false;
            Panel.POcenaGroup.Enabled = false;
            Panel.ZEditGroup.Enabled = false;
            Panel.PEditGroup.Enabled = false;
            Panel.PanelTabControl.SelectedTab = Panel.TabZespoly;
            Panel.Show();
        }
    }
}
