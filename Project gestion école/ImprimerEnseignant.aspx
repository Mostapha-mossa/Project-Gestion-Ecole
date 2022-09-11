<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimerEnseignant.aspx.cs" Inherits="Project_gestion_école.ImprimerEnseignant" %>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <meta name="description" content=""/>
  <meta name="author" content=""/>

  <title>Simple Sidebar - Start Bootstrap Template</title>

  <!-- Bootstrap core CSS -->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

  <!-- Custom styles for this template -->
  <link href="css/simple-sidebar.css" rel="stylesheet"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex" id="wrapper">

    <!-- Sidebar -->
    <div class="bg-light border-right" id="sidebar-wrapper">
      <div class="sidebar-heading">gestion de stageres OFPPT  </div>
      <div class="list-group list-group-flush">
        <a href="classe.aspx" class="list-group-item list-group-item-action bg-light">Classe</a>
        <a href="Enseignant.aspx" class="list-group-item list-group-item-action bg-light">Enseignant</a>
        <a href="Enseignantmatiereaffectation.aspx" class="list-group-item list-group-item-action bg-light">Enseignantmatiereaffectation</a>
        <a href="Etudiant.aspx" class="list-group-item list-group-item-action bg-light">Etudiant</a>
        <a href="Filiere.aspx" class="list-group-item list-group-item-action bg-light">Filiere</a>
                  <a href="impressionnotes.aspx" class="list-group-item list-group-item-action bg-light">impression notes</a>
                              <a href="IMPRESSIONCLASSE.aspx" class="list-group-item list-group-item-action bg-light">IMPRESSION  CLASSE</a>
                     <a href="ImprimerFilière.aspx" class="list-group-item list-group-item-action bg-light">IMPRESSION  Filière</a>
                     <a href="ImprimerEnseignant.aspx" class="list-group-item list-group-item-action bg-light">IMPRESSION  Enseignant</a>
       <a href="InscriptionEtudiantGroup.aspx" class="list-group-item list-group-item-action bg-light">InscriptionEtudiantGroup</a>
       <a href="Matiere.aspx" class="list-group-item list-group-item-action bg-light">Matiere</a>
        <a href="Secteur.aspx" class="list-group-item list-group-item-action bg-light">Secteur</a>
          <a href="Niveau.aspx" class="list-group-item list-group-item-action bg-light">Niveau</a>


      </div>
    </div>
    <!-- /#sidebar-wrapper -->

    <!-- Page Content -->
    <div id="page-content-wrapper">

      <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
        <button class="btn btn-primary" id="menu-toggle">Toggle Menu</button>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav ml-auto mt-2 mt-lg-0">
            <li class="nav-item active">
              <a class="nav-link" href="home.aspx">Home <span class="sr-only">(current)</span></a>
            
            <li class="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                My Comptes
              </a>
              <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown">
                <a class="dropdown-item" href="feedback.aspx">Send feedback</a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" href="logoit.aspx">logoit</a>
              </div>
            </li>
          </ul>
        </div>
      </nav>

      <div class="container-fluid">
        <h1 class="mt-4">impressionnotes</h1>
       
<div>

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" />

</div></div>
    </div>
    <!-- /#page-content-wrapper -->

  </div>
  <!-- /#wrapper -->

  <!-- Bootstrap core JavaScript -->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Menu Toggle Script -->
  <script>
    $("#menu-toggle").click(function(e) {
      e.preventDefault();
      $("#wrapper").toggleClass("toggled");
    });
  </script>

        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="CrystalReportEnseignant.rpt">
            </Report>
        </CR:CrystalReportSource>

    </form>
</body>
</html>

