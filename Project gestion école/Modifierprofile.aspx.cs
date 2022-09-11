using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_gestion_école
{
    public partial class Modifierprofile : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(codeEns) from Enseignant where codeEns='" + Session["username"] + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            return cpt;
        }
        public void list()
        {
            p.connecter();
            if (p.ds.Tables["ens"] != null)
            {
                p.ds.Tables["ens"].Clear();
            }

            p.dap = new System.Data.SqlClient.SqlDataAdapter("select * from Enseignant where login= "+Session["username"], p.con);
            p.dap.Fill(p.ds, "ens");
            GridView1.DataSource = p.ds.Tables["ens"];
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
            else
            {
                if (!Page.IsPostBack)
                {
                    list();
                    DropDownList2.Items.Add("dev");
                    DropDownList2.Items.Add("commerce");
                    DropDownList2.Items.Add("entreprise");

                }
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (nombre() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("update Enseignant set nom='" + TextBox2.Text + "',prénom='" + TextBox3.Text + "',adresse='" + TextBox4.Text + "',date_naissance='" + Calendar1.SelectedDate.ToShortDateString() + "',diplôme='" + TextBox5.Text + "',grade='" + TextBox6.Text + "',dateembauche='" + Calendar2.SelectedDate.ToShortDateString() + "',CNE='" + TextBox7.Text + "',spécialité='" + DropDownList2.Text + "',tel='" + TextBox8.Text + "',email='" + TextBox9.Text + "',Login='" + TextBox10.Text + "',Motdepasse='" + TextBox11.Text + "' where Login='" + Session["username"] + "'", p.con);
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
            TextBox2.Text ="";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int r = e.NewSelectedIndex;
                TextBox2.Text = GridView1.Rows[r].Cells[3].Text;
                TextBox3.Text = GridView1.Rows[r].Cells[4].Text;
                TextBox4.Text = GridView1.Rows[r].Cells[5].Text;
                TextBox5.Text = GridView1.Rows[r].Cells[7].Text;
                TextBox6.Text = GridView1.Rows[r].Cells[8].Text;
                TextBox7.Text = GridView1.Rows[r].Cells[10].Text;
                DropDownList2.SelectedItem.Text = GridView1.Rows[r].Cells[11].Text;
                TextBox8.Text = GridView1.Rows[r].Cells[12].Text;
                TextBox9.Text = GridView1.Rows[r].Cells[13].Text;
                TextBox10.Text = GridView1.Rows[r].Cells[14].Text;
                TextBox11.Text = GridView1.Rows[r].Cells[15].Text;
            }
            catch
            {

            }
        }
    }
}