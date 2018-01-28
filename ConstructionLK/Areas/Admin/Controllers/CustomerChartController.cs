using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using ConstructionLK.Areas.Admin.Models;
using ConstructionLK.Models;

namespace ConstructionLK.Areas.Admin.Controllers
{
    public class CustomerChartController : Controller
    {
        public static DataTable GetCustomerSummary()
        {

            DataTable dt = new DataTable("Customers");
            string query =
                "SELECT count(*) AS Number, MONTH(CreatedDate) Month FROM Customers GROUP BY MONTH(CreatedDate)";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["Azure"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        [HttpGet]
        public JsonResult CustomerSummary()
        {
            List<RegChart> lstSummary = new List<RegChart>();

            foreach (DataRow dr in GetCustomerSummary().Rows)
            {
                RegChart summary = new RegChart();
                //summary.Item = dr[0].ToString().Trim();
                //summary.Value = Convert.ToInt32(dr[1]);
                summary.Item = dr["Month"].ToString();
                summary.Value = Convert.ToInt32(dr["Number"]);
                lstSummary.Add(summary);

            }
            return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}