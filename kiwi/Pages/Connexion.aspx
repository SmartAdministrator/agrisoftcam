<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="kiwi.Pages.Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Connexion</title>
    <link rel="stylesheet" href="../style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="IdLabelInfos" runat="server"></asp:Label><br />
        <asp:Label ID="IdLabelNom" runat="server"></asp:Label><br />
        <asp:Label ID="IdLabelPrenom" runat="server"></asp:Label><br />
    <div class ="conteneur_accueil_style">
        <div class="logo_style">
               <h1> SIKOMBE & Fils Techno Agro Consulting <br /> Breeding edition</h1>
        </div>
        <div class ="connexion_style">
            <table>
                <tr>
                    <td align="right">Login : </td>
                    <td><asp:TextBox ID="IdTxtLogin" CssClass="class_textbox_connexion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="IdRequiredValidLogin" runat="server" ControlToValidate="IdTxtLogin" CssClass="class_error_connexion" ErrorMessage="*" />
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">Password : </td>
                    <td><asp:TextBox ID="IdTxtPassword" CssClass="class_textbox_connexion" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="IdRequiredValidPassword" runat="server" ControlToValidate="IdTxtPassword" CssClass="class_error_connexion" ErrorMessage="*" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right"><asp:Button ID="IdButtonConnexion" CssClass="class_button_connexion" OnClick="validation_connexion" Text="Go !" runat="server" ></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
    </form> 
</body>
</html>
