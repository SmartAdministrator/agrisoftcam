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
    public partial class ManagementsLapins : System.Web.UI.Page
    {
        protected int IdLapin;
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
                fill_list_typeEvent(Connexion);
                fill_sexe(Connexion);
                fill_fiche_lapins(Connexion);
                fill_historique(Connexion);
            }
            
        }

        protected void fill_fiche_lapins(SqlConnection Conn)
        {
            if (Request.QueryString["readOnly"] != null)
            {
                if (Request.QueryString["IdLapin"] != null)
                {
                    HiddenIdRabbit.Value = Request.QueryString["IdLapin"];
                    SqlCommand fiche_lapin = new SqlCommand("rabbit_informations", Conn);
                    fiche_lapin.Parameters.AddWithValue("@idLapin", Request.QueryString["IdLapin"]);
                    SqlDataAdapter da = new SqlDataAdapter();
                    fiche_lapin.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = fiche_lapin;

                    DataSet results_fiche = new DataSet();
                    DataTable table_fiche = new DataTable();
                    da.Fill(results_fiche);
                    //IdTitreIdentification.Text = results_fiche.Tables.Count.ToString();

                    DataRow dr = results_fiche.Tables[0].Rows[0];
                    if (Request.QueryString["readOnly"] == "1")
                    {
                        disable_TextBoxes();
                        IdTitreIdentification.Text = dr["Identification"].ToString();
                        IdTitreName.Text = dr["Nom"].ToString();
                        IDLabelIdentification.Text = dr["Identification"].ToString();
                        IdLabelName.Text = dr["Nom"].ToString();
                        IdLabelBirth.Text = dr["birthdate"].ToString();
                        IdLabelDateSevrage.Text = dr["weaningdate"].ToString();
                        IdLabelDateSaillie.Text = dr["sailliedate"].ToString();
                        IdLabelDateSick.Text = dr["illness_date"].ToString();
                        IdLabelDateGrosse.Text = dr["date_mesure_grosse"].ToString();
                        //IdLabelCageBirth.Text = dr["birthcage"].ToString();
                        IdLabelCageBirth.Text = dr["birthcage"].ToString() + " - " + dr["name_cage_birth"].ToString();
                        IdLabelPere.Text = dr["father"].ToString() + " - " + dr["identification_pere"].ToString();
                        IdLabelMere.Text = dr["mother"].ToString() + " - " + dr["identification_mere"].ToString();
                        IdLabelDateMort.Text = dr["deathdate"].ToString();
                        IdLabelPoids.Text = dr["weight"].ToString();
                        IdLabelTaille.Text = dr["height"].ToString();
                        IdLabelCageFat.Text = dr["fattening_cage"].ToString() + " - " + dr["name_cage_fat"].ToString();
                        IdLabelFratrie.Text = dr["NumFratrie"].ToString();
                        IdLabelSex.Text = dr["label_sexe"].ToString();
                        IdLabelDateEngraisse.Text = dr["fatteningdate"].ToString();
                        
                        IdCheckBoxGrosse.Checked = (bool)dr["gestation"];
                        if ((bool)dr["gestation"]) IdLabelGrosse.Text = "Oui."; else IdLabelGrosse.Text = "Non.";
                        IdCheckBoxGrosse.Enabled = false;

                        IdCheckBoxSick.Checked = (bool)dr["malade"];
                        if ((bool)dr["malade"]) IdLabelSick.Text = "Oui."; else IdLabelSick.Text = "Non.";
                        IdCheckBoxSick.Enabled = false;

                        IdCheckBoxMort.Checked = !(bool)dr["vitalite"];
                        if ((bool)dr["vitalite"]) IdLabelMort.Text = "Non."; else IdLabelMort.Text = "Oui.";
                        IdCheckBoxMort.Enabled = false;

                        IdCheckBoxSevrage.Checked = (bool)dr["weaned"];
                        if ((bool)dr["weaned"]) IdLabelSevrage.Text = "Oui."; else IdLabelSevrage.Text = "Non.";
                        IdCheckBoxSevrage.Enabled = false;

                        IdCheckBoxSaillie.Checked = (bool)dr["saillie"];
                        if ((bool)dr["saillie"]) IdLabelSaillie.Text = "Oui."; else IdLabelSaillie.Text = "Non.";
                        IdCheckBoxSaillie.Enabled = false;

                        IdCheckBoxEngraisse.Checked = (bool)dr["fattened"];
                        if ((bool)dr["fattened"]) IdLabelEngraisse.Text = "Oui."; else IdLabelEngraisse.Text = "Non.";
                        IdCheckBoxEngraisse.Enabled = false;
                    }
                    else
                    {
                        disable_labels();
                        IdTitreIdentification.Text = dr["Identification"].ToString();
                        IdTitreName.Text = dr["Nom"].ToString();
                        IDLabelIdentification.Text = dr["Identification"].ToString();
                        IdTextboxName.Text = dr["Nom"].ToString();
                        IdLabelBirth.Text = dr["birthdate"].ToString();
                        IdLabelDateSevrage.Text = dr["weaningdate"].ToString();
                        IdLabelDateSaillie.Text = dr["sailliedate"].ToString();
                        IdLabelDateGrosse.Text = dr["date_mesure_grosse"].ToString();
                        IdLabelDateSick.Text = dr["illness_date"].ToString();
                        IdTextBoxCageBirth.Text = dr["birthcage"].ToString();
                        IdLabelCageBirth.Text = dr["birthcage"].ToString() + " - " + dr["name_cage_birth"].ToString();
                        IdLabelPere.Text = dr["father"].ToString() + " - " + dr["identification_pere"].ToString();
                        IdLabelMere.Text = dr["mother"].ToString() + " - " + dr["identification_mere"].ToString();
                        IdLabelDateMort.Text = dr["deathdate"].ToString();
                        IdTextBoxPoids.Text = dr["weight"].ToString();
                        IdTextBoxTaille.Text = dr["height"].ToString();
                        IdTextBoxCageFat.Text = dr["fattening_cage"].ToString();
                        //IdLabelCageBirth.Text = dr["birthcage"].ToString();
                        IdTextBoxFratrie.Text = dr["NumFratrie"].ToString();
                        IdLabelDateEngraisse.Text = dr["fatteningdate"].ToString();

                        ListItem default_sex = IdListSex.Items.FindByValue(dr["sexe"].ToString().Trim());
                        IdListSex.SelectedIndex = IdListSex.Items.IndexOf(default_sex);
                        
                        IdCheckBoxGrosse.Checked = (bool)dr["gestation"];
                        if ((bool)dr["gestation"]) IdLabelGrosse.Text = "Oui."; else IdLabelGrosse.Text = "Non.";
                        //IdListSex.SelectedIndex = IdListSex.Items.IndexOf(IdListSex.Items.FindByValue(dr["sexe"].ToString()));

                        IdCheckBoxSick.Checked = (bool)dr["malade"];
                        if ((bool)dr["malade"]) IdLabelSick.Text = "Oui."; else IdLabelSick.Text = "Non.";

                        IdCheckBoxMort.Checked = !(bool)dr["vitalite"];
                        if ((bool)dr["vitalite"]) IdLabelMort.Text = "Non."; else IdLabelMort.Text = "Oui.";

                        IdCheckBoxSevrage.Checked = (bool)dr["weaned"];
                        if ((bool)dr["weaned"]) IdLabelSevrage.Text = "Oui."; else IdLabelSevrage.Text = "Non.";

                        IdCheckBoxSaillie.Checked = (bool)dr["saillie"];
                        if ((bool)dr["saillie"]) IdLabelSaillie.Text = "Oui."; else IdLabelSaillie.Text = "Non.";

                        IdCheckBoxEngraisse.Checked = (bool)dr["fattened"];
                        if ((bool)dr["fattened"]) IdLabelEngraisse.Text = "Oui."; else IdLabelEngraisse.Text = "Non.";

                        display_events_timeline();
                    }
                    IdTextBoxDateGrosse.Visible = false;
                    IdTextBoxMort.Visible = false;
                    IdTextBoxSick.Visible = false;
                    IdTextBoxSaillie.Visible = false;
                    IdTextBoxSevrage.Visible = false;
                    IdTextBoxEngraisse.Visible = false;
                }
            }
            fill_historique(Conn);
        }


        protected void update_fiche_lapins(object Sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Connexion.Open();
            int IdLapin = Convert.ToInt32(HiddenIdRabbit.Value);

            HiddenIdRabbit.Value = Request.QueryString["IdLapin"];
            SqlCommand fiche_lapin = new SqlCommand("rabbit_informations", Connexion);
            fiche_lapin.Parameters.AddWithValue("@idLapin", Request.QueryString["IdLapin"]);
            SqlDataAdapter da = new SqlDataAdapter();
            fiche_lapin.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = fiche_lapin;

            DataSet results_fiche = new DataSet();
            DataTable table_fiche = new DataTable();
            da.Fill(results_fiche);
            //IdTitreIdentification.Text = results_fiche.Tables.Count.ToString();

            DataRow dr = results_fiche.Tables[0].Rows[0];
            if (Request.QueryString["readOnly"] == "1")
            {
                disable_TextBoxes();
                IdTitreIdentification.Text = dr["Identification"].ToString();
                IdTitreName.Text = dr["Nom"].ToString();
                IDLabelIdentification.Text = dr["Identification"].ToString();
                IdLabelName.Text = dr["Nom"].ToString();
                IdLabelBirth.Text = dr["birthdate"].ToString();
                IdLabelDateSevrage.Text = dr["weaningdate"].ToString();
                IdLabelDateSaillie.Text = dr["sailliedate"].ToString();
                IdLabelDateSick.Text = dr["illness_date"].ToString();
                IdLabelDateGrosse.Text = dr["date_mesure_grosse"].ToString();
                IdLabelCageBirth.Text = dr["birthcage"].ToString() + " - " + dr["name_cage_birth"].ToString();
                IdLabelPere.Text = dr["father"].ToString() + " - " + dr["identification_pere"].ToString();
                IdLabelMere.Text = dr["mother"].ToString() + " - " + dr["identification_mere"].ToString();
                IdLabelDateMort.Text = dr["deathdate"].ToString();
                IdLabelPoids.Text = dr["weight"].ToString();
                IdLabelTaille.Text = dr["height"].ToString();
                IdLabelCageFat.Text = dr["fattening_cage"].ToString() + " - " + dr["name_cage_fat"].ToString();
                IdLabelFratrie.Text = dr["NumFratrie"].ToString();
                IdLabelSex.Text = dr["label_sexe"].ToString();
                IdLabelDateEngraisse.Text = dr["fatteningdate"].ToString();
                
                IdCheckBoxGrosse.Checked = (bool)dr["gestation"];
                if ((bool)dr["gestation"]) IdLabelGrosse.Text = "Oui."; else IdLabelGrosse.Text = "Non.";
                IdCheckBoxGrosse.Enabled = false;

                IdCheckBoxSick.Checked = (bool)dr["malade"];
                if ((bool)dr["malade"]) IdLabelSick.Text = "Oui."; else IdLabelSick.Text = "Non.";
                IdCheckBoxSick.Enabled = false;

                IdCheckBoxMort.Checked = !(bool)dr["vitalite"];
                if ((bool)dr["vitalite"]) IdLabelMort.Text = "Non."; else IdLabelMort.Text = "Oui.";
                IdCheckBoxMort.Enabled = false;

                IdCheckBoxSevrage.Checked = (bool)dr["weaned"];
                if ((bool)dr["weaned"]) IdLabelSevrage.Text = "Oui."; else IdLabelSevrage.Text = "Non.";
                IdCheckBoxSevrage.Enabled = false;

                IdCheckBoxSaillie.Checked = (bool)dr["saillie"];
                if ((bool)dr["saillie"]) IdLabelSaillie.Text = "Oui."; else IdLabelSaillie.Text = "Non.";
                IdCheckBoxSaillie.Enabled = false;

                IdCheckBoxEngraisse.Checked = (bool)dr["fattened"];
                if ((bool)dr["fattened"]) IdLabelEngraisse.Text = "Oui."; else IdLabelEngraisse.Text = "Non.";
                IdCheckBoxEngraisse.Enabled = false;
            }
            else
            {
                disable_labels();
                IdTitreIdentification.Text = dr["Identification"].ToString();
                IdTitreName.Text = dr["Nom"].ToString();
                IDLabelIdentification.Text = dr["Identification"].ToString();
                IdTextboxName.Text = dr["Nom"].ToString();
                IdLabelBirth.Text = dr["birthdate"].ToString();
                IdLabelDateSevrage.Text = dr["weaningdate"].ToString();
                IdLabelDateSaillie.Text = dr["sailliedate"].ToString();
                IdLabelDateSick.Text = dr["illness_date"].ToString();
                IdLabelDateGrosse.Text = dr["date_mesure_grosse"].ToString();
                IdLabelDateMort.Text = dr["deathdate"].ToString();
                //IdTextBoxSevrage.Text = dr["weaningdate"].ToString();
                //IdTextBoxSaillie.Text = dr["sailliedate"].ToString();
                //IdTextBoxCageBirth.Text = dr["birthcage"].ToString();
                IdLabelCageBirth.Text = dr["birthcage"].ToString() + " - " + dr["name_cage_birth"].ToString();
                IdLabelPere.Text = dr["father"].ToString() + " - " + dr["identification_pere"].ToString();
                IdLabelMere.Text = dr["mother"].ToString() + " - " + dr["identification_mere"].ToString();
                //IdTextBoxMort.Text = dr["deathdate"].ToString();
                IdTextBoxPoids.Text = dr["weight"].ToString();
                IdTextBoxTaille.Text = dr["height"].ToString();
                IdTextBoxCageFat.Text = dr["fattening_cage"].ToString();
                //IdLabelCageBirth.Text = dr["birthcage"].ToString();
                IdTextBoxFratrie.Text = dr["NumFratrie"].ToString();
                ListItem default_sex = IdListSex.Items.FindByValue(dr["sexe"].ToString().Trim());
                IdListSex.SelectedIndex = IdListSex.Items.IndexOf(default_sex);
                IdLabelDateEngraisse.Text = dr["fatteningdate"].ToString();


                IdCheckBoxGrosse.Checked = (bool)dr["gestation"];
                if ((bool)dr["gestation"]) IdLabelGrosse.Text = "Oui."; else IdLabelGrosse.Text = "Non.";

                IdCheckBoxSick.Checked = (bool)dr["malade"];
                if ((bool)dr["malade"]) IdLabelSick.Text = "Oui."; else IdLabelSick.Text = "Non.";

                IdCheckBoxMort.Checked = !(bool)dr["vitalite"];
                if ((bool)dr["vitalite"]) IdLabelMort.Text = "Non."; else IdLabelMort.Text = "Oui.";

                IdCheckBoxSevrage.Checked = (bool)dr["weaned"];
                if ((bool)dr["weaned"]) IdLabelSevrage.Text = "Oui."; else IdLabelSevrage.Text = "Non.";

                IdCheckBoxSaillie.Checked = (bool)dr["saillie"];
                if ((bool)dr["saillie"]) IdLabelSaillie.Text = "Oui."; else IdLabelSaillie.Text = "Non.";

                IdCheckBoxEngraisse.Checked = (bool)dr["fattened"];
                if ((bool)dr["fattened"]) IdLabelEngraisse.Text = "Oui."; else IdLabelEngraisse.Text = "Non.";

                display_events_timeline();

            }
            IdTextBoxDateGrosse.Visible = false;
            IdTextBoxMort.Visible = false;
            IdTextBoxSick.Visible = false;
            IdTextBoxSaillie.Visible = false;
            IdTextBoxSevrage.Visible = false;
            IdTextBoxEngraisse.Visible = false;
            fill_historique(Connexion);
        }

        protected void display_events_timeline()
        {
            IdCheckBoxGrosse.Enabled = false;
            IdCheckBoxEngraisse.Enabled = false;
            IdCheckBoxSevrage.Enabled = false;
            IdCheckBoxSaillie.Enabled = false;

            //Conditions d'affichage du sevrage : le lapin doit être vivant, en bonne santé (et voir plus tard les conditions par rapport à la date de naissance.)
            if (!IdCheckBoxSevrage.Checked && !IdCheckBoxSick.Checked && !IdCheckBoxMort.Checked)
                IdCheckBoxSevrage.Enabled = true;
            //Conditions d'affichage de la saillie d'une hase : Femelle, sevrée, en bonne santé et vivante
            if (IdCheckBoxSevrage.Checked && !IdCheckBoxSick.Checked && !IdCheckBoxMort.Checked && IdListSex.SelectedValue == "F")
            {
                IdCheckBoxSaillie.Enabled = true;
            }

            // pour pouvoir declarer un engrossement, il faut pour cela qu'une hase ait été saillie et vivante
            if (IdCheckBoxSaillie.Checked && !IdCheckBoxMort.Checked)
            {
                IdCheckBoxGrosse.Enabled = true;
            }

            //pour declarer un Engraissement terminé, il faut que le lapin soit sevré et vivant ( voir plus tard les conditions par rapport aux dates.)
            if (IdCheckBoxSevrage.Checked && !IdCheckBoxMort.Checked)
            {
                IdCheckBoxEngraisse.Enabled = true;
            }

            //Les lapins peuvent etre malades ou morts à tout moment.
            IdCheckBoxMort.Enabled = true;
            IdCheckBoxSick.Enabled = true;

        }

        protected void fill_historique(SqlConnection Conn)
        {
            SqlCommand histo = new SqlCommand("historique_evenements", Conn);
            SqlDataReader results_historique = null;

            histo.CommandType = CommandType.StoredProcedure;
            histo.Parameters.AddWithValue("@id_lapin",HiddenIdRabbit.Value);
            results_historique = histo.ExecuteReader();
            IdHistorique.DataSource = results_historique;
            IdHistorique.DataBind();
            results_historique.Close();

            IdHistorique.GridLines = GridLines.None;
        }
        protected void fill_historique(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Conn.Open();
            SqlCommand histo = new SqlCommand("historique_evenements", Conn);
            SqlDataReader results_historique = null;

            results_historique = histo.ExecuteReader();
            IdHistorique.DataSource = results_historique;
            IdHistorique.DataBind();
            results_historique.Close();
            IdHistorique.GridLines = GridLines.None;
        }

        protected void fill_sexe(SqlConnection Conn)
        {
            SqlCommand Sexe = new SqlCommand("SELECT id_sexe, label FROM sexe", Conn);
            SqlDataReader results = Sexe.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(results);

            IdListSex.DataSource = dt;
            IdListSex.DataTextField = "label";
            IdListSex.DataValueField = "id_sexe";

            IdListSex.DataBind();
        }

        protected void disable_TextBoxes()
        {
            IdTextboxName.Visible = false;
            //IdTextBoxSevrage.Visible = false;
            //IdTextBoxSaillie.Visible = false;
            IdTextBoxCageBirth.Visible = false;
            IdTextBoxPoids.Visible = false;
            IdTextBoxTaille.Visible = false;
            IdTextBoxCageFat.Visible = false;
            IdTextBoxPere.Visible = false;
            IdTextBoxMere.Visible = false;
            IdListSex.Visible = false;
            IdButtonSave.Visible = false;
            IdTextBoxFratrie.Visible = false;
            //IdTextBoxMort.Visible = false;

            IdUpdateCageBirth.Visible = false;
            IdUpdateCageFat.Visible = false;
            //IdUpdateDateDeath.Visible = false;
            //IdUpdateDateSaillie.Visible = false;
            //IdUpdateDateWeaning.Visible = false;
            IdUpdateFratrie.Visible = false;
            IdUpdateName.Visible = false;
            IdUpdatePoids.Visible = false;
            IdUpdateTaille.Visible = false;
            IdUpdateSex.Visible = false;
        }

        protected void disable_labels()
        {
            //IDLabelIdentification.Visible = false;
            IdUpdateCageBirth.Visible = false;
            IdLabelName.Visible = false;
            //IdLabelCageBirth.Visible = false;
            IdTextBoxCageBirth.Visible = false;
            IdTextBoxMere.Visible = false;
            IdTextBoxPere.Visible = false;
            //IdLabelSevrage.Visible = false;
            //IdLabelSaillie.Visible = false;
            IdLabelPoids.Visible = false;
            IdLabelTaille.Visible = false;
            IdLabelCageFat.Visible = false;
            IdLabelSex.Visible = false;
            IdButtonModify.Visible = false;
            //IdLabelMort.Visible = false;
            IdLabelFratrie.Visible = false;
        }

        protected void amend_single_information_checkbox(object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Connexion.Open();
            String champ = "";
            String champ_date = "";
            String value = "";
            String events = "";
            int id_cage = 0;
            int IdLapin = Convert.ToInt32(HiddenIdRabbit.Value);
            
            CheckBox action = (CheckBox)sender;

            switch (action.ID)
            {
                case "IdCheckBoxGrosse":
                    champ = "gestation";
                    value = IdCheckBoxGrosse.Checked.ToString();
                    if (IdCheckBoxGrosse.Checked)
                    {
                        events = "Grosse";
                        champ_date = "date_mesure_grosse";
                    }
                    break;
                case "IdCheckBoxMort":
                    champ = "vitalite";
                    value = (!IdCheckBoxMort.Checked).ToString();
                    if (IdCheckBoxMort.Checked)
                    {
                        events = "Mort";
                        champ_date = "deathdate";
                    }
                    break;
                case "IdCheckBoxSick":
                    champ = "malade";
                    value = IdCheckBoxSick.Checked.ToString();
                    if (IdCheckBoxSick.Checked)
                    {
                        events = "Maladie";
                        champ_date = "illness_date";
                    }
                    break;
                case "IdCheckBoxSevrage":
                    champ = "weaned";
                    value = IdCheckBoxSevrage.Checked.ToString();
                    if (IdCheckBoxSevrage.Checked)
                    {
                        events = "Sevrage";
                        champ_date = "weaningdate";
                    }
                    break;
                case "IdCheckBoxSaillie":
                    champ = "saillie";
                    value = IdCheckBoxSaillie.Checked.ToString();
                    if (IdCheckBoxSaillie.Checked)
                    {
                        events = "Saillie";
                        champ_date = "sailliedate";
                    }
                    break;
                case "IdCheckBoxEngraisse":
                    champ = "fattened";
                    value = IdCheckBoxEngraisse.Checked.ToString();
                    if (IdCheckBoxEngraisse.Checked)
                    {
                        events = "Engraissage";
                        champ_date = "fatteningdate";
                    }
                    break;
            }

            SqlCommand update_single_info = new SqlCommand("update_fiche_rabbits", Connexion);
            update_single_info.CommandType = CommandType.StoredProcedure;
            update_single_info.Parameters.AddWithValue("@id_lapin", IdLapin);
            update_single_info.Parameters.AddWithValue("@nom_champ", champ);
            update_single_info.Parameters.AddWithValue("@value_champ", value);
            update_single_info.Parameters.AddWithValue("@value_event", events);
            update_single_info.Parameters.AddWithValue("@champ_date", champ_date);
            update_single_info.Parameters.AddWithValue("@id_cage", id_cage);
            update_single_info.ExecuteNonQuery();
            update_fiche_lapins(sender, e);
        }

        protected void amend_single_information (object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Connexion.Open();
            String champ = "";
            String value = "";
            String events = "";
            int id_cage = 0;
            int IdLapin = Convert.ToInt32(HiddenIdRabbit.Value);
            Button action = (Button)sender;

            switch(action.ID)
            {
                case "IdUpdateName" :
                    champ = "Nom";
                    value = IdTextboxName.Text;
                    break;
                case "IdUpdateCageBirth" :
                    champ = "birthcage";
                    value = IdUpdateCageBirth.Text;
                    break;
                case "IdUpdateSex":
                    champ = "sexe";
                    value = IdListSex.SelectedValue;
                    events = "Sexe";
                    break;
                case "IdUpdateDateWeaning" :
                    champ = "weaningdate";
                    value =  IdTextBoxSevrage.Text;
                    events = "Sevrage";
                    break;
                case "IdUpdateDateSaillie" :
                    champ = "sailliedate";
                    value = IdTextBoxSaillie.Text;
                    events = "Saillie";
                    break;
                case "IdUpdateDateDeath" :
                    champ = "deathdate";
                    value = IdTextBoxMort.Text;
                    events = "Mort";
                    break;
                case "IdUpdateFratrie" :
                    champ = "NumFratrie";
                    value = IdTextBoxFratrie.Text;
                    events = "Fratrie";
                    break;
                case "IdUpdatePoids" :
                    champ = "weight";
                    value = IdTextBoxPoids.Text;
                    events = "Poids";
                    break;
                case "IdUpdateTaille" :
                    champ = "height";
                    value = IdTextBoxTaille.Text;
                    events = "Taille";
                    break;
                case "IdUpdateCageFat" :
                    champ = "fattening_cage";
                    value = IdTextBoxCageFat.Text;
                    events = "Cage";
                    break;
                case "IdCheckBoxGrosse":
                    champ = "gestation";
                    value = IdCheckBoxGrosse.Checked.ToString();
                    if(IdCheckBoxGrosse.Checked)
                        events = "Grosse";
                    break;
                case "IdCheckBoxEngraisse":
                    champ = "fattened";
                    value = IdCheckBoxEngraisse.Checked.ToString();
                    if (IdCheckBoxEngraisse.Checked)
                        events = "Engraisse";
                    break;
            }

            SqlCommand update_single_info = new SqlCommand("update_fiche_rabbits", Connexion);
            update_single_info.CommandType = CommandType.StoredProcedure;
            update_single_info.Parameters.AddWithValue("@id_lapin", IdLapin);
            update_single_info.Parameters.AddWithValue("@nom_champ",champ );
            update_single_info.Parameters.AddWithValue("@value_champ", value);
            update_single_info.Parameters.AddWithValue("@value_event", events);
            update_single_info.Parameters.AddWithValue("@champ_date", System.DBNull.Value);
            update_single_info.Parameters.AddWithValue("@id_cage",id_cage);
            update_single_info.ExecuteNonQuery();
            update_fiche_lapins(sender, e);

        }

        protected void amend_information(object sender, EventArgs e)
        {
            Response.Redirect("ManagementsLapins.aspx?idLapin=" + HiddenIdRabbit.Value + "&readOnly=0");
        }

        protected void save_information(object sender, EventArgs e)
        {
            //opérations d'enregistrement des valeurs ici
            Response.Redirect("ManagementsLapins.aspx?idLapin=" + HiddenIdRabbit.Value + "&readOnly=1");
        }

        protected void fill_batiment_pere(SqlConnection Conn)
        {
            SqlCommand batiments = new SqlCommand("SELECT batimentId, nom FROM Batiments",Conn);
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
            SqlCommand batiments = new SqlCommand("SELECT batimentId, nom FROM Batiments",Conn);
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
            SqlCommand batiments = new SqlCommand("SELECT Id, Nom FROM Cages WHERE batiment_appartenance = "+list_batiments_p.SelectedValue.ToString(), Conn);
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
            SqlCommand batiments = new SqlCommand("SELECT Id, Nom FROM Cages WHERE batiment_appartenance = "+list_batiments_m.SelectedValue.ToString(), Conn);
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

        protected void fill_list_typeEvent(SqlConnection Conn)
        {
            SqlCommand typeEvents = new SqlCommand("SELECT Type_EventId, Label FROM Type_Evenement", Conn);
            SqlDataReader results = typeEvents.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(results);

            list_type_events.DataSource = dt;
            list_type_events.DataTextField = "Label";
            list_type_events.DataValueField = "Type_EventId";

            list_type_events.DataBind();
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

        protected void update_type_event(object sender, EventArgs e)
        {
            switch (list_type_events.SelectedItem.Text)
            {
                case "Mort":
                case "Maladie":
                case "Sevrage":
                case "Vente":
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


    }
}