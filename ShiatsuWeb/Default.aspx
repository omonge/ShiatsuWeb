<%@ Page Title="Página principal" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="ShiatsuWeb._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Gracias por ingresar a Shiatsu Web.</h2>
            </hgroup>
            <p>
                Para obtener más información sobre este sistema, visite <a href="http://totalcom.cr/">http://totalcom.cr/</a>.
                La página incluye los contactos necesarios para ayudarle a sacar el máximo partido su aplicación.
                Si tiene alguna pregunta relacionada con este sistema no dude en localizarnos.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Ventajas de su nuevo aplicavo:</h3>
    <ol class="round">
        <li class="one">
            <h5>Compatibilidad multiplataforma</h5>
           Las aplicaciones web tienen un camino mucho más sencillo para la compatibilidad multiplataforma que las aplicaciones de software descargables.
        </li>
        <li class="two">
            <h5>Inmediatez de acceso.</h5>
          Las aplicaciones basadas en web no necesitan ser descargadas, instaladas y configuradas. Usted accede a su cuenta online  trabajar sin importar cuál es su configuración o su hardware.
        </li>
        <li class="three">
            <h5>Menos Bugs.</h5>
            Las aplicaciones basadas en web deberán ser menos propensas a colgarse y crear problemas técnicos debido a software o conflictos de hardware con otras aplicaciones existentes, protocolos o software personal interno. Con aplicaciones basadas en web, todos utilizan la misma versión, y todos los bugs pueden ser corregidos tan pronto como son descubiertos.
        </li>
    </ol>
</asp:Content>
