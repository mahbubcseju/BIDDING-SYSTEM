using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BidWeb
{
    public partial class MyBoughtList1 : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = Session["UserName"].ToString();

            var myBoughtList = db.MyBoughtLists.Where(x => x.UserName == userName).Select(x => x).ToList();
            myBoughtListGridView.DataSource = myBoughtList;
            myBoughtListGridView.DataBind();
            userNameLabel.Text = "Hello" + Session["UserName"].ToString();
        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Response.Redirect("HomePage.aspx");
        }
    }
}