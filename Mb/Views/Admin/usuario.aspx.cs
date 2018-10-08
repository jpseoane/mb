using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mb.DAO;



namespace Mb.Views.Admin
{
    public partial class usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                //using (Model = new Models())
                //    {
                //        return entities.Employees.ToList();
                //  }

                    //[HttpGet]
                    //public IEnumerable<Employees> Get()
                    //{
                    //    using (EmployeeDBEntities entities = new EmployeeDBEntities())
                    //    {
                    //        return entities.Employees.ToList();
                    //    }
                    //}

            }
        }
    }
}