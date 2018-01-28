using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Areas.Admin.Models;

namespace ConstructionLK.Areas.Admin.Controllers
{
    public class UserCountChartController : Controller
    {
        public static DataTable GetUserCount()
        {

            DataTable dt = new DataTable();
            string query =
                "SELECT 'Customers' AS Users, Count(*) AS Val FROM Customers UNION SELECT 'Service Providers' AS Users, Count(*) AS Val FROM ServiceProviders";
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
        public JsonResult UserCount()
        {
            List<UserCount> lstSummary = new List<UserCount>();

            foreach (DataRow dr in GetUserCount().Rows)
            {
                UserCount summary = new UserCount();
                //summary.Item = dr[0].ToString().Trim();
                //summary.Value = Convert.ToInt32(dr[1]);
                summary.Item = dr[0].ToString();
                summary.Value = Convert.ToInt32(dr[1]);
                lstSummary.Add(summary);

            }
            return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/UserCountChart
        public ActionResult Index()
        {
            return PartialView("UserCountChart");
        }
    }
}