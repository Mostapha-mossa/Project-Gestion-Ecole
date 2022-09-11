using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_gestion_école
{
    public partial class classe : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(codeC) from Classe where codeC='" + TextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            return cpt;
        }
        public void list()
        {
            p.connecter();
            if (p.ds.Tables["cl"] != null)
            {
                p.ds.Tables["cl"].Clear();
            }

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select Classe.codeC,Classe.nom_classe,Filière.nomFiliere from classe,Filière where Classe.codefilière=Filière.codeF", p.con);
            p.dap.Fill(p.ds, "cl");
            GridView1.DataSource = p.ds.Tables["cl"];
            GridView1.DataBind();
            p.deconnecter();
        }
        public void fil()
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
            else {
                if (!Page.IsPostBack)
            {
                list();
                fil();
            }}
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (nombre() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Classe values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList.SelectedValue + "')", p.con);
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int r = e.NewSelectedIndex;
                TextBox1.Text = GridView1.Rows[r].Cells[2].Text;
                TextBox2.Text = GridView1.Rows[r].Cells[3].Text;
                DropDownList.Text = GridView1.Rows[r].Cells[4].Text;
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
            p.cmd = new System.Data.SqlClient.SqlCommand("delete from Classe where codeC='" + code + "'", p.con);
            p.cmd.ExecuteNonQuery();
            list();
            p.deconnecter();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (nombre() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("update Classe set nomclasse='" + TextBox2.Text + "',codefilière='" + DropDownList.SelectedValue + "' where codeC='" + TextBox1.Text + "'", p.con);
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = Convert.ToInt32(GridView1.Rows[a].Cells[2].Text);
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("delete from Classe where codeC='" + code + "'", p.con);
            p.cmd.ExecuteNonQuery();
            list();
            p.deconnecter();
        }

        protected void GridView1_SelectedIndexChanging1(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int r = e.NewSelectedIndex;
                TextBox1.Text = GridView1.Rows[r].Cells[2].Text;
                DropDownList.Text = GridView1.Rows[r].Cells[3].Text;
            }
            catch
            {

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}