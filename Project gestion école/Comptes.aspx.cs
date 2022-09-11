using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_gestion_école
{
    public partial class Comptes : System.Web.UI.Page
    {
        MOS p = new MOS();
        public int nombre()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(Login) from Comptes where Login='" + TextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            p.deconnecter();
            return cpt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (nombre() != 0)
            {
                string apt;
                Session["username"] = (string)TextBox1.Text;
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("select Mot_de_passe from Comptes where Login='" + TextBox1.Text + "'", p.con);
                apt = (string)p.cmd.ExecuteScalar();
                p.deconnecter();
                if (apt == TextBox2.Text)
                {
                    int cpt;
                    p.connecter();
                    p.cmd = new System.Data.SqlClient.SqlCommand("select count(Login) from Etudiant where Login='" + TextBox1.Text + "'", p.con);
                    cpt = (int)p.cmd.ExecuteScalar();
                    p.deconnecter();
                   
                    if (cpt != 0)
                    {
                        Response.Redirect("test.aspx"); 
                    }
                    int zcpt;
                    p.connecter();
                    p.cmd = new System.Data.SqlClient.SqlCommand("select count(Login) from Enseignant where Login='" + TextBox1.Text + "'", p.con);
                    zcpt = (int)p.cmd.ExecuteScalar();
                    p.deconnecter();
                    if (zcpt != 0)
                    {
                        Response.Redirect("gestionnotes.aspx");
                    }
                    else { Response.Redirect("classe.aspx"); }
                }
            }
            else
            {
                p.deconnecter();
                Label1.Text = "Connectez-vous avec un mot de passe incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

     
    }
}