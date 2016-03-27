<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rapports.aspx.cs" Inherits="kiwi.Pages.Rapports" MasterPageFile="~/Pages/kiwi.Master" %>

<asp:content ID="IdContentFirst" runat="server" ContentPlaceHolderID="IdMainContent">
    <div id="titre" class="Titre_Page">
        Bienvenue sur votre site de gestion d'animaux.
    </div>
    <div id="future_evenements" class="zone_results">
        Evolution de naissances
    </div>
    <div id="Filtres" class="zone">
        <asp:Label ID="IdLabelTypeChart" runat="server">Type de Graphique : </asp:Label> <asp:DropDownList ID="IdDdlCharttypes" OnSelectedIndexChanged="DdlCharttypes_SelectedIndexChanged" AutoPostBack="true" runat="server">
        </asp:DropDownList>
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
                    <asp:Button ID="IdButtonSummary" Text="Valider" runat="server"/>
                </td>
            </tr>
        </table>
        <asp:Label ID="IdLabelTypeTime" runat="server">Echelle du temps : </asp:Label>
        <asp:DropDownList ID="IdListTypeTime" OnSelectedIndexChanged="OnChangeTypeTime" AutoPostBack="true" runat="server">
        </asp:DropDownList>
        <asp:CheckBoxList ID="IdCheckBoxListEvents" OnSelectedIndexChanged="OnCheckTypeEventChanged" AutoPostBack="true" RepeatColumns="6" RepeatLayout="Table" runat="server">
        </asp:CheckBoxList>
     </div>
        <asp:Chart ID="IdChartEvolEvents" BackColor="#F4FEFE"  runat="server" Width="922px" Height="430px">
            <ChartAreas>
                <asp:ChartArea BackColor="#F4FEFE" Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Information" BackColor="#F4FEFE" TitleAlignment="Near" ></asp:Legend>
            </Legends>
        </asp:Chart>
    <div id="Evenements" class="zone_results">
        Evolutions des morts
     </div>

    <div id="dashboard" class="zone_results">
    </div>
        <div class="zone_blanche"><a href="Rapports.aspx"><input class="btn_blue" value="Rapports" /></a><a href="Lapins.aspx"><input class="btn_blue" value="Elevage >" /></a></div>
    <!--</div>-->
</asp:content>
