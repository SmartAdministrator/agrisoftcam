<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accueil.aspx.cs" MasterPageFile="~/Pages/kiwi.Master" Inherits="kiwi.Pages.Accueil" %>

<asp:content ID="IdContentFirst" runat="server" ContentPlaceHolderID="IdMainContent">
    <div id="titre" class="Titre_Page">
        Bienvenue sur votre site de gestion d'animaux.
    </div>
    <div id="future_evenements" class="zone_results">
        Les différents evenements à venir dans les prochains jours.
        <asp:GridView ID="IdEventsResults" CssClass="table_results" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            OnPageIndexChanging="OnPageIndexChanging_coming_events" PageSize="10" OnRowDataBound="BoundActions" EmptyDataText="No Data available">
            <PagerStyle CssClass="pager_style" />
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="Numeric" Position="Bottom"/>
            <Columns>
                <asp:BoundField DataField ="Identification" HeaderText="Lapin" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Nom" HeaderText="Nom" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="age" HeaderText="Age" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="action" HeaderText="Action" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="estimated_date" HeaderText="date prévue" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="reste_jours" HeaderText="Jours restants" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="id" HeaderText="id" ItemStyle-Width ="50px" />
            </Columns>
        </asp:GridView>
    </div>
    <div id="Evenements" class="zone_results">
        Les differents evenements de ces derniers jours.
        <asp:GridView ID="IdLastEvents" CssClass="table_results" runat="server" AutoGenerateColumns="false" OnRowDataBound="BoundEvents"
            OnPageIndexChanging="OnPageIndexChanging_past_events" PageSize="15" AllowPaging="true" EmptyDataText="No Data available">
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="Numeric" Position="Bottom"/>
            <Columns>
                <asp:BoundField DataField ="IdEvent" HeaderText="N°" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Lapin" HeaderText="Lapin" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="id_lapin" HeaderText="Lapin Id" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Partenaire" HeaderText="Partenaire" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="id_partenaire" HeaderText="Partenaire Id" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="name_event" HeaderText="Evenement" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Date_event" HeaderText="Date" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Commentaires" HeaderText="Commentaire" ItemStyle-Width ="150px" />
            </Columns>
        </asp:GridView>
     </div>
    <div class="zone">
        <table>
            <tr>
                <td>
                    Date de debut
                </td>
                <td>
                    <asp:TextBox ID="IdTextBeginDate" TextMode="Date" runat="server"></asp:TextBox>
                </td>
                <td>
                    Date de fin
                </td>
                <td>
                    <asp:TextBox ID="IdTextEndDate" TextMode="Date" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="IdButtonSummary" Text="Valider" runat="server" OnClick="UpdateSummary"/>
                </td>
            </tr>
        </table>
    </div>

    <div id="dashboard" class="zone_results">
        Nous avons ici un tableau de bord sur votre élevage :
        <asp:GridView ID="IdSummaryEvents" CssClass="table_results" runat="server" AutoGenerateColumns="false" OnRowDataBound="BoundSummaries" EmptyDataText="No Data available">
            <Columns>
                <asp:BoundField DataField ="name_event" HeaderText="Description Event" ItemStyle-Width ="150px" />
                <asp:BoundField HeaderText="Date début" ItemStyle-Width ="150px" />
                <asp:BoundField HeaderText="Date fin" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="nbr_lapins" HeaderText="Lapins Affectés" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="percentage" HeaderText="Tendance" ItemStyle-Width ="150px" />
            </Columns>
        </asp:GridView>
    </div>
        <div class="zone_blanche"><a href="Rapports.aspx"><input class="btn_blue" value="Rapports" /></a><a href="Lapins.aspx"><input class="btn_blue" value="Elevage >" /></a></div>
    <!--</div>-->
</asp:content>