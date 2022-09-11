using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_gestion_école
{
    public partial class listdeclasse : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(CodeNote) from Notes where CodeNote='" + TextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            return cpt;
        }
        public void list()
        {
            p.connecter();
            if (p.ds.Tables["note"] != null)
            {
                p.ds.Tables["note"].Clear();
            }

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select distinct  Etudiant.NumInscription, Etudiant.nom, Etudiant.prénom, Etudiant.adresse, Etudiant.date_de_naissance, Etudiant.diplôme, Etudiant.email, Etudiant.tel from Notes,Secteur,Filière,Classe,Etudiant,Inscription where Notes.CodeSecteur=Secteur.CodeSecteur and Notes.codeF=Filière.codeF and Notes.code_Classe=Classe.codec and Notes.NumInscription=Etudiant.NumInscription and Classe.nom_classe='"+TextBox1.Text+"'", p.con);
            p.dap.Fill(p.ds, "note");
            GridView1.DataSource = p.ds.Tables["note"];
            GridView1.DataBind();
            p.deconnecter();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            { Response.Redirect("Comptes.aspx"); }
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(Login) from Etudiant where Login='" + Session["username"] + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();

            if (cpt != 0)
            {
                Response.Redirect("test.aspx");
            }
          
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            list();
        }
    }
}