<%@ Page Title="Page d'accueil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="kiwi._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modifiez ce modèle pour dynamiser votre application ASP.NET.</h2>
            </hgroup>
            <p>
                Pour en savoir plus sur ASP.NET, consultez <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                La page contient <mark>vidéos, didacticiels et exemples</mark> pour vous aider à tirer le meilleur parti d'ASP.NET.
                Si vous avez des questions relatives à ASP.NET, consultez
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">nos forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Nous suggérons ce qui suit :</h3>
    <ol class="round">
        <li class="one">
            <h5>Mise en route</h5>
            ASP.NET Web Forms vous permet de développer des sites Web dynamiques à l'aide d'un modèle connu, basé sur l'événement et le glisser-déplacer.
            Une aire de conception et des centaines de commandes et de composants vous permettent de développer rapidement des sites puissants et sophistiqués, basés sur l'IU et avec accès aux données.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Pour en savoir plus…</a>
        </li>
        <li class="two">
            <h5>Ajouter des packages NuGet et dynamiser votre codage</h5>
            NuGet facilite l'installation et la mise à jour de bibliothèques et d'outils gratuits.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Pour en savoir plus…</a>
        </li>
        <li class="three">
            <h5>Rechercher un hébergement Web</h5>
            Vous trouverez facilement un fournisseur d'hébergement Web proposant la combinaison de fonctionnalités et de prix idéale pour vos applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Pour en savoir plus…</a>
        </li>
    </ol>
</asp:Content>
