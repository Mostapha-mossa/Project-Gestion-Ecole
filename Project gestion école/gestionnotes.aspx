<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionnotes.aspx.cs" Inherits="Project_gestion_école.gestionnotes" %>


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
        
        <a href="gestionnotes.aspx" class="list-group-item list-group-item-action bg-light">gestionnotes</a>
        <a href="listdeclasse.aspx" class="list-group-item list-group-item-action bg-light">list de classe</a>
          <a href="Saisirabsences.aspx" class="list-group-item list-group-item-action bg-light">Saisir absences</a>
          <a href="Modifierprofile.aspx" class="list-group-item list-group-item-action bg-light">Modifier mon profile</a>

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
                <a class="dropdown-item" href="Modifierprofile.aspx">profile</a>
                <a class="dropdown-item" href="feedback.aspx">Send feedback</a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" href="logoit.aspx">logoit</a>
              </div>
            </li>
          </ul>
        </div>
      </nav>

      <div class="container-fluid">
        <h1 class="mt-4">gestionnotes</h1>
        <div>
            <tr>
                <td class="text-right">Donnez Le Code du Note:</td>
                <td>
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" ></asp:TextBox>
                </td>
            </tr>
        <tr>
                <td class="text-right">Selectionner le Secteur :</td>
                <td>
                    <asp:DropDownList ID="DropDownList" CssClass="form-control" runat="server" AutoPostBack="True">
        </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td class="text-right">Choiser la Filière :</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="nomFiliere" DataValueField="codeF">
        </asp:DropDownList>
                </td>
            </tr> 
        <tr>
                <td class="text-right">Choiser la Classe :</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="nomclasse" DataValueField="codeC">
        </asp:DropDownList>
                </td>
            </tr> 
                  <tr>
                <td class="text-right">Choiser l'Etudiant :</td>
                <td>
                    <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource3" DataTextField="Nom Complete" DataValueField="NumInscription">
        </asp:DropDownList>
                </td>
            </tr> 
        <tr>
                <td class="text-right">Donnez la note annuelle (/60):</td>
                <td>
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" ></asp:TextBox>
                </td>
            </tr>
        <tr>
                <td class="text-right">Donnez la note du Passage (/20):</td>
                <td>
                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" ></asp:TextBox>
                </td>
            </tr>
        <tr>
                <td class="text-right">Donnez Note synthèse (/100):</td>
                <td>
                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" ></asp:TextBox>
                </td>
            </tr>
        <tr>
                <td class="text-right">Moyenne Générale (/20):</td>
                <td>
                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" ></asp:TextBox> &nbsp;&nbsp; 
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td><br />
        <asp:Button ID="Button4" runat="server" Text="Calculer" class="btn-success" OnClick="Button4_Click"  />
        <asp:Button ID="Button1" runat="server" Text="Ajouter" class="btn-success" OnClick="Button1_Click"  />
        <asp:Button ID="Button3" runat="server" Text="Modifier" class="btn-success" OnClick="Button3_Click"  />
        <asp:Button ID="Button2" runat="server" Text="Nouveau" class="btn-danger" OnClick="Button2_Click" />
        

                </td>
            </tr>
               &nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    <div>
        <div>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="100%"    ForeColor="#333333" AutoGenerateSelectButton="True" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Width="10%"/>
                <Columns>
                    <asp:CommandField ButtonType="Button" ControlStyle-BackColor="#F0F8FF" HeaderStyle-Width="10%" FooterStyle-Width="10%" ShowDeleteButton="True">
                    <ControlStyle BackColor="AliceBlue"></ControlStyle>
                    <FooterStyle Width="10%"></FooterStyle>
                    <HeaderStyle Width="10%"></HeaderStyle>
                    <ItemStyle Width="10%" />
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:projcoleConnectionString %>" SelectCommand="SELECT Filière.* FROM Filière INNER JOIN Secteur ON Filière.CodeSecteur = Secteur.CodeSecteur WHERE (Secteur.CodeSecteur = @codesecteur)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList" Name="codesecteur" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:projcoleConnectionString %>" SelectCommand="SELECT Classe.*, Filière.codeF FROM Classe INNER JOIN Filière ON Classe.codefilière = Filière.codeF WHERE (Filière.codeF = @codef)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="codef" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:projcoleConnectionString %>" SelectCommand="select Etudiant.nom+' '+Etudiant.prénom as [Nom Complete], Etudiant.* from Etudiant,Inscription,Classe where Etudiant.NumInscription=Inscription.NumInscription and Inscription.code_Classe=Classe.codeC and Classe.codeC=@codecla">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList2" Name="codecla" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>

<div>

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

    </form>
</body>
</html>


