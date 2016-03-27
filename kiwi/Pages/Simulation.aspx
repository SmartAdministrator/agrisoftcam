<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simulation.aspx.cs" MasterPageFile="~/Pages/kiwi.Master" Inherits="kiwi.Pages.Simulation" %>

<asp:content ID="IdContentFirst" runat="server" ContentPlaceHolderID="IdMainContent">
    <div id="titre" class="Titre_Page">
        Bienvenue sur votre site de gestion.
    </div>
    <div id="future_evenements" class="zone_results">
        Evolution de naissances
    </div>
    <div id="Filtres" class="zone">
        <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
        <asp:HiddenField ID="HiddenView" runat="server" />
        Infos génerales : taille clapier : <asp:Label ID="idNbTotal" runat="server" Text="nil"></asp:Label> Id lapin <asp:Label ID="idLapinSelect" runat="server" Text="Nil"></asp:Label><br />
        et valeur <asp:Label ID="IdValue" runat="server" Text="Nil"></asp:Label><br />
        <asp:Label ID="idFuture" runat="server"></asp:Label>
        <asp:Table ID="IdCalendarMonthSecond" runat="server" CssClass="center" >
            <asp:TableHeaderRow>
                <asp:TableHeaderCell><asp:LinkButton ID="IdUrlPreviousMonth" OnClick="previous_month" Text="<<" runat="server"></asp:LinkButton></asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="5" ID="IdLabelMonth" Text="Nil" ></asp:TableHeaderCell>
                <asp:TableHeaderCell><asp:LinkButton ID="IdUrlNextMonth" OnClick="next_month"  Text=">>" runat="server"></asp:LinkButton></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="125">Lundi</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Mardi</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Mercredi</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Jeudi</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Vendredi</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Samedi</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Dimanche</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <asp:Table ID="idCalendarDay" runat="server" CssClass="center" >
            <asp:TableHeaderRow>
                <asp:TableHeaderCell><asp:LinkButton ID="IdLinkPreviousDay" OnClick="previous_day"  Text="<<" runat="server"></asp:LinkButton></asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="5" ID="IdLabelDay" Text="Nil" ></asp:TableHeaderCell>
                <asp:TableHeaderCell><asp:LinkButton ID="IdLinkNextDay" OnClick="next_day"  Text=">>" runat="server"></asp:LinkButton></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow ID="IdHeaderEvt">
                <asp:TableHeaderCell Width="125">Naissances</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Sevrages</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Engraissages</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Ventes</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Saillies</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Grosses</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="125">Morts</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

    </div>
                

    <div id="dashboard" class="zone_results">
    </div>
        <div class="zone_blanche"><a href="Rapports.aspx"><input class="btn_blue" value="Rapports" /></a><a href="Lapins.aspx"><input class="btn_blue" value="Elevage >" /></a></div>
    <!--</div>-->
</asp:content>