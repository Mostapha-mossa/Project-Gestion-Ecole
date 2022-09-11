using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Reporting;
using System.Data;

namespace Project_gestion_école
{
    public partial class IMPRESSIONCLASSE : System.Web.UI.Page
    {
        MOS p = new MOS();
        notes nt = new notes();
        ReportDocument rpt = new ReportDocument();
        public void etude()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Classe", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            DropDownList1.DataSource = dt1;
            DropDownList1.DataTextField = "nom_classe";
            DropDownList1.DataValueField = "codeC";
            DropDownList1.DataBind();
            p.dr.Close();
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
                    etude();

                }
            }

        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            p.connecter();
            CrystalReportCLASSE cr = new CrystalReportCLASSE();
            p.cmd = new System.Data.SqlClient.SqlCommand("exec p2 '" + DropDownList1.SelectedValue+"'", p.con);
            p.dap = new System.Data.SqlClient.SqlDataAdapter(p.cmd);
            DataTable dt2 = new DataTable();
            p.dap.Fill(dt2);
            rpt.Load(Server.MapPath("CrystalReportCLASSE.rpt"));
            rpt.SetDataSource(dt2);

            cr.SetDataSource(dt2);
            CrystalReportViewer1.ReportSource = rpt;
            CrystalReportViewer1.DataBind();
            p.deconnecter();
        }
    }
}