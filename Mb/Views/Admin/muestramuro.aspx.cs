using Mb.DAO;
using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.MuroController;

namespace Mb.Views.Admin
{
    public partial class muestramuro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CrearMuro();
            }
        }

        private void CrearMuro()
        {
            this.Repeater1.DataSource = GetData();
            this.Repeater1.DataBind();
        }
        private DataTable GetData()
        {

            string dbConnect = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            using (SqlConnection con = new SqlConnection(dbConnect))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Distinct(mm.id), [titulo], [mensaje], mm.fecha fecha,apu.Email email, apu.UserName usuario, me.numero " +
                    " nummesa,ISNULL(mm.confoto,'') confoto, ISNULL(mm.nombrefoto,'') nombrefoto FROM [MensajeMuro] mm INNER JOIN AspNetUsers apu ON mm.UserId = " +
                    " apu.Id INNER JOIN UserMesa um ON um.UserId = apu.Id INNER JOIN Mesa me ON um.IdMesa = me.Id" +
                    " Where mm.reportado=0 Order by fecha desc"))
                    //Muestra mensajes aprobados Aprobado Si reportado esta en True no lo muestra
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }



    }
}