using System;
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

        public int DaneLogowania() //Działa z oficjalną bazą (konstrukcją bazy), ale adres bazy i jej nazwa to wartości lokalne.
        {
            int ID, IleRek = 1;
            string IleRekordow = "SELECT COUNT (*) " +
                                "FROM Users INNER JOIN User_password ON Users.ID_user = User_password.ID_user " +
                                "WHERE Users.Nick = '" + LoginBox.Text + "'" +
                                "AND User_password.Password = '" + HasloBox.Text + "'";

            string CheckUser =  "SELECT Users.ID_user " + 
                                "FROM Users INNER JOIN User_password ON Users.ID_user = User_password.ID_user " +
                                "WHERE Users.Nick = '" + LoginBox.Text + "'" +
                                "AND User_password.Password = '" + HasloBox.Text + "'";

            Panel Panel = new Panel();
            SqlDataReader DataUser = Panel.Connect(Panel.TypeOfAction.Select, CheckUser);
            SqlDataReader DataIleRek = Panel.Connect(Panel.TypeOfAction.Select, IleRekordow);

            DataIleRek.Read();
            IleRek = DataIleRek.GetInt32(0);
            DataIleRek.Close();
            if (IleRek == 1 && DataUser.Read())
            {
                ID = DataUser.GetInt32(0);
                DataUser.Close();
                return ID;
            }
            else
            {
                DataUser.Close();
                return 0;
            }
            
        }
        /*Inny sposob na logowanie (uboższy bo nie zwraca ID klienta, co nie pozwala rozkminic kto jest zalogowany - wiec nie do wykorzystania, ale narazie niech lezy)
        public bool UserCheck()
        {
            string ConnectionString = "Server=(localdb)\\Projects;Database=Proba;Trusted_Connection=True;";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            CheckUser = "SELECT Id, Imie, Nazwisko " +
                         "FROM Pracownik " +
                         "WHERE Imie = '" + LoginBox.Text + "'" +
                         "AND Nazwisko = '" + HasloBox.Text + "'";

            SqlCommand DataCmd = new SqlCommand(CheckUser, Conn);
            SqlDataReader Data = DataCmd.ExecuteReader();
            if (Data.HasRows)
            {
                Data.Close();
                Conn.Close();
                return true;
            }
            else
            {
                Data.Close();
                Conn.Close();
                return false;

            }


        }
        */
        private void LoginOK_Click(object sender, EventArgs e)
        {
            Program.ID_zalogowanego = DaneLogowania();
            if (Program.ID_zalogowanego != 0)
            {
                Panel Panel = new Panel();
                Panel.Show();
                Panel.Dane_uzytkownika_Show();
                Program.Start1.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("Błędny Login i/lub Hasło");
            }
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

        private void HasloBox_KeyDown(object sender, KeyEventArgs e) // logowanie po wciśnięciu ENTERa
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoginOK_Click((object)sender, (EventArgs)e);
            }
        }

    }
}
