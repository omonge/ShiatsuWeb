<%@ Page Title="Contacto" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="ShiatsuWeb.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Su página de contacto.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Teléfono:</h3>
        </header>
        <p>
            <span class="label">Principal:</span>
            (+506) 4000-3622
        </p>
        <p>
            <span class="label">Fuera del horario laboral:</span> (+506) 4000-3622</p>
    </section>

    <section class="contact">
        <header>
            <h3>Correo electrónico:</h3>
        </header>
        <p>
            <span class="label">Soporte técnico: </span><a href="mailto:msalamancaa@totalcom.cr">msalamancaa@totalcom.cr</a>
        <p>
            <span class="label">Marketing:</span> <a href="mailto:lguillenh@totalcom.cr">lguillenh@totalcom.cr</a>
        </p>
        <p>
            <span class="label">General:</span><a href="mailto:jmongeu@totalcom.cr">jmongeu@totalcom.cr</a>
        </p>
    </section>

    <section class="contact"><header>
            <h3>Dirección:</h3>  
        </header>    
          <p> 
Avenida 10, Calle 6</br>
San José, Costa Rica
        </p>
    </section>
</asp:Content>