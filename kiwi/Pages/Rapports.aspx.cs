using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;

namespace kiwi.Pages
{
    public partial class Rapports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Connexion.Open();
            if (!IsPostBack)
            {
                Array ChartTypes = Enum.GetValues(typeof(SeriesChartType));
                foreach (var item in ChartTypes)
                {
                    IdDdlCharttypes.Items.Add(item.ToString());
                }
                IdDdlCharttypes.Items.Insert(0,"---Select a Chart---");
                IdTextBeginDate.Text = DateTime.Now.ToShortTimeString();
                IdTextEndDate.Text = DateTime.Now.ToShortTimeString();
                FillEvolEvents(Connexion);
                FillCheckBoxListEvents(Connexion);
                FillTypeTime(Connexion);
            }
        }

        private void FillCheckBoxListEvents(SqlConnection Conn)
        {
            SqlDataReader type_events_results = null;
            DataTable table_type_events_results = new DataTable();
            SqlCommand command_type_results = new SqlCommand("display_type_events", Conn);
            command_type_results.CommandType = CommandType.StoredProcedure;

            type_events_results = command_type_results.ExecuteReader();
            table_type_events_results.Load(type_events_results);

            IdCheckBoxListEvents.DataSource = table_type_events_results;
            IdCheckBoxListEvents.DataBind();

            IdCheckBoxListEvents.DataSource = table_type_events_results;
            IdCheckBoxListEvents.DataTextField = "libelle";
            IdCheckBoxListEvents.DataValueField = "id";
            IdCheckBoxListEvents.DataBind();
        }


        /*protected void FillDropDownListTypeTime(SqlConnection Conn)
        {
            SqlDataReader type_time_results = null;
            DataTable table_type_time_results = new DataTable();
            SqlCommand display_type_time_results = new SqlCommand("display_type_time", Conn);
            display_type_time_results.CommandType = CommandType.StoredProcedure;

            type_time_results = display_type_time_results.ExecuteReader();
            table_type_time_results.Load(type_time_results);

            IdChartEvolEvents.DataSource = table_type_time_results;
            IdChartEvolEvents.DataBind();
        }*/


        protected void FillEvolEvents()
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KiwiConnection"].ConnectionString);
            Conn.Open();
            SqlDataReader chart_events_results = null;
            DataTable table_chart_events_results = new DataTable();
            SqlCommand chart_results = new SqlCommand("chart_results", Conn);
            chart_results.CommandType = CommandType.StoredProcedure;

            chart_results.Parameters.AddWithValue("@begin_date", IdTextBeginDate.Text);
            chart_results.Parameters.AddWithValue("@end_date", IdTextEndDate.Text);
            chart_results.Parameters.AddWithValue("@type_time", IdListTypeTime.SelectedValue);

            chart_events_results = chart_results.ExecuteReader();
            table_chart_events_results.Load(chart_events_results);

            IdChartEvolEvents.DataSource = table_chart_events_results;
            IdChartEvolEvents.DataBind();
        }

        protected void FillEvolEvents(SqlConnection Conn)
        {
            SqlDataReader chart_events_results = null;
            DataTable table_chart_events_results = new DataTable();
            SqlCommand chart_results = new SqlCommand("chart_results", Conn);
            chart_results.CommandType = CommandType.StoredProcedure;

            chart_results.Parameters.AddWithValue("@begin_date", Convert.ToDateTime(IdTextBeginDate.Text));
            chart_results.Parameters.AddWithValue("@end_date", Convert.ToDateTime(IdTextEndDate.Text));
            chart_results.Parameters.AddWithValue("@type_time", IdListTypeTime.SelectedValue);

            chart_events_results = chart_results.ExecuteReader();
            table_chart_events_results.Load(chart_events_results);

            IdChartEvolEvents.DataSource = table_chart_events_results;
            IdChartEvolEvents.DataBind();
        }

        protected void OnCheckTypeEventChanged(object sender, EventArgs e)
        {
            CheckBoxList TypeEvents = (CheckBoxList)sender;
            List<ListItem> selectedItems = new List<ListItem>();

            IdChartEvolEvents.Series.Clear();

            foreach (ListItem item in TypeEvents.Items)
            { 
                if (item.Selected)
                    selectedItems.Add(item);
            }


            for (int i = 0; i < selectedItems.Count; i++ )
            {
                Series serie_event = new Series();
                serie_event.Name = selectedItems[i].Text;
                serie_event.XValueMember = "temps";
                serie_event.YValueMembers = selectedItems[i].Text;

                IdChartEvolEvents.Series.Add(serie_event);
            }

            for (int i = 0; i < IdChartEvolEvents.Series.Count; i++)
            {
                IdChartEvolEvents.Series[i].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), IdDdlCharttypes.SelectedItem.Text);
                IdChartEvolEvents.Series[i].BorderWidth = 3;
            }
            FillEvolEvents();
            //serie_event.Name = 
           // IdChartEvolEvents.Series.Add(item);
        }

        protected void OnChangeTypeTime(object sender, EventArgs e)
        {
            OnCheckTypeEventChanged(IdCheckBoxListEvents, e);
        }

        protected void FillTypeTime(SqlConnection Conn)
        {
            SqlDataReader type_time_results = null;
            DataTable table_type_time_results = new DataTable();
            SqlCommand type_time = new SqlCommand("display_type_time", Conn);
            type_time.CommandType = CommandType.StoredProcedure;

            type_time_results = type_time.ExecuteReader();
            table_type_time_results.Load(type_time_results);

            IdListTypeTime.DataSource = table_type_time_results;
            IdListTypeTime.DataTextField = "label";
            IdListTypeTime.DataValueField = "code";
            IdListTypeTime.DataBind();
        }

        protected void DdlCharttypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCheckTypeEventChanged(IdCheckBoxListEvents,e);
            /*for(int i = 0; i< IdChartEvolEvents.Series.Count; i++)
            {
                IdChartEvolEvents.Series[i].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), IdDdlCharttypes.SelectedItem.Text);
            }*/
            //IdChartEvolEvents.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), IdDdlCharttypes.SelectedItem.Text);
            //FillEvolEvents();
        }


    }
}