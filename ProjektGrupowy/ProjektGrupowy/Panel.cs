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
    public partial class Panel : Form
    {
/*############################ OGOLNE #################################################################################################################*/   
        // OGOLNE
        public static int ID_Selected_MPlyta = 0;
        public static int ID_Selected_Zespol = 0;
        public static int ID_Selected_Plyta = 0;
        public string NickData, ImieData, NazwiskoData, KrajData, MiastoData, MailData, StatusData;
        public DateTime Data_ur;
        public int PlecData;

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

        /*public SqlCommand Connect1(TypeOfAction TOA, string Query)  // Inny sposob na auto połączenie z bazą - zwracający SqlCommand zamiast SqlDataReader (wg. mnie gorszy sposob dlatego nie uzywam i komentuje, ale może kiedyś się przydać(brak mozliwosci uzycia SqlDataReader-a) , więc nie usuwam.
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

/*############################ KONIEC OGOLNE ##########################################################################################################*/

/*############################ 1 ZAKLADKA (Moje Oceny) ################################################################################################*/
        // 1 ZAKLADKA (Moje Oceny)
        private void DaneSave_Click(object sender, EventArgs e)
        {
            if (ImieBox.Text == ImieData &&
                NazwiskoBox.Text == NazwiskoData &&
                DataBox.Value == Data_ur &&
                PlecBox.SelectedIndex == (PlecData - 1) &&
                MailBox.Text == MailData &&
                KrajBox.Text == KrajData &&
                MiastoBox.Text == MiastoData)
            {
                MessageBox.Show("Nie wprowadzono żadnych zmian, nic nie zaaktualizowano.");
            }
            else
            {
                string UpdateUser = "update Users " +
                                        "set " +
                                        "Imie = '" + ImieBox.Text +
                                        "', Nazwisko = '" + NazwiskoBox.Text +
                                        "', Data_urodzenia = '" + DataBox.Text +
                                        "', ID_plec = '" + (PlecBox.SelectedIndex + 1) +
                                        "', Mail = '" + MailBox.Text +
                                        "', Kraj = '" + KrajBox.Text +
                                        "', Miasto = '" + MiastoBox.Text + "' " +
                                        "where Users.ID_user = " + Program.ID_zalogowanego;

                SqlDataReader Data = Connect(TypeOfAction.Update, UpdateUser);
                Dane_uzytkownika_Show();
                MessageBox.Show("Dane zaaktualizowane");
            }
        }

        private void OcenaSave_Click(object sender, EventArgs e)
        {                        
            string UpdateOcena =
                "update Ocena " +
                "set Ocena = " + OcenaBox.Text +
                "where Ocena.ID_plyta = " + ID_Selected_MPlyta + " and Ocena.ID_user = " + Program.ID_zalogowanego;
            SqlDataReader Data = Connect(TypeOfAction.Update, UpdateOcena);
            MessageBox.Show("Zmiana oceny powiodła się");
            
            MOcenyList.Items.Clear();
            this.Plyty_uzytkownika_Show();
        }

        private void MOcenyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Do dodania funkcja która przeniesie zaznaczony rekord do pól po prawej");
            if (MOcenyList.SelectedItems.Count != 0)
            {
                OcenaBox.Enabled = true;
                OcenaSave.Enabled = true;
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

        public void Dane_uzytkownika_Show()
        {
            //string Nick, Imie, Nazwisko, Kraj, Miasto, Mail, Status;
            //DateTime Data_ur;
            //int Plec;
            int ID = Program.ID_zalogowanego;
            string GetDane_user =
                "SELECT Users.Nick, Users.Imie, Users.Nazwisko, Users.Kraj, Users.Miasto, Users.Mail, Status.Nazwa, Users.Data_urodzenia, Users.Id_plec " +
                "FROM Users INNER JOIN Status on Status.ID_status = Users.ID_status " +
                "WHERE Users.ID_user = " + ID;

            SqlDataReader Data = Connect(TypeOfAction.Select, GetDane_user);

            Data.Read();
            NickData = Data.GetString(0);
            ImieData = Data.GetString(1);
            if (Data.IsDBNull(2))
            {
                Nazwisko = null;
            }
            else { NazwiskoData = Data.GetString(2); ; }
            if (Data.IsDBNull(3))
            {
                Kraj = null;
            }
            else { KrajData = Data.GetString(3); }
            if (Data.IsDBNull(4))
            {
                Miasto = null;
            }
            else { MiastoData = Data.GetString(4); }
            MailData = Data.GetString(5);
            StatusData = Data.GetString(6);

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
            PlecData = Data.GetInt32(8);

            NickBox.Text = NickData;
            ImieBox.Text = ImieData;
            NazwiskoBox.Text = NazwiskoData;
            KrajBox.Text = KrajData;
            MiastoBox.Text = MiastoData;
            MailBox.Text = MailData;
            StatusBox.Text = StatusData;
            PlecBox.SelectedIndex = PlecData - 1;

            Data.Close();
        }

        public void Plyty_uzytkownika_Show()
        {
            int ID = Program.ID_zalogowanego;

            string Plyta, Zespol, Gatunek;
            int Rok, Sciezki, Ocena, ID_Plyta;

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

                MOcenyList.Items.Add(new ListViewItem(new[] { ID_Plyta.ToString(), Plyta, Zespol, Gatunek, Rok.ToString(), Sciezki.ToString(), Ocena.ToString() }));
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

        private void TabMojeOceny_Enter(object sender, EventArgs e)
        {
            MOcenyList.Items.Clear();
            Plyty_uzytkownika_Show();
        }

/*############################ KONIEC  1 ZAKLADKA (Moje Oceny) ########################################################################################*/

/*############################ 2 ZAKLADKA (Zespoly) ###################################################################################################*/
        // 2 ZAKLADKA (Zespoly)
        private void ZSzukaj_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Do dodania funkcja która zapełni wynikami wyszukiwania listę po prawej, i wyświetli w grupie zespół pierwszy item z listy");
            string ZespolV, GatunekV;
            int ZespolID, RokStV, CountV;
            int? RokEndV;
            
            string Nazwa = ZNazwaBox.Text;
            string Gatunek = ZGatunekBox.Text;
            string RokSt = ZRokStBox.Text;
            string RokEnd = ZRokEndBox.Text;
            string RokStOption = RokStGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            string RokEndOption = RokEndGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            string warunek = "";
            int Warunki_sum = 0;

            int[] Warunki = new int[4];
            Warunki[0] = If_Checked(ZNazwaCheck, ZNazwaBox);
            Warunki[1] = If_Checked(ZGatunekCheck, ZGatunekBox);
            Warunki[2] = If_Checked(ZRokStCheck, ZRokStBox);
            Warunki[3] = If_Checked(ZRokEndCheck, ZRokEndBox);
            Warunki_sum = Warunki[0] + Warunki[1] + Warunki[2] + Warunki[3];

            string[] Warunki_String = new string[4];
            Warunki_String[0] = "Zespol.Nazwa like '%" + Nazwa + "%' ";
            Warunki_String[1] = "Gatunek.Nazwa = '" + Gatunek + "' ";
            Warunki_String[2] = "Zespol.Rok_Start " + RokStOption +" " + RokSt + " ";
            Warunki_String[3] = "Zespol.Rok_End " + RokEndOption + " " + RokEnd + " ";

            bool Warunki_ok = false;
            if ((Warunki_sum) > 0)
            {
                Warunki_ok = true;
            }

            

            if (Warunki_ok)
            {
                ZespolyList.Items.Clear();
                ZWyczysc();
                ZPlytyButton.Enabled = false;
                ID_Selected_Zespol = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (Warunki[i] == 1)
                    {
                        warunek = warunek + Warunki_String[i];
                        Warunki_sum += -1;
                    }
                    if (Warunki_sum != 0 & Warunki[i] == 1)
                    {
                        warunek = warunek + "and ";
                    }
                }
                string GetZespoly = "select Zespol.ID_zespol, Zespol.Nazwa, Gatunek.Nazwa, Zespol.Rok_start, Zespol.Rok_end " +
                                    "from dbo.Zespol " +
                                    "inner join Gatunek on Gatunek.Id_gatunek = Zespol.Id_Gatunek " +
                                    "where " + warunek;

                SqlDataReader Data = Connect(TypeOfAction.Select, GetZespoly);

                while (Data.Read())
                {
                    ZespolID = Data.GetInt32(0);
                    ZespolV = Data.GetString(1);
                    GatunekV = Data.GetString(2);
                    RokStV = Data.GetInt32(3);
                    if (Data.IsDBNull(4))
                        RokEndV = 0;
                    else
                        RokEndV = Data.GetInt32(4);

                    string GetCountPlyty = "select COUNT(*) from Plyta " +
                                       "where Plyta.ID_zespol = " + ZespolID +
                                       "group by Plyta.ID_zespol";
                    SqlDataReader Data1 = Connect(TypeOfAction.Select, GetCountPlyty);
                    Data1.Read();
                    CountV = Data1.GetInt32(0);
                    Data1.Close();

                    ZespolyList.Items.Add(new ListViewItem(new[] { ZespolID.ToString(), ZespolV, GatunekV, RokStV.ToString(), RokEndV.ToString(), CountV.ToString() }));
                }
                Data.Close();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnego warunku wyszukiwania lub pola pozostały puste");
            }
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
            //MessageBox.Show("Jeśli ilość płyt jest >0 to przeniesie do zakładki płyty, i tam wyświetli wszystkie płyty");
            if (ZespolyList.SelectedItems.Count != 0)
            {
                ZPlytyButton.Enabled = true;
                ZNazwaBox1.Text = ZespolyList.SelectedItems[0].SubItems[1].Text;
                ZGatunekBox1.Text = ZespolyList.SelectedItems[0].SubItems[2].Text;
                ZRokStBox1.Text = ZespolyList.SelectedItems[0].SubItems[3].Text;
                ZRokEndBox1.Text = ZespolyList.SelectedItems[0].SubItems[4].Text;
                ID_Selected_Zespol = Int32.Parse(ZespolyList.SelectedItems[0].SubItems[0].Text);
            }
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

        private void ZCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wyświetl zaznaczony item z litView; na koniec zablokuje pola powyżej");
            this.ZZablokuj();
            ZEditButton.Enabled = true;
            ZNewButton.Enabled = true;
        }

        private void ZPlytyButton_Click(object sender, EventArgs e)
        {
            double Avg;
            if (ID_Selected_Zespol != 0)
            {
                Plyty_SzukajClear();
                PanelTabControl.SelectedTab = TabPlyty;
                ID_Selected_Plyta = 0;
                POcenaBox.Enabled = false;
                POcenaDodaj.Enabled = false;
                PlytyList.Items.Clear();
                string GetPlyty = " select Plyta.ID_Plyta, Plyta.Nazwa, Gatunek.Nazwa, Zespol.Nazwa, Plyta.Rok_wydania, Plyta.Ilosc_Sciezek " +
                    "from dbo.Plyta " +
                    "inner join Gatunek on Gatunek.Id_gatunek = Plyta.Id_Gatunek " +
                    "inner join Zespol on Zespol.Id_zespol = Plyta.Id_zespol " +
                    "where Plyta.Id_zespol = " + ID_Selected_Zespol;

                SqlDataReader Data = Connect(TypeOfAction.Select, GetPlyty);

                while (Data.Read())
                {
                    string GetAvgPlyta = "select AVG(cast((Ocena.Ocena)as decimal(2,0))) from Ocena " +
                                       "where Ocena.ID_plyta = " + Data.GetInt32(0) + " " +
                                       "group by Ocena.ID_plyta";
                    SqlDataReader Data1 = Connect(TypeOfAction.Select, GetAvgPlyta);
                    Data1.Read();
                    if (Data1.IsDBNull(0))
                    {
                        Avg = 0.0;
                    }
                    else
                    {
                        Avg = (double)Data1.GetDecimal(0);
                    }
                    Data1.Close();
                    PlytyList.Items.Add(new ListViewItem(new[] { Data.GetInt32(0).ToString(), Data.GetString(1), Data.GetString(2), Data.GetString(3), Data.GetInt32(4).ToString(), Data.GetInt32(5).ToString(), Avg.ToString() }));

                }
                Data.Close();

            }
            else
            {
                MessageBox.Show("Wybierz zespół");
            }
        }

        private void Plyty_SzukajClear()
        {
            PNazwaBox.Text = "";
            PNazwaCheck.Checked = false;
            PGatunekBox.Text = "";
            PGatunekCheck.Checked = false;
            PZespolBox.Text = "";
            PZespolCheck.Checked = false;
            PRokBox.Text = "";
            PRokCheck.Checked = false;
            RadioRok3.Checked = true;
        }

        private void TabZespoly_Enter(object sender, EventArgs e) // Uzupełnienie ComboBoxów
        {
            DropDownItems_Gatunek(ZGatunekBox);
            DropDownItems_Gatunek(ZGatunekBox1);
            DropDownItems_Rok(ZRokEndBox);
            DropDownItems_Rok(ZRokStBox);
            DropDownItems_Rok(ZRokEndBox1);
            DropDownItems_Rok(ZRokStBox1);
        } // 2 ZAKLADKA (Zespoly)

/*############################ KONIEC  2 ZAKLADKA (Zespoly) ###########################################################################################*/

/*############################ 3 ZAKLADKA (Plyty) #####################################################################################################*/
        // 3 ZAKLADKA (Plyty)
        private void PSzukaj_Click(object sender, EventArgs e)
        {
            string NazwaV, ZespolV, GatunekV;
            int PlytaID, RokV, SciezkiV;
            double AvgV;
            string Nazwa = PNazwaBox.Text;
            string Gatunek = PGatunekBox.Text;
            string Zespol = PZespolBox.Text;
            string Rok = PRokBox.Text;           
            string RokOption = PRokGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;

            string warunek = "";
            int Warunki_sum = 0;

            int[] Warunki = new int[4];
            Warunki[0] = If_Checked(PNazwaCheck, PNazwaBox);
            Warunki[1] = If_Checked(PGatunekCheck, PGatunekBox);
            Warunki[2] = If_Checked(PZespolCheck, PZespolBox);
            Warunki[3] = If_Checked(PRokCheck, PRokBox);
            Warunki_sum = Warunki[0] + Warunki[1] + Warunki[2] + Warunki[3];

            string[] Warunki_String = new string[4];
            Warunki_String[0] = "Plyta.Nazwa like '%" + Nazwa + "%' ";
            Warunki_String[1] = "Gatunek.Nazwa = '" + Gatunek + "' ";
            Warunki_String[2] = "Zespol.Nazwa like '%" + Zespol + "%' ";
            Warunki_String[3] = "Plyta.Rok_wydania " + RokOption + " " + Rok + " ";

            bool Warunki_ok = false;
            if ((Warunki_sum) > 0)
            {
                Warunki_ok = true;
            }

            

            if (Warunki_ok)
            {
                PlytyList.Items.Clear();
                PWyczysc();
                ID_Selected_Plyta = 0;
                POcenaBox.Enabled = false;
                POcenaDodaj.Enabled = false;

                for (int i = 0; i < 4; i++)
                {
                    if (Warunki[i] == 1)
                    {
                        warunek = warunek + Warunki_String[i];
                        Warunki_sum += -1;
                    }
                    if (Warunki_sum != 0 & Warunki[i] == 1)
                    {
                        warunek = warunek + "and ";
                    }
                }
                string GetPlyty = " select Plyta.ID_Plyta, Plyta.Nazwa, Gatunek.Nazwa, Zespol.Nazwa, Plyta.Rok_wydania, Plyta.Ilosc_Sciezek " +
                                    "from dbo.Plyta " +
                                    "inner join Gatunek on Gatunek.Id_gatunek = Plyta.Id_Gatunek " +
                                    "inner join Zespol on Zespol.Id_zespol = Plyta.Id_zespol " +
                                    "where " + warunek;

                SqlDataReader Data = Connect(TypeOfAction.Select, GetPlyty);

                while (Data.Read())
                {
                    PlytaID = Data.GetInt32(0);
                    NazwaV = Data.GetString(1);
                    GatunekV = Data.GetString(2);
                    ZespolV = Data.GetString(3);
                    RokV = Data.GetInt32(4);
                    SciezkiV = Data.GetInt32(5);

                    string GetAvgPlyta = "select AVG(cast((Ocena)as decimal(2,0))) from Ocena " +
                                       "where Ocena.ID_plyta = " + PlytaID + " "+
                                       "group by Ocena.ID_plyta";                   // poprawic zapytanie zeby AVG nie zwracało int
                    SqlDataReader Data1 = Connect(TypeOfAction.Select, GetAvgPlyta);
                    Data1.Read();
                    if(Data1.IsDBNull(0))
                    {
                        AvgV = 0.0;
                    }
                    else
                    {
                        AvgV = (double) Data1.GetDecimal(0);
                    }

                    Data1.Close();

                    PlytyList.Items.Add(new ListViewItem(new[] { PlytaID.ToString(), NazwaV, GatunekV, ZespolV, RokV.ToString(), SciezkiV.ToString(), AvgV.ToString() }));
                }
                Data.Close();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnego warunku wyszukiwania lub pola pozostały puste");
            }         
        }

        private void POcenaDodaj_Click(object sender, EventArgs e)
        {
            if (POcenaBox.Text != "0")
            {
                if (CzyPlytaOceniona())
                {
                    string UpdateOcena =
                    "update Ocena " +
                    "set Ocena = " + POcenaBox.Text +
                    "where Ocena.ID_plyta = " + ID_Selected_Plyta + " and Ocena.ID_user = " + Program.ID_zalogowanego;

                    SqlDataReader Data = Connect(TypeOfAction.Update, UpdateOcena);
                }
                else
                {
                    string InsertOcena =
                    "insert into Ocena values (" + ID_Selected_Plyta + ", " + Program.ID_zalogowanego + ", " + Int32.Parse(POcenaBox.Text) + ", '')";
                    SqlDataReader Data = Connect(TypeOfAction.Update, InsertOcena);
                }
                MessageBox.Show("Zapis zakończony sukcesem");
            }
            else
            {
                MessageBox.Show("Zapis nie powiódł się");
            }

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

        private bool CzyPlytaOceniona()
        {
            bool b = false;
            string GetOcena = "SELECT Ocena FROM Ocena WHERE ID_Plyta = " + ID_Selected_Plyta + "and ID_user = " + Program.ID_zalogowanego;
            SqlDataReader Data = Connect(TypeOfAction.Select, GetOcena);
            Data.Read();
            if (Data.HasRows)
            {
                b = true;
            }
            Data.Close();
            return b;
        }

        private void PlytyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlytyList.SelectedItems.Count != 0)
            {
                POcenaDodaj.Enabled = true;
                POcenaBox.Enabled = true;
                PNazwaBox1.Text = PlytyList.SelectedItems[0].SubItems[1].Text;
                PGatunekBox1.Text = PlytyList.SelectedItems[0].SubItems[2].Text;
                PZespolBox1.Text = PlytyList.SelectedItems[0].SubItems[3].Text;
                PRokBox1.Text = PlytyList.SelectedItems[0].SubItems[4].Text;
                PSciezkiBox1.Text = PlytyList.SelectedItems[0].SubItems[5].Text;
                ID_Selected_Plyta = Int32.Parse(PlytyList.SelectedItems[0].SubItems[0].Text);

                string GetOcena = "SELECT Ocena FROM Ocena WHERE ID_Plyta = " + ID_Selected_Plyta + "and ID_user = " + Program.ID_zalogowanego;
                SqlDataReader Data = Connect(TypeOfAction.Select, GetOcena);
                Data.Read();
                if (!Data.HasRows)
                {
                    POcenaBox.Text = "0";
                }
                else
                {
                    POcenaBox.Text = Data.GetInt32(0).ToString();
                }
                Data.Close();
            }
        }

        private void TabPlyty_Enter(object sender, EventArgs e)
        {
            DropDownItems_Gatunek(PGatunekBox);
            DropDownItems_Gatunek(PGatunekBox1);
            DropDownItems_Rok(PRokBox);
            DropDownItems_Rok(PRokBox1);
            DropDownItems_Sciezki(PSciezkiBox1);
            DropDownItems_Zespol(PZespolBox1);
        }

/*############################ KONIEC  3 ZAKLADKA (Plyty) #############################################################################################*/

/*############################ WSPOLNE ################################################################################################################*/
        // WSPOLNE
        private void Panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Start1.Show();
        }

        private void DropDownItems_Gatunek(ComboBox CB) // Pobiera gatunki jako itemy do ComboBoxow
        {
            string GetGatunki = "SELECT Nazwa FROM Gatunek";
            SqlDataReader Data = Connect(TypeOfAction.Select, GetGatunki);
            while (Data.Read())
            {
                CB.Items.Add(Data.GetString(0));
            }
            Data.Close();
        }

        private void DropDownItems_Rok(ComboBox CB) // Rok jako item do ComboBoxow
        {
            for (int i = 1900; i<= DateTime.Now.Year; i++)
            {
                CB.Items.Add(i);
            }
        }

        private void DropDownItems_Sciezki(ComboBox CB)
        {
            for (int i = 1; i <= 50; i++)
            {
                CB.Items.Add(i);
            }
        }

        private void DropDownItems_Zespol(ComboBox CB) 
        {
            string GetZespol = "SELECT Nazwa FROM Zespol ORDER BY Nazwa desc";
            SqlDataReader Data = Connect(TypeOfAction.Select, GetZespol);
            while (Data.Read())
            {
                CB.Items.Add(Data.GetString(0));
            }
            Data.Close();
        }

        private int If_Checked(CheckBox CB, Control CT)
        {
            if (CB.Checked == true & CT.Text!="")
                return 1;
            else
                return 0;
        }

/*############################ KONIEC  WSPOLNE ########################################################################################################*/
    }
}
