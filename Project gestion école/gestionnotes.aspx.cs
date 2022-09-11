using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project_gestion_école
{
    public partial class gestionnotes : System.Web.UI.Page
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

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select distinct Notes.CodeNote as [Code],secteur.nomSecteur as [Secteur],Filière.nomFiliere as [Filiere],Classe.nom_classe as [Classe],Etudiant.nom+' '+Etudiant.prénom as [Nom Complete],Notes.NoteAnnee as [La Note Annuelle],Notes.NotePassage as [La Note de Passage],Notes.NoteEpreuve as [Note du Fin Formation],Notes.Notegeneral as [Moyenne générale] from Notes,Secteur,Filière,Classe,Etudiant,Inscription where Notes.CodeSecteur=Secteur.CodeSecteur and Notes.codeF=Filière.codeF and Notes.code_Classe=Classe.codec and Notes.NumInscription=Etudiant.NumInscription", p.con);
            p.dap.Fill(p.ds, "note");
            GridView1.DataSource = p.ds.Tables["note"];
            GridView1.DataBind();
            p.deconnecter();
        }
        public void sec()
        {
            p.connecter();
            string x;
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Secteur", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            DropDownList.DataSource = dt1;
            DropDownList.DataTextField = "nomSecteur";
            DropDownList.DataValueField = "CodeSecteur";
            DropDownList.DataBind();
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
            else
            {
                if (!Page.IsPostBack)
                {
                    list();
                    sec();

                }
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (nombre() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Notes values ('" + TextBox1.Text + "','" + DropDownList.SelectedValue + "','" + DropDownList1.SelectedValue + "','" + DropDownList2.SelectedValue + "','" + DropDownList3.SelectedValue + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                Label1.Text = "Resultat Bien Ajouter";
                list();
                Label1.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                p.deconnecter();
                Label1.Text = "Resultat Existe Deja";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            double note1 = double.Parse(TextBox2.Text);
            double note2 = double.Parse(TextBox3.Text);
            double note3 = double.Parse(TextBox4.Text);
            double general = (note1 + note2 + note3) / 9;
            string gene = general.ToString("0.00");
            TextBox5.Text = gene;

        }


    }
}