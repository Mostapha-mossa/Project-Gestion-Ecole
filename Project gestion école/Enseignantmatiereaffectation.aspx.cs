using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project_gestion_école
{
    public partial class Enseignantmatiereaffectation : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(CodeAff) from Affectation where CodeAff='" + TextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            return cpt;
        }
        public void list()
        {
            p.connecter();
            if (p.ds.Tables["aff"] != null)
            {
                p.ds.Tables["aff"].Clear();
            }

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select Affectation.codeaff,Enseignant.nom+' '+Enseignant.prénom as [nom],Matière.nomMat,Affectation.dateAffactation  from Affectation,Matière,Enseignant where Enseignant.codeEns=Affectation.codeEns and Affectation.codeM=Matière.codeM", p.con);
            p.dap.Fill(p.ds, "aff");
            GridView1.DataSource = p.ds.Tables["aff"];
            GridView1.DataBind();
            p.deconnecter();
        }
        public void ens()
        {
            p.connecter();
            string x;
            p.cmd = new System.Data.SqlClient.SqlCommand("select nom+' '+prénom as [nom],codeEns from Enseignant", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            DropDownList.DataSource = p.dt;
            DropDownList.DataTextField = "nom";
            DropDownList.DataValueField = "codeEns";
            DropDownList.DataBind();
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
            DropDownList1.DataSource = dt1;
            DropDownList1.DataTextField = "nomFiliere";
            DropDownList1.DataValueField = "codeF";
            DropDownList1.DataBind();
            p.deconnecter();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]==null)
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
                    ens();
                    fil();

                }
            }
          
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                p.connecter();
                string x;
                p.cmd = new System.Data.SqlClient.SqlCommand("select * from Matière,Filière where Matière.codeFili=Filière.codeF and Filière.codeF='" + DropDownList1.SelectedValue + "'", p.con);
                p.dr = p.cmd.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(p.dr);
                DropDownList2.DataSource = dt2;
                DropDownList2.DataTextField = "nomMat";
                DropDownList2.DataValueField = "codeM";
                DropDownList2.DataBind();
                p.deconnecter();
            }
            catch
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (nombre() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Affectation (CodeAff,codeEns,codeM,dateAffactation) values ('" + TextBox1.Text + "','" + DropDownList.SelectedValue + "','" + DropDownList2.SelectedValue + "','" + DateTime.Now.ToShortDateString() + "')", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                Label1.Text = "Bien Ajouter";
                list();
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label1.Text = "Existe Deja!";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (nombre() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("update Affectation set codeEns='" + DropDownList.SelectedValue + "',codeM='" + DropDownList2.SelectedValue + "',dateAffactation='" + DateTime.Now.ToShortDateString() + "' where codeaff='" + TextBox1.Text + "'", p.con);
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
            TextBox1.Text = "";
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int r = e.NewSelectedIndex;
                TextBox1.Text = GridView1.Rows[r].Cells[2].Text;
                DropDownList.SelectedItem.Text = GridView1.Rows[r].Cells[3].Text;

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
            p.cmd = new System.Data.SqlClient.SqlCommand("delete from Affectation where codeaff='" + code + "'", p.con);
            p.cmd.ExecuteNonQuery();
            list();
            p.deconnecter();
        }
    }
}