<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementsLapins.aspx.cs" MasterPageFile="~/Pages/kiwi.Master" Inherits="kiwi.Pages.ManagementsLapins" %>

<asp:content ID="IdContentFirst" runat="server" ContentPlaceHolderID="IdMainContent">
        <div id="info_rabbit">
            <div class="Titre_Page">
                Fiche du Lapin <asp:Label ID="IdTitreIdentification" runat="server" Text="Nil"></asp:Label> : <asp:Label ID="IdTitreName" runat="server" Text="Nil"></asp:Label>
                <asp:HiddenField ID="HiddenIdRabbit" runat="server" />    
             </div>
            <div class="zone">
                <table class="table_fiche">
                    <tr>
                        <td style="width:160px">Identification : </td>
                        <td>
                            <asp:Label ID="IDLabelIdentification" runat="server" Text="Nil"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Nom adopté : </td>
                        <td>
                            <asp:Label ID="IdLabelName" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextboxName" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="IdUpdateName" CssClass="" Text="Appliquer" runat="server" OnClick="amend_single_information" /></td>
                    </tr>
                    <tr>
                        <td>Date de naissance : </td>
                        <td>
                            <asp:Label ID="IdLabelBirth" runat="server" Text="Nil"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Cage de Naissance : </td>
                        <td>
                            <asp:Label ID="IdLabelCageBirth" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxCageBirth" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="IdUpdateCageBirth" CssClass="" Text="Appliquer" runat="server" OnClick="amend_single_information" /></td>
                    </tr>
                    <tr>
                        <td>Sexe : </td>
                        <td>
                            <asp:Label ID="IdLabelSex" runat="server" ></asp:Label>
                            <asp:DropDownList runat="server" ID="IdListSex"></asp:DropDownList>
                        </td>
                        <td><asp:Button ID="IdUpdateSex" CssClass="" Text="Appliquer" runat="server" OnClick="amend_single_information" /></td>
                    </tr>
                    <tr>
                        <td>Sevrage ? : </td>
                        <td>
                            <asp:Label ID="IdLabelSevrage" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxSevrage" runat="server" Text="Nil"></asp:TextBox>
                            <asp:CheckBox ID="IdCheckBoxSevrage" runat="server" OnCheckedChanged="amend_single_information_checkbox" AutoPostBack="true" />
                            -
                            <asp:Label ID="IdLabelDateSevrage" runat="server" Text="Nil"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Saillie ? : </td>
                        <td>
                            <asp:Label ID="IdLabelSaillie" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxSaillie" runat="server" Text="Nil"></asp:TextBox>
                            <asp:CheckBox ID="IdCheckBoxSaillie" runat="server" OnCheckedChanged="amend_single_information_checkbox" AutoPostBack="true" />
                            -
                            <asp:Label ID="IdLabelDateSaillie" runat="server" Text="Nil"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Grosse ? : </td>
                        <td>
                            <asp:Label ID="IdLabelGrosse" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxDateGrosse" runat="server" Text="Nil"></asp:TextBox>
                            <asp:CheckBox ID="IdCheckBoxGrosse" runat="server" OnCheckedChanged="amend_single_information_checkbox" AutoPostBack="true" />
                            -
                            <asp:Label ID="IdLabelDateGrosse" runat="server" Text="Nil"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Mort ? : </td>
                        <td>
                            <asp:Label ID="IdLabelMort" runat="server" Text="Nil"></asp:Label>
                            
                            <asp:CheckBox ID="IdCheckBoxMort" runat="server" OnCheckedChanged="amend_single_information_checkbox" AutoPostBack="true" />
                            -
                            <asp:Label ID="IdLabelDateMort" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxMort" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Engraissé ? : </td>
                        <td>
                            <asp:Label ID="IdLabelEngraisse" runat="server" Text=""></asp:Label>
                            
                            <asp:CheckBox ID="IdCheckBoxEngraisse" runat="server" OnCheckedChanged="amend_single_information_checkbox" AutoPostBack="true" />
                            -
                            <asp:Label ID="IdLabelDateEngraisse" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxEngraisse" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                     <tr>
                        <td>Malade ? : </td>
                        <td>
                            <asp:Label ID="IdLabelSick" runat="server" Text="Nil"></asp:Label>
                            
                            <asp:CheckBox ID="IdCheckBoxSick" runat="server" OnCheckedChanged="amend_single_information_checkbox" AutoPostBack="true" />
                            -
                            <asp:Label ID="IdLabelDateSick" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxSick" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Père : </td>
                        <td>
                            <asp:Label ID="IdLabelPere" runat="server" Text="Nil"></asp:Label>
                            <asp:DropDownList ID="IdTextBoxPere" runat="server"></asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Mère : </td>
                        <td>
                            <asp:Label ID="IdLabelMere" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxMere" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Numéro fratrie : </td>
                        <td>
                            <asp:Label ID="IdLabelFratrie" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxFratrie" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="IdUpdateFratrie" CssClass="" Text="Appliquer" runat="server" OnClick="amend_single_information" /></td>
                    </tr>
                    <tr>
                        <td>Poids : </td>
                        <td>
                            <asp:Label ID="IdLabelPoids" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxPoids" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="IdUpdatePoids" CssClass="" Text="Appliquer" runat="server" OnClick="amend_single_information" /></td>
                    </tr>
                    <tr>
                        <td>Taille : </td>
                        <td>
                            <asp:Label ID="IdLabelTaille" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxTaille" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="IdUpdateTaille" CssClass="" Text="Appliquer" runat="server" OnClick="amend_single_information" /></td>
                    </tr>
                    <tr>
                        <td>Cage d'engraissement : </td>
                        <td>
                            <asp:Label ID="IdLabelCageFat" runat="server" Text="Nil"></asp:Label>
                            <asp:TextBox ID="IdTextBoxCageFat" runat="server" Text="Nil"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="IdUpdateCageFat" CssClass="" Text="Appliquer" runat="server" OnClick="amend_single_information" /></td>
                    </tr>
                </table>
                
            </div>
             
        </div>
        
        <div class="zone_blanche">
            <asp:Button ID="IdButtonSave" CssClass="btn_blue" Text="Appliquer" OnClick="save_information" runat="server" />
            <asp:Button ID="IdButtonModify" CssClass="btn_blue" Text="Modifer" OnClick="amend_information" runat="server" />
        </div>
        <div class="zone">
            <table class="table_fiche">
                    <tr>
                        <td style="text-align:center"><h3>Historique des actions Lapins</h3></td>
                    </tr>
            </table>
            <asp:GridView ID="IdHistorique" CssClass="table_fiche" runat="server" AutoGenerateColumns="false" EmptyDataText="No Data available">
            <Columns>
                <asp:BoundField DataField ="numero" HeaderText="N°" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Identification" HeaderText="Lapin" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Type_event" HeaderText="Lapin" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Date_event" HeaderText="Date event" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="Commentaires" HeaderText="Comments" ItemStyle-Width ="150px" />
                <asp:BoundField DataField ="identification_partenaire" HeaderText="Ident. Partenaire" ItemStyle-Width ="150px" />
            </Columns>
        </asp:GridView>
        </div>
        <div class="zone_blanche">
            <asp:Button ID="IdButtonExport" CssClass="btn_blue" Text="Exporter" runat="server" />
        </div>
        <asp:Panel ID="IdPanelA" runat="server">
        <div id="form_birth" class="zone">
        
            <div>
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
        </div>
        </asp:Panel>
        <div class="zone_blanche"><asp:Button ID="IdActionDeclare" CssClass="btn_blue" Text="Declarer" runat="server" OnClick="update_event_lapins" /></div>
    <!--<div id="btn_zone" class="btn_zone">-->
        <div class="zone_blanche"><a href="Accueil.aspx"><input class="btn_blue" value="Accueil" /></a><a href="Lapins.aspx"><input class="btn_blue" value="Elevage >" /></a></div>
    <!--</div>-->
</asp:content>