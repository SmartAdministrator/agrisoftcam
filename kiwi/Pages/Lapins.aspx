<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lapins.aspx.cs" MasterPageFile="~/Pages/kiwi.Master" Inherits="kiwi.Pages.Lapins" %>

<asp:content ID="IdContentFirst" runat="server" ContentPlaceHolderID="IdMainContent">
  <div class="Titre_Page">Recherche de Lapins.</div>
    <div id="management" class="zone">
       
        <table class="table_fiche">
            <tr class="trait">
                <td>Recherche par nom : </td>
                <td>
                    <input type="text" class="autocompletion" value="Tapez le nom du lapin ici.." />
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td>Batiment</td>
                <td>
                    <select style="width:170px">
                        <option>Tous</option>
                        <option>Batiment A</option>
                    </select>
                </td>
                <td>Type de cage</td>
                <td>
                    <select style="width:170px">
                        <option>Tous</option>
                        <option>Cage mère</option>
                        <option>Cage d'engraissement</option>
                        <option>...</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Cages</td>
                <td>
                    <select style="width:170px">
                        <option>Tous</option>
                        <option>Medumba</option>
                        <option>Feussap</option>
                        <option>...</option>
                    </select>
                </td>
                <td>Lapins</td>
                <td>
                    <select style="width:170px">
                        <option>Tous</option>
                        <option>Justin</option>
                        <option>Alcine</option>
                        <option>Pothin</option>
                        <option>...</option>
                    </select>
                </td>
            </tr>
        </table>
            
        </div>
        <div id="btn_zone" class="btn_zone">
            <a href="Accueil.aspx"><input class="btn" value="Accueil" /></a>
            <a href="Lapins.aspx"><input class="btn" value="Rechercher >" /></a>
        </div>
        <div>
            <div id="CellCage1"><a href="ManagementsLapins.aspx?IdLapin=1&readOnly=1"><input type="button" class="rab_results" value="Justin" /></a></div>
            <div id="CellCage2"><a href="ManagementsLapins.aspx?IdLapin=2&readOnly=1"><input type="button" class="rab_results" value="Alcine" /></a></div>
            <div id="CellCage3"><a href="ManagementsLapins.aspx?IdLapin=3&readOnly=1"><input type="button" class="rab_results" value="Pothin" /></a></div>
            <div id="CellCage4"><a href="ManagementsLapins.aspx?IdLapin=4&readOnly=1"><input type="button" class="rab_results" value="Boniface" /></a></div>
            <div id="CellCage5"><a href="ManagementsLapins.aspx?IdLapin=5&readOnly=1"><input type="button" class="rab_results" value="Igor" /></a></div>
            <div id="CellCage6"><a href="ManagementsLapins.aspx?IdLapin=6&readOnly=1"><input type="button" class="rab_results" value="Norbert" /></a></div>
            <div id="Div1"><a href="ManagementsLapins.aspx?IdLapin=7&readOnly=1"><input type="button" class="rab_results" value="Igor" /></a></div>
            <div id="Div2"><a href="ManagementsLapins.aspx?IdLapin=8&readOnly=1"><input type="button" class="rab_results" value="Norbert" /></a></div>
            <div id="Div3"><a href="ManagementsLapins.aspx?IdLapin=9&readOnly=1"><input type="button" class="rab_results" value="Justin" /></a></div>
            <div id="Div4"><a href="ManagementsLapins.aspx?IdLapin=10&readOnly=1"><input type="button" class="rab_results" value="Alcine" /></a></div>
            <div id="Div5"><a href="ManagementsLapins.aspx?IdLapin=1&readOnly=1"><input type="button" class="rab_results" value="Pothin" /></a></div>
            <div id="Div6"><a href="ManagementsLapins.aspx?IdLapin=2&readOnly=1"><input type="button" class="rab_results" value="Boniface" /></a></div>
            <div id="Div7"><a href="ManagementsLapins.aspx?IdLapin=3&readOnly=1"><input type="button" class="rab_results" value="Igor" /></a></div>
            <div id="Div8"><a href="ManagementsLapins.aspx?IdLapin=4&readOnly=1"><input type="button" class="rab_results" value="Norbert" /></a></div>
            <div id="Div9"><a href="ManagementsLapins.aspx?IdLapin=5&readOnly=1"><input type="button" class="rab_results" value="Igor" /></a></div>
            <div id="Div10"><a href="ManagementsLapins.aspx?IdLapin=6&readOnly=1"><input type="button" class="rab_results" value="Norbert" /></a></div>
        </div>
</asp:content>