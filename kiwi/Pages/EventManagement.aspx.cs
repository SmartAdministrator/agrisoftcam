using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace kiwi.Pages
{
    public partial class EventManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
                Connexion.Open();

                fill_batiment_pere(Connexion);
                fill_batiment_mere(Connexion);
                fill_cage_pere(Connexion);
                fill_cage_mere(Connexion);
                fill_lapins_pere(Connexion);
                fill_lapins_mere(Connexion);
                /*
                 * fill_list_typeEvent(Connexion);
                fill_sexe(Connexion);
                fill_fiche_lapins(Connexion);
                fill_historique(Connexion);
                 * 
                 */
            }
        }

        protected void fill_batiment_pere(SqlConnection Conn)
        {
            SqlCommand batiments = new SqlCommand("SELECT batimentId, nom FROM Batiments", Conn);
            SqlDataReader results = batiments.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(results);

            list_batiments_p.DataSource = dt;
            list_batiments_p.DataTextField = "nom";
            list_batiments_p.DataValueField = "batimentId";

            list_batiments_p.DataBind();
            list_batiments_p.SelectedIndex = 0;
            fill_cage_pere(Conn);
        }

        protected void fill_batiment_mere(SqlConnection Conn)
        {
            SqlCommand batiments = new SqlCommand("SELECT batimentId, nom FROM Batiments", Conn);
            SqlDataReader results = batiments.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(results);

            list_batiments_m.DataSource = dt;
            list_batiments_m.DataTextField = "nom";
            list_batiments_m.DataValueField = "batimentId";

            list_batiments_m.DataBind();
            list_batiments_p.SelectedIndex = 0;
            fill_cage_mere(Conn);
        }

        protected void fill_cage_pere(SqlConnection Conn)
        {
            SqlCommand batiments = new SqlCommand("SELECT Id, Nom FROM Cages WHERE batiment_appartenance = " + list_batiments_p.SelectedValue.ToString(), Conn);
            SqlDataReader results = batiments.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(results);

            list_cages_p.DataSource = dt;
            list_cages_p.DataTextField = "Nom";
            list_cages_p.DataValueField = "Id";

            list_cages_p.DataBind();
            list_lapins_p.SelectedIndex = 0;
            fill_lapins_pere(Conn);

        }

        protected void fill_cage_mere(SqlConnection Conn)
        {
            SqlCommand batiments = new SqlCommand("SELECT Id, Nom FROM Cages WHERE batiment_appartenance = " + list_batiments_m.SelectedValue.ToString(), Conn);
            SqlDataReader results = batiments.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(results);

            list_cages_m.DataSource = dt;
            list_cages_m.DataTextField = "Nom";
            list_cages_m.DataValueField = "Id";
            list_cages_m.DataBind();

            list_cages_m.SelectedIndex = 0;

            fill_lapins_mere(Conn);
        }

        protected void fill_lapins_mere(SqlConnection Conn)
        {
            SqlCommand batiments = new SqlCommand("SELECT Id, Identification FROM Lapins WHERE coalesce(fattening_cage, birthcage) = " + list_cages_m.SelectedValue.ToString(), Conn);
            SqlDataReader results = batiments.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(results);

            list_lapins_m.DataSource = dt;
            list_lapins_m.DataTextField = "Identification";
            list_lapins_m.DataValueField = "Id";

            list_lapins_m.DataBind();
            list_lapins_m.SelectedIndex = 0;
            text_name_lapins_m.Text = list_lapins_m.SelectedItem.Text;
        }

        protected void fill_lapins_pere(SqlConnection Conn)
        {
            SqlCommand batiments = new SqlCommand("SELECT Id, Identification FROM Lapins WHERE coalesce(fattening_cage, birthcage) = " + list_cages_p.SelectedValue.ToString(), Conn);
            SqlDataReader results = batiments.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(results);

            list_lapins_p.DataSource = dt;
            list_lapins_p.DataTextField = "Identification";
            list_lapins_p.DataValueField = "Id";

            list_lapins_p.DataBind();
            list_lapins_p.SelectedIndex = 0;

            text_name_lapins_p.Text = list_lapins_p.SelectedItem.Text;
        }

        protected void update_list_cages_p(object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Connexion.Open();
            fill_cage_pere(Connexion);
        }

        protected void update_list_cages_m(object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Connexion.Open();
            fill_cage_mere(Connexion);
        }

        protected void update_list_lapins_p(object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Connexion.Open();
            fill_lapins_pere(Connexion);
        }

        protected void update_list_lapins_m(object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Connexion.Open();
            fill_lapins_mere(Connexion);
        }

        protected void update_text_lapins_p(object sender, EventArgs e)
        {
            text_name_lapins_p.Text = list_lapins_p.SelectedItem.Text;
        }

        protected void update_text_lapins_m(object sender, EventArgs e)
        {
            text_name_lapins_m.Text = list_lapins_m.SelectedItem.Text;
        }

        protected void EventToDeclare(object sender, EventArgs e)
        {
            IdLabelTypeEvent.Text = "Déclaration d";
            Button Action = (Button)sender;
            switch (Action.ID)
            {
                case "IdButtonNaissance": IdLabelTypeEvent.Text += "e Naissance"; break;
                case "IdButtonSevrage": IdLabelTypeEvent.Text += "e Sevrage"; break;
                case "IdButtonSaillie": IdLabelTypeEvent.Text += "e Saillie"; break;
                case "IdButtonEngraissage": IdLabelTypeEvent.Text += "' Engraissage"; break;
                case "IdButtonGrosse": IdLabelTypeEvent.Text += "' Engrossement"; break;
                case "IdButtonVente": IdLabelTypeEvent.Text += "e Vente"; break;
                case "IdButtonMort": IdLabelTypeEvent.Text += "e Mort"; break;
                case "IdButtonMaladie": IdLabelTypeEvent.Text += "e Maladie"; break;
                case "IdButtonPoids": IdLabelTypeEvent.Text += "e Prise de Poids"; break;
                case "IdButtonTaille": IdLabelTypeEvent.Text += "e Prise de Taille"; break;
            }
            update_type_event(Action, e);
        }


        protected void update_event_lapins(object sender, EventArgs e)
        {
            //string connexion_string = "Data source=localhost;Initial Catalog = kiwi; Integrated Security = True;";
            int nb = Convert.ToInt32(IdTxtNbBirths.Text);
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);

            SqlCommand update_event_rabbit = new SqlCommand("update_event_rabbit", Connexion);
            update_event_rabbit.CommandType = CommandType.StoredProcedure;
            update_event_rabbit.Parameters.AddWithValue("@nom", list_type_events.SelectedItem.Text);
            update_event_rabbit.Parameters.AddWithValue("@sexe", "N");
            update_event_rabbit.Parameters.AddWithValue("@type_event", Convert.ToInt32(list_type_events.SelectedValue));
            update_event_rabbit.Parameters.AddWithValue("@identification", list_lapins_p.SelectedItem.Text);
            update_event_rabbit.Parameters.AddWithValue("@cage", Convert.ToInt32(list_cages_m.SelectedValue));
            update_event_rabbit.Parameters.AddWithValue("@father", Convert.ToInt32(list_lapins_p.SelectedValue));
            update_event_rabbit.Parameters.AddWithValue("@mother", Convert.ToInt32(list_lapins_m.SelectedValue));
            update_event_rabbit.Parameters.AddWithValue("@height", 10);
            update_event_rabbit.Parameters.AddWithValue("@weight", 15);
            Connexion.Open();

            for (int i = 0; i < nb; i++)
            {
                update_event_rabbit.ExecuteNonQuery();
                //IdTxtNbBirths.Text = IdTxtNbBirths.Text + " " + ++i;
            }
        }

        protected void update_type_event(object sender, EventArgs e)
        {
            Button action = (Button)sender;
            IdHiddenEvent.Value = action.Text;
            switch (action.Text)
            {
                case "Mort":
                case "Maladie":
                case "Sevrage":
                case "Vente":
                case "Grosse":
                case "Poids":
                case "Taille":
                case "Engraissage":
                    IdLabelDeclareMere.Visible = false;
                    IdLabelDeclarePere.Visible = false;
                    IdLabelBatimentMere.Visible = false;
                    list_batiments_m.Visible = false;
                    IdLabelCageMere.Visible = false;
                    list_cages_m.Visible = false;
                    IdLabelLapinMere.Visible = false;
                    list_lapins_m.Visible = false;
                    text_name_lapins_m.Visible = false;
                    id_name_lapin_m.Visible = false;
                    IdTxtNbBirths.Visible = false;
                    IdTxtNbBirths.Text = "1";
                    IdLabelNbLapins.Visible = false;
                    break;
                case "Naissance":
                case "Saillie":
                    IdLabelDeclareMere.Visible = true;
                    IdLabelDeclarePere.Visible = true;
                    IdLabelBatimentMere.Visible = true;
                    list_batiments_m.Visible = true;
                    IdLabelCageMere.Visible = true;
                    list_cages_m.Visible = true;
                    IdLabelLapinMere.Visible = true;
                    list_lapins_m.Visible = true;
                    text_name_lapins_m.Visible = true;
                    id_name_lapin_m.Visible = true;
                    IdTxtNbBirths.Visible = true;
                    IdTxtNbBirths.Text = "1";
                    IdLabelNbLapins.Visible = true;
                    break;
                default:
                    IdLabelDeclareMere.Visible = false;
                    break;
            }
        }
    }


}