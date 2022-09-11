<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Project_gestion_école.home" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <meta name="description" content=""/>
  <meta name="author" content=""/>

  <title>HOME</title>

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
                  <a href="impressionnotes.aspx" class="list-group-item list-group-item-action bg-light">impressionnotes</a>
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
            </li>
            <li class="nav-item active">
              <a class="nav-link" href="Comptes.aspx">LOGIN <span class="sr-only">(current)</span></a>
            </li>
          </ul>
        </div>
      </nav>
      <div class="container-fluid">
        <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
    <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
          <img class="first-slide" src="img/50.jpg"  alt="First slide" width:"100%" height:"550 PX"/>
      <div class="carousel-caption d-none d-md-block">
          <h5>GDS-العربية</h5>
          <p>                         مرحبا بكم في      </p>
            <p>                                GDS</p>
            <p>   .نحن مؤسسة تعليمية نقوم بتدريب الشباب من أجل سوق الشغل</p>
      </div>
    </div>
    <div class="carousel-item">
          <img class="first-slide" src="img/60.jpg"  alt="First slide" width:"100%" height:"550 PX"/>
      <div class="carousel-caption d-none d-md-block">
        <h5>GDS-francais</h5>
        <p>Bienvenue chez GDS Nous sommes un établissement d'enseignement qui forme les jeunes  au marché .</p>
      </div>
    </div>
    <div class="carousel-item">
          <img class="first-slide" src="img/40.jpg"  alt="First slide" width:"100%" height:"550 PX"/>
      <div class="carousel-caption d-none d-md-block">
        <h5>GDS-english</h5>
        <p>Welcome to GDS We are an educational institution that trains young people for the market.</p>
      </div>
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
</div>
<div>

</div></div>
    </div>
    <!-- /#page-content-wrapper -->

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

    </form>
</body>
</html>

