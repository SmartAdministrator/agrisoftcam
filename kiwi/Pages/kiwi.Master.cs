using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace kiwi.Pages
{
    public partial class kiwi : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAccount"] != null)
                if ((bool)Session["IsAccount"])
                {
                    IdLabelNom.Text = (string)Session["nom"];
                    IdLabelPrenom.Text = (string)Session["prenom"];
                    IdLapbelProfile.Text = (string)Session["profil"];
                    IdLabelMatricule.Text = (string)Session["matricule"];
                    chosen_page();
                }
                else
                    Response.Redirect("Connexion.aspx");
            else
                Response.Redirect("Connexion.aspx");
        }

        public void chosen_page() 
        {
            
            string path = HttpContext.Current.Request.Url.AbsolutePath.Split('/')[2];
            
       
            Id_Onglet_Accueil.Attributes.Clear();
            Id_Onglet_Administration.Attributes.Clear();
            Id_Onglet_Evolutions.Attributes.Clear();
            Id_Onglet_ManagementLapins.Attributes.Clear();
            Id_Onglet_Rechercher.Attributes.Clear();
            Id_Onglet_Simulations.Attributes.Clear();

            IdImgProfil.ImageUrl = "~/Images/Sikombe.png";
            switch (path)
            {
                case "Accueil.aspx": Id_Onglet_Accueil.Attributes.Add("class","active"); break;
                case "Administration.aspx": Id_Onglet_Administration.Attributes.Add("class","active"); break;
                case "Rapports.aspx": Id_Onglet_Evolutions.Attributes.Add("class","active"); break;
                case "ManagementsLapins.aspx": Id_Onglet_ManagementLapins.Attributes.Add("class","active"); break;
                case "Lapins.aspx": Id_Onglet_Rechercher.Attributes.Add("class", "active"); break;
                case "Simulation.aspx": Id_Onglet_Simulations.Attributes.Add("class","active"); break;
                default: Id_Onglet_Accueil.Attributes.Add("class", "active"); break;
            }
        }
    }
}