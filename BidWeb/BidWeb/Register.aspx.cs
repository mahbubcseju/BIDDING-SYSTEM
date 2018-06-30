using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BidWeb
{
    public partial class Register : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        UserInfo userInfo = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!string.IsNullOrEmpty(Session["UserName"] as string))
            {
                //userNameLabel.Text = "Hello " + Session["UserName"].ToString();
                //registerLabel.Text = "";
                //loginLabel.Text = "";
                //registerLabel.Visible = false;
                //loginLabel.Visible = false;
                //logoutButton.Visible = true;
                //menuLabel.Visible = true;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (db.UserInfoes.Any(x => x.UserName == userNameTextBox.Text))
            {
                Response.Write("<script>alert('The message already exist ! ! !');</script>");
            }
            else
            {
                userInfo.UserName = userNameTextBox.Text;
                userInfo.Password = passwordTextBox.Text;
                userInfo.Email = emailTextBox.Text;
                userInfo.Phone = phoneTextBox.Text;
                userInfo.Country = countryTextBox.Text;
                db.UserInfoes.Add(userInfo);
                db.SaveChanges();
                Response.Write("<script>alert('Registration Complete !!!!');</script>");
            }
        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Response.Redirect("HomePage.aspx");
        }

        protected void loginButton_OnClick(object sender, EventArgs e)
        {
            var userName = TextBox1.Text;
            var pass = db.UserInfoes.Where(x => x.UserName == userName).Select(x => x.Password).ToList().LastOrDefault();
            if (pass == TextBox2.Text)
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