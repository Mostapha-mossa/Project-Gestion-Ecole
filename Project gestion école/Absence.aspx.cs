using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_gestion_école
{
    public partial class Absence : System.Web.UI.Page
    {
        MOS p = new MOS();

        public void list()
        {
            p.connecter();
            if (p.ds.Tables["Absence"] != null)
            {
                p.ds.Tables["Absence"].Clear();
            }
            string cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select NumInscription from Etudiant where Login='" + Session["username"] + "'", p.con);
            cpt = (string)p.cmd.ExecuteScalar();
            p.deconnecter();
            p.dap = new System.Data.SqlClient.SqlDataAdapter("select * from Absence where Absence.NumInscription='" + cpt + "'", p.con);
            p.dap.Fill(p.ds, "Absence");
            GridView1.DataSource = p.ds.Tables["Absence"];
            GridView1.DataBind();
            p.deconnecter();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            { Response.Redirect("Comptes.aspx"); }

            if (!Page.IsPostBack)
            {
                list();

            }


        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}