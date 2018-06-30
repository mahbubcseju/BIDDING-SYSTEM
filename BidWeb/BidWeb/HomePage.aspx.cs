using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BidWeb
{
    public partial class HomePage : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UserName"] as string))
            {
                userNameLabel.Text = "Hello " + Session["UserName"].ToString();
                registerLabel.Text = "";
                loginLabel.Text = "";
                registerLabel.Visible = false;
                loginLabel.Visible = false;
                logoutButton.Visible = true;
                menuLabel.Visible = true;
            }
            else
            {
                menuLabel.Visible = false;
                registerLabel.Visible = true;
                loginLabel.Visible = true;
                logoutButton.Visible = false;
                registerLabel.Text = "Register";
                loginLabel.Text = "Login";
            }
        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Response.Redirect("HomePage.aspx");
        }

        protected void loginButton_OnClick(object sender, EventArgs e)
        {
            var userName = userNameTextBox.Text;
            var pass = db.UserInfoes.Where(x => x.UserName == userName).Select(x => x.Password).ToList().LastOrDefault();
            if (pass == passwordTextBox.Text)
            {
                Session["UserName"] = userName;
                Response.Redirect("Menu.aspx");
            }
            else
            {
                Response.Write("Plz Check ur Password!!!");
            }
        }
    }
}