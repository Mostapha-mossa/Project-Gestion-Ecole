using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project_gestion_école
{
    public partial class Filiere : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(codeF) from Filière where codeF='" + TextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            return cpt;
        }
        public void list()
        {
            p.connecter();
            if (p.ds.Tables["fil"] != null)
            {
                p.ds.Tables["fil"].Clear();
            }

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select Filière.codeF,Filière.nomFiliere,Niveau.nomNiveau,Secteur.nomSecteur from Filière,Niveau,Secteur where Filière.codeNiveau=Niveau.codeNiveau and Filière.CodeSecteur=Secteur.CodeSecteur", p.con);
            p.dap.Fill(p.ds, "fil");
            GridView1.DataSource = p.ds.Tables["fil"];
            GridView1.DataBind();
            p.deconnecter();
        }
        public void niveau()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Niveau", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            DropDownList1.DataSource = p.dt;
            DropDownList1.DataTextField = "nomNiveau";
            DropDownList1.DataValueField = "codeNiveau";
            DropDownList1.DataBind();
            p.deconnecter();
        }
        //
        public void Secteur()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Secteur", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);

            DropDownList2.DataSource = dt1;
            DropDownList2.DataTextField = "nomSecteur";
            DropDownList2.DataValueField = "CodeSecteur";
            DropDownList2.DataBind();
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
                    niveau();
                    Secteur();
                    DropDownList.Items.Add("Technicien Specialise en Commerce");
                    DropDownList.Items.Add("Technicien Specialise en Gestion des Entreprises");
                    DropDownList.Items.Add("Technique de Secretariat de Direction");
                    DropDownList.Items.Add("Techniques de Developpement Informatique");
                    DropDownList.Items.Add("Techniques des Reseaux Informatiques");
                    DropDownList.Items.Add("Technicien Specialise Gros Oeuvres");
                }
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (nombre() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Filière values ('" + TextBox1.Text + "','" + DropDownList.Text + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "')", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                Label1.Text = "Bien Ajouter";
                list();
                Label1.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                p.deconnecter();
                Label1.Text = "Existe Deja";
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
            try
            {
                int r = e.NewSelectedIndex;
                TextBox1.Text = GridView1.Rows[r].Cells[2].Text;
                DropDownList.SelectedItem.Text = GridView1.Rows[r].Cells[3].Text;
                DropDownList1.SelectedItem.Text = GridView1.Rows[r].Cells[4].Text;
                DropDownList2.SelectedItem.Text = GridView1.Rows[r].Cells[5].Text;
            }
            catch
            {

            }
        }

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = Convert.ToInt32(GridView1.Rows[a].Cells[2].Text);
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("delete from Filière where codeF='" + code + "'", p.con);
            p.cmd.ExecuteNonQuery();
            list();
            p.deconnecter();
        }


    }
}