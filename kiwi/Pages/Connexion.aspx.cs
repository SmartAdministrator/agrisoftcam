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
    public partial class Connexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void validation_connexion(object Sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            SqlCommand account_informations = new SqlCommand("infos_connexion", Conn);
            SqlDataAdapter da = new SqlDataAdapter();
            //Ajout de paramètres
            account_informations.Parameters.AddWithValue("@login", IdTxtLogin.Text);
            account_informations.Parameters.AddWithValue("@password", IdTxtPassword.Text);
           
            //type de requete à appeller
            account_informations.CommandType = CommandType.StoredProcedure;

            da.SelectCommand = account_informations;


            DataSet ds_account_informations = new DataSet();
            DataTable infos_account = new DataTable();
            da.Fill(ds_account_informations);

            Session["IsAccount"] = false;
            if (ds_account_informations.Tables[0].Rows.Count != 0)
            {
                DataRow dr = ds_account_informations.Tables[0].Rows[0];
                IdLabelInfos.Text = "Nous avons trouvé une occurence";
                IdLabelNom.Text = dr["nom"].ToString();
                IdLabelPrenom.Text = dr["prenom"].ToString();

                Session["IsAccount"] = true;
                Session["nom"] = dr["nom"].ToString();
                Session["prenom"] = dr["prenom"].ToString();
                Session["matricule"] = dr["matricule"].ToString();
                Session["profil"] = dr["profil"].ToString();
                Session["url_photo_profil"] = dr["url_photo_profil"].ToString();

                Response.Redirect("Accueil.aspx");
            }
            else
            {
                IdLabelInfos.Text = "Aucune Occurrence Putain !!!";
            }
        }
    }
}