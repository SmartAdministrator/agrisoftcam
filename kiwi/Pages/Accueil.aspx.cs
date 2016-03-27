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
    public partial class Accueil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
                SqlDataReader results_coming_events = null;
                DataTable table_coming_events = new DataTable();
                SqlDataReader results_past_events = null;
                DataTable table_past_events = new DataTable();
                SqlDataReader results_summary_events = null;

                try
                {
                    Conn.Open();
                    SqlCommand coming_events = new SqlCommand("display_events_to_come", Conn);
                    SqlCommand past_events = new SqlCommand("display_lasts_events", Conn);
                    SqlCommand summary_events = new SqlCommand("recap_on_events", Conn);

                    results_coming_events = coming_events.ExecuteReader();
                    table_coming_events.Load(results_coming_events);
                    IdEventsResults.DataSource = table_coming_events;//results_coming_events;
                    IdEventsResults.DataBind();
                    results_coming_events.Close();

                    results_past_events = past_events.ExecuteReader();
                    table_past_events.Load(results_past_events);
                    IdLastEvents.DataSource = table_past_events;
                    IdLastEvents.DataBind();
                    results_past_events.Close();

                    summary_events.Parameters.AddWithValue("@date_debut", DateTime.Now.ToShortDateString());
                    summary_events.Parameters.AddWithValue("@date_fin", DateTime.Now.ToShortDateString());
                    summary_events.CommandType = CommandType.StoredProcedure;
                    results_summary_events = summary_events.ExecuteReader();
                    IdSummaryEvents.DataSource = results_summary_events;
                    IdSummaryEvents.DataBind();
                    results_summary_events.Close();

                }
                catch (Exception ex)
                {
throw;
                }
                finally
                {
                    if (results_coming_events != null)
                    {
                        results_coming_events.Close();
                    }
                    if (results_past_events != null)
                    {
                        results_past_events.Close();
                    }
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                }
        }

        protected void OnPageIndexChanging_coming_events(object sender, GridViewPageEventArgs e)
        {
            IdEventsResults.PageIndex = e.NewPageIndex;
            IdEventsResults.DataBind();
        }

        protected void OnPageIndexChanging_past_events(object sender, GridViewPageEventArgs e)
        {
            IdLastEvents.PageIndex = e.NewPageIndex;
            IdLastEvents.DataBind();
        }

        protected void BoundActions(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime date_event = Convert.ToDateTime(e.Row.Cells[4].Text);
                e.Row.Cells[0].Text = "<a href='ManagementsLapins.aspx?idLapin=" + e.Row.Cells[6].Text + "&readOnly=1'>" + e.Row.Cells[0].Text + "</a>";
                e.Row.Cells[4].Text = date_event.ToShortDateString();
            }
        }

        protected void BoundEvents(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime date_event = Convert.ToDateTime(e.Row.Cells[6].Text);
                
                e.Row.Cells[1].Text = "<a href='ManagementsLapins.aspx?idLapin=" + e.Row.Cells[2].Text + "&readOnly=1'>" + e.Row.Cells[1].Text + "</a>";
                e.Row.Cells[3].Text = "<a href='ManagementsLapins.aspx?idLapin=" + e.Row.Cells[4].Text + "&readOnly=1'>" + e.Row.Cells[3].Text + "</a>";
                e.Row.Cells[6].Text = date_event.ToShortDateString();
            }
        }

        protected void BoundSummaries(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = IdTextBeginDate.Text;
                e.Row.Cells[2].Text = IdTextEndDate.Text;
                e.Row.Cells[4].Text = e.Row.Cells[4].Text + " %";
            }
        }

        protected void UpdateSummary(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            SqlDataReader results_summary_events = null;

            try
            {
                Conn.Open();
                SqlCommand summary_events = new SqlCommand("recap_on_events", Conn);

                summary_events.Parameters.AddWithValue("@date_debut", IdTextBeginDate.Text);
                summary_events.Parameters.AddWithValue("@date_fin", IdTextEndDate.Text);
                summary_events.CommandType = CommandType.StoredProcedure;
                results_summary_events = summary_events.ExecuteReader();
                IdSummaryEvents.DataSource = results_summary_events;
                IdSummaryEvents.DataBind();
                results_summary_events.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (results_summary_events != null)
                {
                    results_summary_events.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


    }
}