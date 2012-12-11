﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjektGrupowy
{
    public partial class Panel : Form
    {
        public static int ID_Selected_MPlyta = 0;

        public Panel()
        {
            InitializeComponent();
        }

        public Panel(bool parametr)
        {
            InitializeComponent();
        }

        public enum TypeOfAction
        {
            Select,
            Update,
            Count
        };

        public SqlDataReader Connect(TypeOfAction TOA, string Query) // Funcka otwierajaca polaczenie i w zależności od pożadanej akcji wykonuje różny kod.
        {
            string ConnectionString = "Server=ProjektGrupowy.mssql.somee.com; Database=ProjektGrupowy; User ID=derri_SQLLogin_1; Password=pe2fjz4yh9;";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();

            SqlDataReader Data;

            if (TOA == TypeOfAction.Update)// Przy update nie zamykać SqlDataReadera!(w uzywanej funkcji) bo jego wartosc == null!!!
            {
                SqlCommand DataCmd = new SqlCommand(Query, Conn);
                DataCmd.ExecuteNonQuery();
                Conn.Close();
            }

            if (TOA == TypeOfAction.Select)
            {
                SqlCommand DataCmd = new SqlCommand(Query, Conn);
                Data = DataCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return Data;
            }
            return null;
        }

        // Inny sposob na auto połączenie z bazą - zwracający SqlCommand zamiast SqlDataReader (wg. mnie gorszy sposob dlatego nie uzywam i komentuje, ale może kiedyś się przydać(brak mozliwosci uzycia SqlDataReader-a) , więc nie usuwam.
        /*public SqlCommand Connect1(TypeOfAction TOA, string Query)
        {
            string ConnectionString = "Server=ProjektGrupowy.mssql.somee.com; Database=ProjektGrupowy; User ID=derri_SQLLogin_1; Password=pe2fjz4yh9;";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();


            SqlCommand DataCmd = null;

            if (TOA == TypeOfAction.Update)// Przy update nie zamykać SqlDataReadera! bo jego wartosc == null!!!
            {
                DataCmd = new SqlCommand(Query, Conn);
            }

            if (TOA == TypeOfAction.Select)
            {
                DataCmd = new SqlCommand(Query, Conn);
            }

            if (TOA == TypeOfAction.Count)
            {
                DataCmd = new SqlCommand(Query, Conn);
            }

            return DataCmd;
        }*/

        private void DaneSave_Click(object sender, EventArgs e)
        {
            string UpdateUser =    "update Users " +
                                    "set " + 
                                    "Imie = '" + ImieBox.Text +
                                    "', Nazwisko = '" + NazwiskoBox.Text +
                                    "', Data_urodzenia = '" + DataBox.Text  +
                                    "', ID_plec = '" + (PlecBox.SelectedIndex+1) +
                                    "', Mail = '" + MailBox.Text +
                                    "', Kraj = '" + KrajBox.Text +
                                    "', Miasto = '" + MiastoBox.Text + "' " + 
                                    "where Users.ID_user = " + Program.ID_zalogowanego;

            SqlDataReader Data = Connect(TypeOfAction.Update, UpdateUser);
            MessageBox.Show("Dane zaaktualizowane");
        }

        private void OcenaSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Do dodania funkcja robiąca update w tabeli z ocenami");
            //int ocena = Int32.Parse(OcenaBox.Text);

            string UpdateOcena =
                "update Ocena " +
                "set Ocena = " + OcenaBox.Text + //+ ocena + //!!! DLA KUBY!!!Nie musisz "przerabiac oceny z txt w textbox na int, bo do zapytania i tak tylko txt idzie :)/
                "where Ocena.ID_plyta = " + ID_Selected_MPlyta +" and Ocena.ID_user = " + Program.ID_zalogowanego;

            SqlDataReader Data = Connect(TypeOfAction.Update, UpdateOcena);

            MOcenyList.Items.Clear();
            this.Plyty_uzytkownika_Show();
        }

        private void MOcenyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Do dodania funkcja która przeniesie zaznaczony rekord do pól po prawej");
            if (MOcenyList.SelectedItems.Count != 0)
            {
                PlytaBox.Text = MOcenyList.SelectedItems[0].SubItems[1].Text;
                ZespolBox.Text = MOcenyList.SelectedItems[0].SubItems[2].Text;
                GatunekBox.Text = MOcenyList.SelectedItems[0].SubItems[3].Text;
                RokBox.Text = MOcenyList.SelectedItems[0].SubItems[4].Text;
                SciezkiBox.Text = MOcenyList.SelectedItems[0].SubItems[5].Text;
                OcenaBox.Text = MOcenyList.SelectedItems[0].SubItems[6].Text;
                ID_Selected_MPlyta = Int32.Parse(MOcenyList.SelectedItems[0].SubItems[0].Text);
            }
            //MessageBox.Show(ID_Selected_MPlyta.ToString());
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

        public void Dane_uzytkownika_Show()
        {
            string Nick, Imie, Nazwisko, Kraj, Miasto, Mail, Status;
            DateTime Data_ur;
            int Plec;
            int ID = Program.ID_zalogowanego;
            string GetDane_user= 
                "SELECT Users.Nick, Users.Imie, Users.Nazwisko, Users.Kraj, Users.Miasto, Users.Mail, Status.Nazwa, Users.Data_urodzenia, Users.Id_plec " +
                "FROM Users INNER JOIN Status on Status.ID_status = Users.ID_status " +
                "WHERE Users.ID_user = " + ID;

            SqlDataReader Data = Connect(TypeOfAction.Select, GetDane_user);

            Data.Read();
            Nick = Data.GetString(0);
            Imie = Data.GetString(1);
            if (Data.IsDBNull(2))
            {
                Nazwisko = null;
            }
            else { Nazwisko = Data.GetString(2); ; }
            if (Data.IsDBNull(3))
            {
                Kraj = null;
            }
            else { Kraj = Data.GetString(3); }
            if (Data.IsDBNull(4))
            {
                Miasto = null;
            }
            else { Miasto = Data.GetString(4); }
            Mail = Data.GetString(5);
            Status = Data.GetString(6);

            if (Data.IsDBNull(7))
            {
                DataBox.Checked = false;
                DataBox.Format = DateTimePickerFormat.Custom;
                DataBox.CustomFormat = " ";
            }
            else 
            {
                Data_ur = Data.GetDateTime(7);
                DataBox.Value = Data_ur;
            }
            Plec = Data.GetInt32(8);

            NickBox.Text = Nick;
            ImieBox.Text = Imie;
            NazwiskoBox.Text = Nazwisko;
            KrajBox.Text = Kraj;
            MiastoBox.Text = Miasto;
            MailBox.Text = Mail;
            StatusBox.Text = Status;
            PlecBox.SelectedIndex = Plec - 1;

            Data.Close();
        }

        public void Plyty_uzytkownika_Show()
        {
            int ID = Program.ID_zalogowanego;

            string Plyta, Zespol, Gatunek;
            int  Rok, Sciezki, Ocena, ID_Plyta;

            string GetDane_plyty =
                "Select Plyta.Nazwa, Zespol.Nazwa, Gatunek.Nazwa, Plyta.Rok_wydania, Plyta.Ilosc_sciezek, Ocena.Ocena, Ocena.ID_plyta " +
                "from Ocena " +
                "inner join Plyta on Plyta.ID_plyta = Ocena.ID_plyta " +
                "inner join Zespol on Zespol.ID_zespol = Plyta.ID_zespol " +
                "inner join Gatunek on Gatunek.ID_gatunek = Plyta.ID_gatunek " +
                "where Ocena.ID_user = " + ID;

            SqlDataReader Data = Connect(TypeOfAction.Select, GetDane_plyty);

            while (Data.Read())
            {
                Plyta = Data.GetString(0);
                Zespol = Data.GetString(1);
                Gatunek = Data.GetString(2);
                Rok = Data.GetInt32(3);
                Sciezki = Data.GetInt32(4);
                Ocena = Data.GetInt32(5);
                ID_Plyta = Data.GetInt32(6);

                MOcenyList.Items.Add(new ListViewItem(new[] { ID_Plyta.ToString(), Plyta, Zespol, Gatunek, Rok.ToString(), Sciezki.ToString(), Ocena.ToString()}));
            }
            Data.Close();
        }

        private void DataBox_ValueChanged(object sender, EventArgs e)
        {
            if (DataBox.Checked == true)
            {
                DataBox.Format = DateTimePickerFormat.Short;
            }

            else
            {
                DataBox.Format = DateTimePickerFormat.Custom;
                DataBox.CustomFormat = " ";
            }
        }




    }
}
