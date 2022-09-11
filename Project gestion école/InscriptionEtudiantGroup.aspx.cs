using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project_gestion_école
{
    public partial class InscriptionEtudiantGroup : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(CodeInscription) from Inscription where CodeInscription='" + TextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            return cpt;
        }
        public void list()
        {
            p.connecter();
            if (p.ds.Tables["insc"] != null)
            {
                p.ds.Tables["insc"].Clear();
            }

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select Inscription.NumInscription,Etudiant.nom+' '+Etudiant.prénom as [Nom Complete],Filière.nomFiliere,Classe.nom_classe,CONVERT(VARCHAR(10), Inscription.DateInscription, 103) as [Date d'Inscription]  from Inscription,Etudiant,Filière,Classe where Etudiant.NumInscription=Inscription.NumInscription and Classe.codeC=Inscription.codeClasse and Filière.codeF=Classe.codefilière", p.con);
            p.dap.Fill(p.ds, "aff");
            GridView1.DataSource = p.ds.Tables["aff"];
            GridView1.DataBind();
            p.deconnecter();
        }
        public void etud()
        {
            p.connecter();
            string x;
            p.cmd = new System.Data.SqlClient.SqlCommand("select nom+' '+prénom as [Nom Complete],NumInscription from Etudiant", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            DropDownList1.DataSource = p.dt;
            DropDownList1.DataTextField = "Nom Complete";
            DropDownList1.DataValueField = "NumInscription";
            DropDownList1.DataBind();
            p.deconnecter();
        }
        public void fil()
        {
            p.connecter();
            string x;
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Filière", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            DropDownList2.DataSource = dt1;
            DropDownList2.DataTextField = "nomFiliere";
            DropDownList2.DataValueField = "codeF";
            DropDownList2.DataBind();
            p.deconnecter();
        }
        public void cla()
        {
            p.connecter();
            string x;
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Classe", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(p.dr);
            DropDownList3.DataSource = dt2;
            DropDownList3.DataTextField = "nomclasse";
            DropDownList3.DataValueField = "codeC";
            DropDownList3.DataBind();
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
            int zcpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(Login) from Enseignant where Login='" + Session["username"] + "'", p.con);
            zcpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            if (zcpt != 0)
            {
                Response.Redirect("gestionnotes.aspx");
            }
            if (cpt != 0)
            {
                Response.Redirect("test.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    list();
                    etud();
                    fil();

                }
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (nombre() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Inscription (CodeInscription,NumInscription,code_Classe,DateInscription) values ('" + TextBox1.Text + "','" + DropDownList1.SelectedValue + "','" + DropDownList2.SelectedValue + "','" + DateTime.Now.ToShortDateString() + "')", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                Label1.Text = "Affectation Bien Effectué!";
                list();
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label1.Text = "l'étudiant deja inscrit!";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (nombre() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("update Inscription set NumInscription='" + DropDownList1.SelectedValue + "',code_Classe='" + DropDownList3.SelectedValue + "' where Inscription.CodeInscription='" + TextBox1.Text + "'", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                Label1.Text = "Bien Modifier";
                list();
                Label1.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                p.deconnecter();
                Label1.Text = "N'existe Pas!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Enabled = true;
            TextBox1.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int r = e.NewSelectedIndex;
                TextBox1.Text = GridView1.Rows[r].Cells[2].Text;
                DropDownList1.SelectedItem.Text = GridView1.Rows[r].Cells[3].Text;
                DropDownList2.SelectedItem.Text = GridView1.Rows[r].Cells[4].Text;
                DropDownList3.SelectedItem.Text = GridView1.Rows[r].Cells[5].Text;
                TextBox1.Enabled = false;
            }
            catch
            {

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = Convert.ToInt32(GridView1.Rows[a].Cells[2].Text);
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("delete from Inscription where CodeInscription='" + code + "'", p.con);
            p.cmd.ExecuteNonQuery();
            list();
            p.deconnecter();
        }
    }
}