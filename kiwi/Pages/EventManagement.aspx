<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventManagement.aspx.cs" MasterPageFile="~/Pages/kiwi.Master" Inherits="kiwi.Pages.EventManagement" %>

<asp:content ID="IdContentFirst" runat="server" ContentPlaceHolderID="IdMainContent">
    <div id="titre" class="Titre_Page">
        Administration de la console
    </div>
    <div id="types_evenements" class="zone">
        Quel type d'évenement voulez vous ajouter :
        <asp:HiddenField ID="IdHiddenEvent" runat="server" />
       <table cellspacing="10" align="center">
           <tr>
               <td class="cell_style_naissance">
                   <asp:Button ID="IdButtonNaissance" runat="server" CssClass="cell_style_naissance button_style_height" OnClick="EventToDeclare" Text="Naissance" /></td>
               <td class="cell_style_sevrage">
                   <asp:Button ID="IdButtonSevrage" runat="server" CssClass="cell_style_sevrage button_style_height" OnClick="EventToDeclare" Text="Sevrage" />
               </td>
               <td class="cell_style_engraissage">
                   <asp:Button ID="IdButtonEngraissage" runat="server" CssClass="cell_style_engraissage button_style_height" OnClick="EventToDeclare" Text="Engraissage" />
               </td>
                <td class="cell_style_saillie">
                   <asp:Button ID="IdButtonSaillie" runat="server" CssClass="cell_style_saillie button_style_height" OnClick="EventToDeclare" Text="Saillie" />
               </td>
               <td class="cell_style_Grosse">
                   <asp:Button ID="IdButtonGrosse" runat="server" CssClass="cell_style_Grosse button_style_height" OnClick="EventToDeclare" Text="Grosse" />
               </td>
           </tr>
            <tr>
               <td class="">&nbsp;</td>
               <td class="">&nbsp;</td>
               <td class="">&nbsp;</td>
               <td class="">&nbsp;</td>
               <td class="">&nbsp;</td>
           </tr>
           <tr>
               <td class="cell_style_naissance">
                   <asp:Button ID="IdButtonVente" runat="server" CssClass="cell_style_naissance button_style_height" OnClick="EventToDeclare" Text="Vente" />
               </td>
               <td class="cell_style_sevrage">
                   <asp:Button ID="IdButtonPoids" runat="server" CssClass="cell_style_sevrage button_style_height" OnClick="EventToDeclare" Text="Poids" />
               </td>
               <td class="cell_style_engraissage">
                   <asp:Button ID="IdButtonTaille" runat="server" CssClass="cell_style_engraissage button_style_height" OnClick="EventToDeclare" Text="Taille" />
               </td>
               <td class="cell_style_saillie">
                   <asp:Button ID="IdButtonMort" runat="server" CssClass="cell_style_saillie button_style_height" OnClick="EventToDeclare" Text="Mort" />
               </td>
               <td class="cell_style_Grosse">
                   <asp:Button ID="IdButtonMaladie" runat="server" CssClass="cell_style_Grosse button_style_height" OnClick="EventToDeclare" Text="Maladie" />
               </td>
           </tr>
       </table>
    </div>
    <div id="type_naissance" class="zone">
        Nouvelle Naissance
       <table>
           <tr>
               <td class="cell_style_naissance">Naissance</td>
               <td class="cell_style_sevrage">Sevrage</td>
               <td class="cell_style_engraissage">Engraissage</td>
               <td class="cell_style_saillie">Saillie</td>
               <td class="cell_style_Grosse">Engrossement</td>
           </tr>
            <tr>
               <td class="">&nbsp;</td>
               <td class="">&nbsp;</td>
               <td class="">&nbsp;</td>
               <td class="">&nbsp;</td>
               <td class="">&nbsp;</td>
           </tr>
           <tr>
               <td class="cell_style_naissance">Vente</td>
               <td class="cell_style_sevrage">Poids</td>
               <td class="cell_style_engraissage">Taille</td>
               <td class="cell_style_saillie">Mort</td>
               <td class="cell_style_Grosse">Maladie</td>
           </tr>
       </table>
    </div>
    <asp:HiddenField ID="IdHiddenTypeEvent" runat="server" />
    <div id="Div1" class="zone">
       <asp:Label ID="IdLabelTypeEvent" runat="server">@</asp:Label>
       <table>
            <tr>
                <td style="width:60px"><asp:Label ID="IdLabelDeclarePere" runat="server"> Père :</asp:Label></td>
                <td style="width:100px"><asp:Label ID="IdLabelBatimentPere" runat="server">Batiment :</asp:Label></td>
                <td>
                    <asp:DropDownList ID="list_batiments_p" runat="server" CssClass="listbox_style_100" AutoPostBack="true" OnSelectedIndexChanged="update_list_cages_p"></asp:DropDownList>
                </td>
                <td style="width:60px"><asp:Label ID="IdLabelCagePere" runat="server">Cage :</asp:Label></td>
                <td>
                    <asp:DropDownList ID="list_cages_p" runat="server" CssClass="listbox_style_150" AutoPostBack="true" OnSelectedIndexChanged="update_list_lapins_p" ></asp:DropDownList>
                </td>
                <td style="width:60px"><asp:Label ID="IdLabelLapinPere" runat="server">Lapin :</asp:Label></td>
                <td>
                    <asp:DropDownList ID="list_lapins_p" runat="server" CssClass="listbox_style_150" AutoPostBack="true" OnSelectedIndexChanged="update_text_lapins_p" ></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="text_name_lapins_p" runat="server" CssClass="listbox_style_150" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="id_name_lapin_p" runat="server" Text="Nil"></asp:Label>
                </td>
            </tr>
            <tr class="trait">
                <td><asp:Label ID="IdLabelDeclareMere" runat="server">Mère :</asp:Label></td>
                <td><asp:Label ID="IdLabelBatimentMere" runat="server">Batiment :</asp:Label></td>
                <td>
                    <asp:DropDownList ID="list_batiments_m" runat="server" CssClass="listbox_style_100" AutoPostBack="true" OnSelectedIndexChanged="update_list_cages_m" ></asp:DropDownList>
                </td>
                <td><asp:Label ID="IdLabelCageMere" runat="server">Cage :</asp:Label></td>
                <td>
                    <asp:DropDownList ID="list_cages_m" runat="server" CssClass="listbox_style_150" AutoPostBack="true" OnSelectedIndexChanged="update_list_lapins_m" ></asp:DropDownList>
                </td>
                <td><asp:Label ID="IdLabelLapinMere" runat="server">Lapin :</asp:Label></td>
                <td>
                    <asp:DropDownList ID="list_lapins_m" runat="server" CssClass="listbox_style_150" AutoPostBack="true" OnSelectedIndexChanged="update_text_lapins_m" ></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="text_name_lapins_m" runat="server" CssClass="listbox_style_150" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="id_name_lapin_m" runat="server" Text="Nil"></asp:Label>
                </td>
            </tr>
                <tr>
                <td>&nbsp;</td>
                <td>Declarer :</td>
                <td>
                    <asp:DropDownList ID="list_type_events" runat="server" CssClass="listbox_style_150" OnSelectedIndexChanged="update_type_event" AutoPostBack="true" ></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="IdLabelNbLapins" runat="server">Nbre:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="IdTxtNbBirths" runat="server" CssClass="input_style" Text="1"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">&nbsp;</td>
                <td colspan="2"></td>
            </tr>
           </table>
    </div>
    <div class="zone_blanche"><asp:Button ID="IdActionDeclare" CssClass="btn_blue" Text="Declarer" runat="server" OnClick="update_event_lapins" /></div>
    <!--<div id="btn_zone" class="btn_zone">-->
     <div class="zone_blanche"><a href="Accueil.aspx"><input class="btn_blue" value="Accueil" /></a><a href="Lapins.aspx"><input class="btn_blue" value="Elevage >" /></a></div>
</asp:content>
