using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_gestion_école
{
    public partial class Matiere : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(codeM) from Matière where codeM='" + TextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            return cpt;
        }
        public void list()
        {
            p.connecter();
            if (p.ds.Tables["mat"] != null)
            {
                p.ds.Tables["mat"].Clear();
            }

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select Matière.codeM,Matière.nom_Mat,Matière.Nombreheure,Filière.nomFiliere from Matière,Filière where Filière.codeF=Matière.codeFili", p.con);
            p.dap.Fill(p.ds, "mat");
            GridView1.DataSource = p.ds.Tables["mat"];
            GridView1.DataBind();
            p.deconnecter();
        }
        public void filiere()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Filière", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            DropDownList.DataSource = p.dt;
            DropDownList.DataTextField = "nomFiliere";
            DropDownList.DataValueField = "codeF";
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
                    filiere();
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (nombre() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Matière values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + DropDownList.SelectedValue + "')", p.con);
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
            if (nombre() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("update Matière set nomMat='" + TextBox2.Text + "',Nombreheure='" + TextBox3.Text + "',codeFili='" + DropDownList.SelectedValue + "' where codeM='" + TextBox1.Text + "'", p.con);
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int r = e.NewSelectedIndex;
                TextBox1.Text = GridView1.Rows[r].Cells[2].Text;
                TextBox2.Text = GridView1.Rows[r].Cells[3].Text;
                TextBox3.Text = GridView1.Rows[r].Cells[4].Text;
                DropDownList.SelectedItem.Text = GridView1.Rows[r].Cells[5].Text;
            }
            catch
            {

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = Convert.ToInt32(GridView1.Rows[a].Cells[2].Text);
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("delete from Matière where codeM='" + code + "'", p.con);
            p.cmd.ExecuteNonQuery();
            list();
            p.deconnecter();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }
}