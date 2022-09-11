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
    public partial class ImprimerEnseignant : System.Web.UI.Page
    {
        MOS p = new MOS();
        notes nt = new notes();
        ReportDocument rpt = new ReportDocument();
      
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
                    p.connecter();
                    CrystalReportEnseignant cr = new CrystalReportEnseignant();
                    p.cmd = new System.Data.SqlClient.SqlCommand("exec p3 " , p.con);
                    p.dap = new System.Data.SqlClient.SqlDataAdapter(p.cmd);
                    DataTable dt2 = new DataTable();
                    p.dap.Fill(dt2);
                    rpt.Load(Server.MapPath("CrystalReportEnseignant.rpt"));
                    rpt.SetDataSource(dt2);

                    cr.SetDataSource(dt2);
                    CrystalReportViewer1.ReportSource = rpt;
                    CrystalReportViewer1.DataBind();
                    p.deconnecter();
                }
            }
        }
    }
}