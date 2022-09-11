using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project_gestion_école
{
    public partial class Saisirabsences : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(NumInscription) from Absence where NumInscription='" + DropDownList.SelectedValue + "' and codeM='"+ DropDownList1.SelectedValue + "'", p.con);
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

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select * from Absence ", p.con);
            p.dap.Fill(p.ds, "note");
            GridView1.DataSource = p.ds.Tables["note"];
            GridView1.DataBind();
            p.deconnecter();
        }
        public void sec1()
        {
            p.connecter();
            string x;
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Etudiant", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            DropDownList.DataSource = dt1;
            DropDownList.DataTextField = "prénom";
            DropDownList.DataValueField = "NumInscription";
            DropDownList.DataBind();
            p.deconnecter();
        }
        public void sec2()
        {
            p.connecter();
            string x;
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Matière", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(p.dr);
            DropDownList.DataSource = dt2;
            DropDownList.DataTextField = "nom_Mat";
            DropDownList.DataValueField = "codeM";
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
                    sec1();
                    sec2();
                }

            }
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (nombre() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Absence values ('" + DropDownList.SelectedValue + "','" + DropDownList1.SelectedValue + "','" + Calendar1.SelectedDate.ToShortDateString() + "'," + int.Parse(TextBox1.Text) + ")", p.con); 
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
                p.cmd = new System.Data.SqlClient.SqlCommand("update Absence set dateAbsence='"+ Calendar1.SelectedDate.ToShortDateString() + "' Nombreheure=" + TextBox1.Text + " where NumInscription='" + DropDownList.SelectedValue + "' and codeM='" + DropDownList1.SelectedValue + "'", p.con);
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
            TextBox1.Text="";
        }
    }
}