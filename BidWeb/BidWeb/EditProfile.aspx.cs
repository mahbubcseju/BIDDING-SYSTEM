using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BidWeb
{
    public partial class EditProfile : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        UserInfo userInfo = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = Session["UserName"].ToString();
            emailTextBox.Text =
                 db.UserInfoes.Where(x => x.UserName == userName).Select(x => x.Email).ToList().LastOrDefault();

            phoneTextBox.Text = db.UserInfoes.Where(x => x.UserName == userName).Select(x => x.Phone).ToList().LastOrDefault();

            countryTextBox.Text = db.UserInfoes.Where(x => x.UserName == userName).Select(x => x.Country).ToList().LastOrDefault();
            userNameLabel.Text = "Hello " + Session["UserName"].ToString();
        }

        protected void updateButton_OnClick(object sender, EventArgs e)
        {
            var userName = Session["UserName"].ToString();

            try
            {
                userInfo = db.UserInfoes.Where(x => x.UserName == userName).Select(x => x).First();
                userInfo.Password = passwordTextBox.Text;
                userInfo.Email = emailTextBox.Text;
                userInfo.Phone = phoneTextBox.Text;
                userInfo.Country = countryTextBox.Text;
                db.SaveChanges();
                Response.Write("<script>alert('Updated  ! ! !');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Something Went wrong !!! ');</script>");
            }

        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Response.Redirect("HomePage.aspx");
        }
    }
}