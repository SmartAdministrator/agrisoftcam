using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;


namespace kiwi.Pages
{
    public partial class Simulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime effectiveDate;
            if (Request.QueryString["currentDate"] != null)
            {
                /*int month = Convert.ToInt32(Request.QueryString["month"]);
                int year = Convert.ToInt32(Request.QueryString["year"]);
                effectiveDate = new DateTime(year, month, 1);*/
                effectiveDate = Convert.ToDateTime(Request.QueryString["currentDate"]);
            }
            else 
            {
                effectiveDate = DateTime.Now;
            }
            HiddenCurrentDate.Value = effectiveDate.ToShortDateString();
            launch_process();

            if (Request.QueryString["view"] == "jour")
            {
                idCalendarDay.Visible = true;
                HiddenView.Value = "jour";
                IdCalendarMonthSecond.Visible = false;
                calendarDayView(effectiveDate);
            }
            else
            {
                idCalendarDay.Visible = false;
                HiddenView.Value = "mois";
                IdCalendarMonthSecond.Visible = true;
                calendarMonthView(effectiveDate);
            }
        }

        protected void previous_month(object sender, EventArgs e)
        {
            DateTime CurrentDate = (Convert.ToDateTime(HiddenCurrentDate.Value)).AddMonths(-1);
            Response.Redirect("Simulation.aspx?currentDate=" + CurrentDate.ToShortDateString() + "&view=mois");
        }

        protected void next_month(object sender, EventArgs e)
        {
            DateTime CurrentDate = (Convert.ToDateTime(HiddenCurrentDate.Value)).AddMonths(1);
            Response.Redirect("Simulation.aspx?currentDate=" + CurrentDate.ToShortDateString() + "&view=mois");
        }

        protected void previous_day(object sender, EventArgs e)
        {
            DateTime CurrentDate = (Convert.ToDateTime(HiddenCurrentDate.Value)).AddDays(-1);
            Response.Redirect("Simulation.aspx?currentDate=" + CurrentDate.ToShortDateString() + "&view=jour");
        }

        protected void next_day(object sender, EventArgs e)
        {
            DateTime CurrentDate = (Convert.ToDateTime(HiddenCurrentDate.Value)).AddDays(1);
            Response.Redirect("Simulation.aspx?currentDate=" + CurrentDate.ToShortDateString() + "&view=jour");
        }

        public class Lapin
        {
            public int id;
            public string nom;
            public string identification;
            public string sexe;
            public int pere;
            public int mere;
            public int fratrie;
            public int cage_naissance;
            public int cage_engraissement;
            public float height;
            public float weight;
            public bool saillie;
            public bool sevrage;
            public bool malade;
            public bool vitalite;
            public bool gestation;
            public bool engraissement;
            public DateTime naissance;
            public DateTime date_sevrage;
            public DateTime date_mort;
            public DateTime date_saillie;
            public DateTime date_checking_grosse;
            public DateTime date_malade;

            public Lapin()
            {
                id = 0;
            }

            public Lapin(int id)
            {
                SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
                Conn.Open();

                SqlCommand fiche_lapin = new SqlCommand("rabbit_informations", Conn);
                fiche_lapin.Parameters.AddWithValue("@idLapin", id);
                SqlDataAdapter da = new SqlDataAdapter();
                fiche_lapin.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = fiche_lapin;

                DataSet results_fiche = new DataSet();
                DataTable table_fiche = new DataTable();
                da.Fill(results_fiche);

                for (int i = 0; i < results_fiche.Tables[0].Rows.Count; i++)
                {
                    //Lapin betail = new Lapin();

                    DataRow dr = results_fiche.Tables[0].Rows[i];
                    id = Convert.ToInt32(dr["id"].ToString());
                    identification = dr["Identification"].ToString();
                    nom = dr["Nom"].ToString();
                    naissance = Convert.ToDateTime(string.IsNullOrEmpty(dr["birthdate"].ToString()) ? null : dr["birthdate"].ToString());
                    date_sevrage = Convert.ToDateTime(string.IsNullOrEmpty(dr["weaningdate"].ToString()) ? null : dr["weaningdate"].ToString());
                    date_saillie = Convert.ToDateTime(string.IsNullOrEmpty(dr["sailliedate"].ToString()) ? null : dr["sailliedate"].ToString());
                    date_malade = Convert.ToDateTime(string.IsNullOrEmpty(dr["illness_date"].ToString()) ? null : dr["illness_date"].ToString());
                    date_checking_grosse = Convert.ToDateTime(string.IsNullOrEmpty(dr["date_mesure_grosse"].ToString()) ? null : dr["date_mesure_grosse"].ToString());
                    date_mort = Convert.ToDateTime(string.IsNullOrEmpty(dr["deathdate"].ToString()) ? null : dr["deathdate"].ToString());
                    cage_naissance = Convert.ToInt32(string.IsNullOrEmpty(dr["birthcage"].ToString()) ? null : dr["birthcage"]);
                    cage_engraissement = Convert.ToInt32(string.IsNullOrEmpty(dr["fattening_cage"].ToString()) ? null : dr["fattening_cage"].ToString());
                    pere = Convert.ToInt32(string.IsNullOrEmpty(dr["father"].ToString()) ? null : dr["father"].ToString());
                    mere = Convert.ToInt32(string.IsNullOrEmpty(dr["mother"].ToString()) ? null : dr["mother"].ToString());
                    fratrie = Convert.ToInt32(string.IsNullOrEmpty(dr["NumFratrie"].ToString()) ? null : dr["NumFratrie"].ToString());
                    sexe = dr["sexe"].ToString().Trim();
                    sevrage = (bool)dr["weaned"];
                    saillie = (bool)dr["saillie"];
                    malade = (bool)dr["malade"];
                    vitalite = (bool)dr["vitalite"];
                    gestation = (bool)dr["gestation"];
                    weight = (float)Convert.ToDecimal(string.IsNullOrEmpty(dr["weight"].ToString()) ? null : dr["weight"].ToString());
                    height = (float)Convert.ToDecimal(string.IsNullOrEmpty(dr["height"].ToString()) ? null : dr["height"].ToString());
                }

            }

            public int get_id()
            {
                return id;
            }

            public string get_identification()
            {
                return identification;
            }
            
        }

        public class Evenement
        {
            public int id_evenement;
            public int id_type_evenement;
            public string type_evenement;
            public Lapin lapin_concerne;
            public Lapin lapin_partenaire;
            public DateTime date_evenement;
            public bool is_future_event;
        }

        public class Parametres
        {
            public int id_parametre;
	        public string label_parametre;
	        public string valeur_parametre;
	        public string mesure_parametre;
            public DateTime date_update;

            private int gestation;
            private int nb_hase_male;
            private int moyenne_portee;
            private int duree_sevrage;
            private int duree_engraissage;
            private int contenance_cage_mere;
            private int contenance_cage_engraissement;
            private float longueur_cage;
            private float largeur_cage;
            private int prix_unitaire;
            private float longueur_batiment;
            private float largeur_batiment;



            public void set_parametres(SqlConnection Conn)
            {

                SqlCommand data_parametres = new SqlCommand("get_parametres", Conn);
                SqlDataAdapter da = new SqlDataAdapter();
                data_parametres.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = data_parametres;

                DataSet results_parametres = new DataSet();
                DataTable table_fiche = new DataTable();

                da.Fill(results_parametres);
                for (int i = 0; i < results_parametres.Tables[0].Rows.Count; i++)
                {
                    string code = results_parametres.Tables[0].Rows[i]["code_parametre"].ToString();
                    string valeur = results_parametres.Tables[0].Rows[i]["valeur_parametre"].ToString();
                    switch (code)
                    {
                        case "duree_gestation" :
                            gestation = Convert.ToInt32(valeur);
                            break;
                        case "femelles_par_male":
                            nb_hase_male = Convert.ToInt32(valeur);
                            break;
                        case "moyenne_portee" :
                            moyenne_portee = Convert.ToInt32(valeur);
                            break;
                        case "duree_sevrage" :
                            duree_sevrage = Convert.ToInt32(valeur);
                            break;
                        case "duree_engraissage":
                            duree_engraissage = Convert.ToInt32(valeur);
                            break;
                        case "cont_cage_engraiss" :
                            contenance_cage_engraissement = Convert.ToInt32(valeur);
                            break;
                        case "cont_cage_mere" :
                            contenance_cage_mere = Convert.ToInt32(valeur);
                            break;
                        case "longueur_cage" :
                            longueur_cage = (float)Convert.ToDecimal(valeur);
                            break;
                        case "largeur_cage" :
                            largeur_cage = (float)Convert.ToDecimal(valeur);
                            break;
                        case "prix_unitaire" :
                            prix_unitaire = Convert.ToInt32(valeur);
                            break;
                        case "longueur_batiment" :
                            longueur_batiment = (float)Convert.ToDecimal(valeur);
                            break;
                        case "largeur_batiment" :
                            largeur_batiment = (float)Convert.ToDecimal(valeur);
                            break;
                    }
                }
            }

            public int get_duree_gestation()
            {
                return gestation;
            }

            public int get_duree_sevrage()
            {
                return duree_sevrage;
            }

            public int get_duree_engraissage()
            {
                return duree_engraissage;
            }

        }

        List<Lapin> clapier = new List<Lapin>();

        public void fillClapier(SqlConnection Conn)
        {
            SqlCommand fiche_lapin = new SqlCommand("rabbit_informations", Conn);
            SqlDataAdapter da = new SqlDataAdapter();
            fiche_lapin.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = fiche_lapin;

            DataSet results_fiche = new DataSet();
            DataTable table_fiche = new DataTable();
            da.Fill(results_fiche);

            clapier.Clear();

            for (int i = 0; i < results_fiche.Tables[0].Rows.Count; i++)
            {
                Lapin betail = new Lapin();

                DataRow dr = results_fiche.Tables[0].Rows[i];
                betail.id = Convert.ToInt32(dr["id"].ToString());
                betail.identification = dr["Identification"].ToString();
                betail.nom = dr["Nom"].ToString();
                betail.naissance = Convert.ToDateTime(string.IsNullOrEmpty(dr["birthdate"].ToString()) ? null : dr["birthdate"].ToString());
                betail.date_sevrage = Convert.ToDateTime(string.IsNullOrEmpty(dr["weaningdate"].ToString()) ? null : dr["weaningdate"].ToString());
                betail.date_saillie = Convert.ToDateTime(string.IsNullOrEmpty(dr["sailliedate"].ToString()) ? null : dr["sailliedate"].ToString());
                betail.date_malade = Convert.ToDateTime(string.IsNullOrEmpty(dr["illness_date"].ToString()) ? null : dr["illness_date"].ToString());
                betail.date_checking_grosse = Convert.ToDateTime(string.IsNullOrEmpty(dr["date_mesure_grosse"].ToString()) ? null : dr["date_mesure_grosse"].ToString());
                betail.date_mort = Convert.ToDateTime(string.IsNullOrEmpty(dr["deathdate"].ToString()) ? null : dr["deathdate"].ToString());
                betail.cage_naissance = Convert.ToInt32(string.IsNullOrEmpty(dr["birthcage"].ToString()) ? null : dr["birthcage"]);
                betail.cage_engraissement = Convert.ToInt32(string.IsNullOrEmpty(dr["fattening_cage"].ToString()) ? null : dr["fattening_cage"].ToString());
                betail.pere = Convert.ToInt32(string.IsNullOrEmpty(dr["father"].ToString()) ? null : dr["father"].ToString());
                betail.mere = Convert.ToInt32(string.IsNullOrEmpty(dr["mother"].ToString()) ? null : dr["mother"].ToString());
                betail.fratrie = Convert.ToInt32(string.IsNullOrEmpty(dr["NumFratrie"].ToString()) ? null : dr["NumFratrie"].ToString());
                betail.sexe = dr["sexe"].ToString().Trim();
                betail.sevrage = (bool)dr["weaned"];
                betail.saillie = (bool)dr["saillie"];
                betail.malade = (bool)dr["malade"];
                betail.vitalite = (bool)dr["vitalite"];
                betail.gestation = (bool)dr["gestation"];
                betail.weight = (float)Convert.ToDecimal(string.IsNullOrEmpty(dr["weight"].ToString()) ? null : dr["weight"].ToString());
                betail.height = (float)Convert.ToDecimal(string.IsNullOrEmpty(dr["height"].ToString()) ? null : dr["height"].ToString());

                clapier.Add(betail);
            }
            idNbTotal.Text = clapier.Count.ToString();

        }

        public List<Lapin> getClapier()
        {
            return clapier;
        }

        Parametres parametres_clapier = new Parametres();
        List<Evenement> previous_events = new List<Evenement>();
        List<Evenement> future_events = new List<Evenement>();

        void fillPreviousEvents(SqlConnection Conn)
        { 
            SqlCommand events_clapier = new SqlCommand("display_lasts_events", Conn);
            SqlDataAdapter da = new SqlDataAdapter();
            events_clapier.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = events_clapier;

            DataSet results_events = new DataSet();
            DataTable table_events = new DataTable();
            da.Fill(results_events);

            previous_events.Clear();

            
            for (int i = 0; i < results_events.Tables[0].Rows.Count; i++)
            {
                Evenement single_event = new Evenement();

                DataRow dr = results_events.Tables[0].Rows[i];

                single_event.id_evenement = Convert.ToInt32(dr["IdEvent"].ToString());
                single_event.id_type_evenement = Convert.ToInt32(dr["IdTypeEvent"].ToString());
                single_event.is_future_event = false;
                single_event.lapin_concerne = clapier.Find(
                                                            delegate(Lapin Lp)
                                                            {
                                                                return Lp.id == Convert.ToInt32(dr["id_lapin"].ToString());
                                                            });

                if(!(string.IsNullOrEmpty(dr["id_partenaire"].ToString())))
                    single_event.lapin_partenaire = clapier.Find(
                                                                delegate(Lapin Lp)
                                                                {
                                                                    return Lp.id == Convert.ToInt32(dr["id_lapin"].ToString());
                                                                });
                        

                single_event.date_evenement = Convert.ToDateTime(string.IsNullOrEmpty(dr["Date_event"].ToString()) ? null : dr["Date_event"].ToString());

                previous_events.Add(single_event);
            }
            //string test = "test";
        }

        void fillEvtNaissances() 
        {
            //Les naissances à venir concernent les hases confirmées engrossées vivantes. le paramètre de la durée de gestation est à utiliser ici.
            for (int i = 0; i < clapier.Count; i++)
            {
                int duree_gestation = parametres_clapier.get_duree_gestation();
                //new Lapin()
                if (clapier[i].gestation && clapier[i].vitalite && clapier[i].sexe == "F")
                {
                    Evenement new_evt = new Evenement();
                    new_evt.date_evenement = clapier[i].date_saillie.AddDays(duree_gestation);
                    new_evt.id_type_evenement = 1; // Naissance
                    new_evt.lapin_concerne = clapier[i];
                    new_evt.type_evenement = "Naissance";
                    new_evt.is_future_event = true;
                    future_events.Add(new_evt);
                }
            }

        }

        void fillEvtSevrages() 
        {
            //les sevrages interviennent pour des lapins nés, vivants, et n'étant pas encore sevré n'ayant pas été engrossés, ni saillies
            for (int i = 0; i < clapier.Count; i++)
            {
                int duree_sevrage = parametres_clapier.get_duree_sevrage();
                if (clapier[i].vitalite && !clapier[i].sevrage)
                {
                    Evenement new_evt = new Evenement();
                    new_evt.date_evenement = clapier[i].naissance.AddDays(duree_sevrage);
                    new_evt.id_type_evenement = 3; // Sevrage
                    new_evt.lapin_concerne = clapier[i];
                    new_evt.type_evenement = "Sevrage";
                    new_evt.is_future_event = true;
                    future_events.Add(new_evt);
                }
            }
        }

        void fillEvtEngraissages() 
        {
            //Les lapins vont en engraissages quand ils sont vivants, sevrés et non en periode d'engrossement.
            for (int i = 0; i < clapier.Count; i++)
            {
                int duree_engraissage = parametres_clapier.get_duree_engraissage();
                if (clapier[i].vitalite && clapier[i].sevrage && !clapier[i].engraissement)
                {
                    Evenement new_evt = new Evenement();
                    new_evt.date_evenement = clapier[i].naissance.AddDays(duree_engraissage);
                    new_evt.id_type_evenement = 14; // Sevrage
                    new_evt.lapin_concerne = clapier[i];
                    new_evt.type_evenement = "Engraissage";
                    new_evt.is_future_event = true;
                    future_events.Add(new_evt);
                }
            }
        }
        
        void fillPretPourVente() 
        {
        
        }

        void launch_process()
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Conn.Open();

            parametres_clapier.set_parametres(Conn);
            fillClapier(Conn);
            fillPreviousEvents(Conn);
            fillEvtNaissances();
            fillEvtSevrages();
            fillEvtEngraissages();
            Lapin test = clapier.Find(
                delegate(Lapin Lp)
                {
                    return Lp.id == 45;
                });
            idLapinSelect.Text = test.id.ToString();
            IdValue.Text = "saillie : " + test.saillie.ToString() + " gestation : " + test.gestation.ToString() +" vitalite : " +test.vitalite.ToString()+ " Sexe : " +test.sexe.ToString()+". future " + future_events.Count.ToString();
            idFuture.Text = "events : " + future_events[0].type_evenement +" "+ future_events[0].date_evenement.ToShortDateString() +" "+ future_events[0].id_type_evenement;
        }

        public int getNbEvents(DateTime date, int idtypeEvent)
        {
            int cpt = 0;
            foreach (var evt in previous_events)
            {
                if (evt.date_evenement.Date.CompareTo(date.Date) == 0 && evt.id_type_evenement == idtypeEvent)
                {
                    cpt++;
                }
            }

            foreach (var evt in future_events)
            {
                if (evt.date_evenement.Date.CompareTo(date.Date) == 0 && evt.id_type_evenement == idtypeEvent)
                {
                    cpt++;
                }
            }
            return cpt;
        }

        public DateTime getPremierJourSemaine(int numeroSemaine, int annee)
        {
            DateTime temp = new DateTime(annee, 1, 1);
            int compteurSemaine = 1;

            //D'abord, on va se caler sur le premier jeudi de l'année
            //Le premier jeudi dans l'année représente la première semaine
            while (temp.DayOfWeek != DayOfWeek.Thursday)
            {
                temp = temp.AddDays(1);
            }

            //Maintenant, on revient sur le lundi précédent
            while (temp.DayOfWeek != DayOfWeek.Monday)
                temp = temp.AddDays(-1);

            //On va avancer de 7 jours en 7 jours pour trouver notre semaine
            while (compteurSemaine < numeroSemaine)
            {
                temp = temp.AddDays(7);
                compteurSemaine++;
            }

            return temp;
        }

        void calendarMonthView(DateTime currentDate) 
        {
            //DateTime currentDate = DateTime.Now;
            int month = currentDate.Month;
            int year = currentDate.Year;
            int nbJours = System.DateTime.DaysInMonth(year,month);
            IdLabelMonth.Text = currentDate.ToString("MMMM").ToUpper() + " " + year.ToString() ;

           
            DateTime firstDayMonth = new DateTime(year, month, 1);
            DateTime lastDayMonth = (firstDayMonth.AddMonths(1)).AddDays(-1);
            CultureInfo myCI = new CultureInfo("en-US");
            //Calendar myCal = myCI.Calendar;
            System.Globalization.Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            int nbFirstWeek = myCal.GetWeekOfYear(firstDayMonth, myCWR, myFirstDOW);
            int nbLastWeek = myCal.GetWeekOfYear(lastDayMonth, myCWR, myFirstDOW);

            string dayOfWeek = currentDate.DayOfWeek.ToString();
            int wk=0;
            for (int i = nbFirstWeek; i < nbLastWeek+1; i++ )
            {
                TableRow rowDate = new TableRow();
                
                for (int j = 0; j<7; j++)
                {
                    TableCell cellule = new TableCell();
                    cellule.Text = (getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j)).Day.ToString();
                    cellule.CssClass = "cell_style_journee";
                    rowDate.Cells.Add(cellule);
                }

                TableRow rowNaissances = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    int nbNaissances = 0;
                    TableCell cellule = new TableCell();
                    HyperLink lien = new HyperLink();
                    DateTime day = (getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j));
                    nbNaissances = getNbEvents(day, 1);
                    cellule.CssClass = "cell_style_vide";
                    if (nbNaissances != 0)
                    {
                        lien.Text = "Naissances : " + nbNaissances.ToString();
                        lien.NavigateUrl = "Simulation.aspx?currentDate=" + getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j).ToShortDateString() + "&view=jour";
                        lien.Style.Add("display", "block");
                        lien.Style.Add("width", "100%");
                        lien.Style.Add("height", "100%");
                        cellule.CssClass = "cell_style_naissance";
                        cellule.Controls.Add(lien);
                    }
                    rowNaissances.Cells.Add(cellule);
                }

                TableRow rowSevrages = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    int nbSevrages = 0;
                    TableCell cellule = new TableCell();
                    HyperLink lien = new HyperLink();
                    DateTime day = (getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j));
                    nbSevrages = getNbEvents(day, 3);
                    cellule.CssClass = "cell_style_vide";
                    if (nbSevrages != 0)
                    {
                        lien.Text = "Sevrages : " + nbSevrages.ToString();
                        lien.NavigateUrl = "Simulation.aspx?currentDate=" + getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j).ToShortDateString() + "&view=jour";
                        lien.Style.Add("display","block");
                        lien.Style.Add("width","100%");
                        lien.Style.Add("height","100%");
                        cellule.CssClass = "cell_style_sevrage";
                        cellule.Controls.Add(lien);
                    }
                    rowSevrages.Cells.Add(cellule);
                }

                TableRow rowEngraissages = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    int nbEngraissages = 0;
                    TableCell cellule = new TableCell();
                    HyperLink lien = new HyperLink();
                    DateTime day = (getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j));
                    nbEngraissages = getNbEvents(day, 14);
                    cellule.CssClass = "cell_style_vide";
                    if (nbEngraissages != 0)
                    {
                        lien.Text = "Engraissages : " + nbEngraissages.ToString();
                        lien.NavigateUrl = "Simulation.aspx?currentDate=" + getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j).ToShortDateString() + "&view=jour";
                        lien.Style.Add("display", "block");
                        lien.Style.Add("width", "100%");
                        lien.Style.Add("height", "100%");
                        cellule.CssClass = "cell_style_engraissage";
                        cellule.Controls.Add(lien);
                    }
                    rowEngraissages.Cells.Add(cellule);
                }

                TableRow rowSaillies = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    int nbSaillies = 0;
                    TableCell cellule = new TableCell();
                    HyperLink lien = new HyperLink();
                    DateTime day = (getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j));
                    nbSaillies = getNbEvents(day, 4);
                    cellule.CssClass = "cell_style_vide";
                    if (nbSaillies != 0)
                    {
                        lien.Text = "Saillies : " + nbSaillies.ToString();
                        lien.NavigateUrl = "Simulation.aspx?currentDate=" + getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j).ToShortDateString() + "&view=jour";
                        lien.Style.Add("display", "block");
                        lien.Style.Add("width", "100%");
                        lien.Style.Add("height", "100%");
                        cellule.CssClass = "cell_style_saillie";
                        cellule.Controls.Add(lien);
                    }
                    rowSaillies.Cells.Add(cellule);
                }

                TableRow rowGrosses = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    int nbGrosses = 0;
                    TableCell cellule = new TableCell();
                    HyperLink lien = new HyperLink();
                    DateTime day = (getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j));
                    nbGrosses = getNbEvents(day, 4);
                    cellule.CssClass = "cell_style_vide";
                    if (nbGrosses != 0)
                    {
                        lien.Text = "Grosses : " + nbGrosses.ToString();
                        lien.NavigateUrl = "Simulation.aspx?currentDate=" + getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j).ToShortDateString() + "&view=jour";
                        lien.Style.Add("display", "block");
                        lien.Style.Add("width", "100%");
                        lien.Style.Add("height", "100%");
                        cellule.CssClass = "cell_style_Grosse";
                        cellule.Controls.Add(lien);
                    }
                    rowGrosses.Cells.Add(cellule);
                }

                TableRow rowAddEvt = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    TableCell cellule = new TableCell();
                    HyperLink lien = new HyperLink();
                    DateTime day = (getPremierJourSemaine(nbFirstWeek, year).AddDays(wk * 7 + j));
                    cellule.CssClass = "cell_style_vide";
                    //if (nbGrosses != 0)
                    //{
                    lien.Text = "+ 1";
                    lien.NavigateUrl = "EventManagement.aspx";
                    lien.Style.Add("display", "block");
                    lien.Style.Add("width", "100%");
                    lien.Style.Add("height", "100%");
                    //cellule.CssClass = "cell_style_Grosse";
                    cellule.Controls.Add(lien);
                    //}
                    rowAddEvt.Cells.Add(cellule);
                }

                TableRow rowVide = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    TableCell cellule = new TableCell();
                    cellule.Height = 10;
                    rowVide.Cells.Add(cellule);
                }
                wk++;
                IdCalendarMonthSecond.Rows.Add(rowDate);
                IdCalendarMonthSecond.Rows.Add(rowNaissances);
                IdCalendarMonthSecond.Rows.Add(rowSevrages);
                IdCalendarMonthSecond.Rows.Add(rowEngraissages);
                IdCalendarMonthSecond.Rows.Add(rowSaillies);
                IdCalendarMonthSecond.Rows.Add(rowGrosses);
                IdCalendarMonthSecond.Rows.Add(rowAddEvt);
                IdCalendarMonthSecond.Rows.Add(rowVide);
            }
        }


        void calendarDayView(DateTime currentDate)
        {
            int maxrows = 1;
            int nbNaissances = getNbEvents(currentDate, 1);
            int nbSevrages = getNbEvents(currentDate, 3);
            int nbEngraissages = getNbEvents(currentDate, 14);
            int nbSaillies = getNbEvents(currentDate, 4);
            int nbGrosses = getNbEvents(currentDate, 7);
            int[] tab = new int[] { nbNaissances, nbSevrages, nbEngraissages, nbSaillies, nbGrosses };
            IdLabelDay.Text = currentDate.ToString("dd MMMM yyyy");
            for (int i = 0; i < tab.Count(); i++)
            {
                if (tab[i] > maxrows)
                    maxrows = tab[i];
            }

            for(int i = 0; i < maxrows; i++ )
            {
                TableRow rowVide = new TableRow();
                for (int j = 0; j < 6; j++)
                {
                    TableCell cellule = new TableCell();
                    cellule.Height = 10;
                    rowVide.Cells.Add(cellule);
                }
                idCalendarDay.Rows.Add(rowVide);
            }

            // Remplissage des naissances dans la premiere case.
            List<Evenement> ListNaissances = future_events.FindAll(
                delegate(Evenement evt)
                {
                    return (evt.id_type_evenement == 1 && evt.date_evenement.ToShortDateString() == currentDate.ToShortDateString());
                });
            ListNaissances.AddRange(previous_events.FindAll(
                delegate(Evenement evt)
                {
                    return (evt.id_type_evenement == 1 && evt.date_evenement.ToShortDateString() == currentDate.ToShortDateString());
                }));

            List<Evenement> ListSevrages = future_events.FindAll(
                delegate(Evenement evt)
                {
                    return (evt.id_type_evenement == 3 && evt.date_evenement.ToShortDateString() == currentDate.ToShortDateString());
                });

            ListSevrages.AddRange(previous_events.FindAll(
                delegate(Evenement evt)
                {
                    return (evt.id_type_evenement == 3 && evt.date_evenement.ToShortDateString() == currentDate.ToShortDateString());
                }));

            List<Evenement> ListEngraissages = future_events.FindAll(
                delegate(Evenement evt)
                {
                    return (evt.id_type_evenement == 14 && evt.date_evenement.ToShortDateString() == currentDate.ToShortDateString());
                });

            ListEngraissages.AddRange(previous_events.FindAll(
                delegate(Evenement evt)
                {
                    return (evt.id_type_evenement == 14 && evt.date_evenement.ToShortDateString() == currentDate.ToShortDateString());
                }));

            List<Evenement> ListSaillies = previous_events.FindAll(
                delegate(Evenement evt)
                {
                    return (evt.id_type_evenement == 4 && evt.date_evenement.ToShortDateString() == currentDate.ToShortDateString());
                });

            List<Evenement> ListGrosses = previous_events.FindAll(
                delegate(Evenement evt)
                {
                    return (evt.id_type_evenement == 7 && evt.date_evenement.ToShortDateString() == currentDate.ToShortDateString());
                });

            /*for (int i = 2; i <= previous_events.Count() + 1; i++)
            {
                string test = previous_events[i - 2].lapin_concerne.identification + "*";
                idCalendarDay.Rows[i].Cells[0].Text = "*";
                switch (previous_events[i - 2].id_type_evenement)
                {
                    case 1: idCalendarDay.Rows[i].Cells[0].CssClass = "cell_style_naissance"; break;
                    case 3: idCalendarDay.Rows[i].Cells[0].CssClass = "cell_style_sevrage"; break;
                    case 14: idCalendarDay.Rows[i].Cells[0].CssClass = "cell_style_engraissage"; break;
                }

            }*/



            for(int i = 2; i <= ListNaissances.Count()+1; i ++)
            {
                //idCalendarDay.Rows[i].Cells[0].Text = ListNaissances[i-2].lapin_concerne.identification + (ListNaissances[i-2].is_future_event ? "" : "*");
                HyperLink lien = new HyperLink();
                lien.NavigateUrl = "ManagementsLapins.aspx?idLapin=" + ListNaissances[i - 2].lapin_concerne.id + "&readOnly=0";
                lien.Text = ListNaissances[i - 2].lapin_concerne.identification + (ListNaissances[i - 2].is_future_event ? "" : "*");
                lien.Style.Add("display", "block");
                lien.Style.Add("width", "100%");
                lien.Style.Add("height", "100%");
                if (ListNaissances[i - 2].is_future_event && ListNaissances[i - 2].date_evenement <= DateTime.Now)
                    lien.Style.Add("Text-decoration", "blink");
                idCalendarDay.Rows[i].Cells[0].CssClass = "cell_style_naissance";
                idCalendarDay.Rows[i].Cells[0].Controls.Add(lien);
            }

            for(int i = 2; i <= ListSevrages.Count()+1; i ++)
            {
                //idCalendarDay.Rows[i].Cells[1].Text = ListSevrages[i - 2].lapin_concerne.identification + (ListSevrages[i - 2].is_future_event ? "" : "*");
                HyperLink lien = new HyperLink();
                lien.NavigateUrl = "ManagementsLapins.aspx?idLapin=" + ListSevrages[i - 2].lapin_concerne.id + "&readOnly=0";
                lien.Text = ListSevrages[i - 2].lapin_concerne.identification + (ListSevrages[i - 2].is_future_event ? "" : "*");
                lien.Style.Add("display", "block");
                lien.Style.Add("width", "100%");
                lien.Style.Add("height", "100%");
                if (ListSevrages[i - 2].is_future_event && ListSevrages[i - 2].date_evenement <= DateTime.Now)
                    lien.Style.Add("Text-decoration", "blink");
                idCalendarDay.Rows[i].Cells[1].CssClass = "cell_style_sevrage";
                idCalendarDay.Rows[i].Cells[1].Controls.Add(lien);
            }

            for(int i = 2; i <= ListEngraissages.Count()+1; i ++)
            {
                //idCalendarDay.Rows[i].Cells[2].Text = ListEngraissages[i - 2].lapin_concerne.identification + (ListEngraissages[i - 2].is_future_event ? "" : "*");
                HyperLink lien = new HyperLink();
                lien.NavigateUrl = "ManagementsLapins.aspx?idLapin=" + ListEngraissages[i - 2].lapin_concerne.id + "&readOnly=0";
                lien.Text = ListEngraissages[i - 2].lapin_concerne.identification + (ListEngraissages[i - 2].is_future_event ? "" : "*");
                lien.Style.Add("display", "block");
                lien.Style.Add("width", "100%");
                lien.Style.Add("height", "100%");
                idCalendarDay.Rows[i].Cells[2].CssClass = "cell_style_engraissage";
                if (ListEngraissages[i - 2].is_future_event && ListEngraissages[i - 2].date_evenement <= DateTime.Now)
                    idCalendarDay.Rows[i].Cells[2].CssClass = "cell_style_engraissage_blink";
                    //lien.Style.Add("Text-decoration", "blink");
                idCalendarDay.Rows[i].Cells[2].Controls.Add(lien);
            }

            for (int i = 2; i <= ListSaillies.Count() + 1; i++)
            {
                //idCalendarDay.Rows[i].Cells[2].Text = ListEngraissages[i - 2].lapin_concerne.identification + (ListEngraissages[i - 2].is_future_event ? "" : "*");
                HyperLink lien = new HyperLink();
                lien.NavigateUrl = "ManagementsLapins.aspx?idLapin=" + ListSaillies[i - 2].lapin_concerne.id + "&readOnly=0";
                lien.Text = ListSaillies[i - 2].lapin_concerne.identification + (ListSaillies[i - 2].is_future_event ? "" : "*");
                lien.Style.Add("display", "block");
                lien.Style.Add("width", "100%");
                lien.Style.Add("height", "100%");
                if (ListSaillies[i - 2].is_future_event && ListSaillies[i - 2].date_evenement <= DateTime.Now)
                    lien.Style.Add("Text-decoration", "blink");
                idCalendarDay.Rows[i].Cells[4].CssClass = "cell_style_saillie";
                idCalendarDay.Rows[i].Cells[4].Controls.Add(lien);
            }

            for (int i = 2; i <= ListGrosses.Count() + 1; i++)
            {
                //idCalendarDay.Rows[i].Cells[2].Text = ListEngraissages[i - 2].lapin_concerne.identification + (ListEngraissages[i - 2].is_future_event ? "" : "*");
                HyperLink lien = new HyperLink();
                lien.NavigateUrl = "ManagementsLapins.aspx?idLapin=" + ListGrosses[i - 2].lapin_concerne.id + "&readOnly=0";
                lien.Text = ListGrosses[i - 2].lapin_concerne.identification + (ListGrosses[i - 2].is_future_event ? "" : "*");
                lien.Style.Add("display", "block");
                lien.Style.Add("width", "100%");
                lien.Style.Add("height", "100%");
                if (ListGrosses[i - 2].is_future_event && ListGrosses[i - 2].date_evenement <= DateTime.Now)
                    lien.Style.Add("Text-decoration", "blink");
                idCalendarDay.Rows[i].Cells[5].CssClass = "cell_style_Grosse";
                idCalendarDay.Rows[i].Cells[5].Controls.Add(lien);
            }
        }

    }

}