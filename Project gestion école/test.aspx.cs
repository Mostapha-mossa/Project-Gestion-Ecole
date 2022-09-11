using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_gestion_école
{
    public partial class test : System.Web.UI.Page
    {
        MOS p = new MOS();
       
        public void list()
        {
            p.connecter();
            if (p.ds.Tables["note"] != null)
            {
                p.ds.Tables["note"].Clear();
            }

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select distinct Notes.CodeNote as [Code],secteur.nomSecteur as [Secteur],Filière.nomFiliere as [Filiere],Classe.nom_classe as [Classe],Etudiant.nom+' '+Etudiant.prénom as [Nom Complete],Notes.NoteAnnee as [La Note Annuelle],Notes.NotePassage as [La Note de Passage],Notes.NoteEpreuve as [Note du Fin Formation],Notes.Notegeneral as [Moyenne générale] from Notes,Secteur,Filière,Classe,Etudiant,Inscription where Notes.CodeSecteur=Secteur.CodeSecteur and Notes.codeF=Filière.codeF and Notes.code_Classe=Classe.codec and Notes.NumInscription=Etudiant.NumInscription AND Etudiant.Login='"+Session["username"]+"'",p.con);
            p.dap.Fill(p.ds, "note");
            GridView1.DataSource = p.ds.Tables["note"];
            GridView1.DataBind();
            p.deconnecter();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            { Response.Redirect("Comptes.aspx"); }
           
                if (!Page.IsPostBack)
                {
                    list();

                }
            
            
        }

       

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}