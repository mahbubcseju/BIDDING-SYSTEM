using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BidWeb
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(Session["UserName"] as string))
            {
                userNameLabel.Text ="Hello "+ Session["UserName"].ToString();
                registerLabel.Visible = false;
            }
            
        }

        protected void addItemButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");
        }

        protected void viewAllItemButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllItem.aspx");
        }

        protected void viewMyItemButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewMyItem.aspx");
        }

        protected void myBidingListButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("MyProductBidingList.aspx");
        }

        protected void myBuyingItemButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("MyBoughtList.aspx");
        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Response.Redirect("HomePage.aspx");
        }
    }
}