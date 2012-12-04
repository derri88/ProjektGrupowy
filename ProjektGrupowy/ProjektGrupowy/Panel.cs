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
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
        }

        public Panel(bool parametr)
        {
            InitializeComponent();
        }

        private void OcenaSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do dodania funkcja robiąca update w tabeli z ocenami");
            
        }

        private void MOcenyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Do dodania funkcja która przeniesie zaznaczony rekord do pól po prawej");
        }

        private void ZSzukaj_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do dodania funkcja która zapełni wynikami wyszukiwania listę po prawej, i wyświetli w grupie zespół pierwszy item z listy");
            ZespolyList.View = View.Details;
        }

        private void ZEditButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Odblokuje pola powyżej, docelowo edycja i dodawanie dostępne tylko dla admina ");
            this.ZOdblokuj();
            ZEditButton.Enabled = false;
            ZNewButton.Enabled = false;

        }

        private void ZNewButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Odblokuje i wyczyści pola powyżej");
            this.ZOdblokuj();
            this.ZWyczysc();
            ZEditButton.Enabled = false;
            ZNewButton.Enabled = false;
        }

        private void ZSaveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("gdy edycja - update; gdy nowy - insert; na koniec zablokuje pola powyżej");
            this.ZZablokuj();
            ZEditButton.Enabled = true;
            ZNewButton.Enabled = true;
        }

        private void ZespolyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Jeśli ilość płyt jest >0 to przeniesie do zakładki płyty, i tam wyświetli wszystkie płyty");
        }

        private void PSzukaj_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkcja która zapełni listę, i wyświetli pierwszę płytę w grupie płyta");
            PlytyList.View = View.Details;
        }

        private void POcenaDodaj_Click(object sender, EventArgs e)
        {
            MessageBox.Show("jeśli oceny brak - insert, jeśli ocena jest - update");
        }

        private void PEditButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Odblokuje pola powyżej");
            this.POdblokuj();
            PEditButton.Enabled = false;
            PNewButton.Enabled = false;
        }

        private void PAddButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Odblokuje i wyczyści pola powyżej");
            this.POdblokuj();
            this.PWyczysc();
            PEditButton.Enabled = false;
            PNewButton.Enabled = false;
        }

        private void PSaveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("gdy edycja - update; gdy nowy - insert; na koniec zablokuje pola powyżej");
            this.PZablokuj();
            PEditButton.Enabled = true;
            PNewButton.Enabled = true;
        }

        private void Panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Start1.Show();
        }

        private void TabMojeOceny_Click(object sender, EventArgs e)
        {
            //TabMojeOceny.Invalidate();
        }

        private void TabZespoly_Click(object sender, EventArgs e)
        {
            TabZespoly.Invalidate();
        }

        private void TabPlyty_Click(object sender, EventArgs e)
        {
            //TabPlyty.Invalidate();
        }

        private void ZCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wyświetl zaznaczony item z litView; na koniec zablokuje pola powyżej");
            this.ZZablokuj();
            ZEditButton.Enabled = true;
            ZNewButton.Enabled = true;
        }

        private void ZOdblokuj()
        {
            ZNazwaBox1.Enabled = true;
            ZGatunekBox1.Enabled = true;
            ZRokEndBox1.Enabled = true;
            ZRokStBox1.Enabled = true;
            ZCancel.Enabled = true;
            ZSaveButton.Enabled = true;
        }

        private void ZZablokuj()
        {
            ZNazwaBox1.Enabled = false;
            ZGatunekBox1.Enabled = false;
            ZRokEndBox1.Enabled = false;
            ZRokStBox1.Enabled = false;
            ZCancel.Enabled = false;
            ZSaveButton.Enabled = false;
        }

        private void ZWyczysc()
        {
            ZNazwaBox1.Text = "";
            ZGatunekBox1.Text = "";
            ZRokEndBox1.Text = "";
            ZRokStBox1.Text = "";
        }
        private void POdblokuj()
        {
            PNazwaBox1.Enabled = true;
            PGatunekBox1.Enabled = true;
            PZespolBox1.Enabled = true;
            PRokBox1.Enabled = true;
            PSciezkiBox1.Enabled = true;
            PCancel.Enabled = true;
            PSaveButton.Enabled = true;
        }

        private void PZablokuj()
        {
            PNazwaBox1.Enabled = false;
            PGatunekBox1.Enabled = false;
            PZespolBox1.Enabled = false;
            PRokBox1.Enabled = false;
            PSciezkiBox1.Enabled = false;
            PCancel.Enabled = false;
            PSaveButton.Enabled = false;
        }

        private void PWyczysc()
        {
            PNazwaBox1.Text = "";
            PGatunekBox1.Text = "";
            PZespolBox1.Text = "";
            PRokBox1.Text = "";
            PSciezkiBox1.Text = "";
        }

        private void PCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wyświetl zaznaczony item z litView; na koniec zablokuje pola powyżej");
            this.PZablokuj();
            PEditButton.Enabled = true;
            PNewButton.Enabled = true;
        }

        private void ZPlytyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dodać komunikat, gdy nie  jest wybrany zespół");
            PanelTabControl.SelectedTab = TabPlyty;
        }


    }
}
