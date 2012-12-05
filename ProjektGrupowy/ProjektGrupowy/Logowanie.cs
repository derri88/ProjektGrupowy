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

        public int DaneLogowania() //Z powodu braku oficjalnej bazy, zrobiłem bazę o nazwie probra, gdzie za login sluzy imie a za hasło nazwisko.
        {
            int ID, count;
            string Imie, Nazwisko;
            string ConnectionString = "Server=(localdb)\\Projects;Database=Proba;Trusted_Connection=True;";
            string IleRekordow = "SELECT COUNT(*) " +
                                    "FROM Pracownik " +
                                    "WHERE Imie = '" + LoginBox.Text + "'" +
                                    "AND Nazwisko = '" + HasloBox.Text + "'";

            string CheckUser = "SELECT Id, Imie, Nazwisko " +
                                    "FROM Pracownik " +
                                    "WHERE Imie = '" + LoginBox.Text + "'" +
                                    "AND Nazwisko = '" + HasloBox.Text + "'";

            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            SqlCommand DataCmd = new SqlCommand(CheckUser, Conn);
            SqlCommand IleRek = new SqlCommand(IleRekordow, Conn);

            count = (Int32)IleRek.ExecuteScalar(); //Spradzam czy zapytanie zwraca 1 rekord (login i hasło muszą byc unikalne! Więc zaptanie musi zwracać jeden rekord)

            SqlDataReader Data = DataCmd.ExecuteReader();
            if (count == 1 && Data.Read())
            {
                Imie = Data[1].ToString();
                Nazwisko = Data[2].ToString();
                ID = Data.GetInt32(0);
                return ID;
            }
            else return 0;
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
            if (DaneLogowania() != 0)
            {
                Panel Panel = new Panel();
                Panel.Show();
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

    }
}
