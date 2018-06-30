using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BidWeb
{
    public partial class ItemDetails : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        BidingInfo bidingInfo = new BidingInfo();
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

            var productCode = Session["ProductCode"].ToString();
            productNameLabel.Text =
                db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.ProductName)
                    .ToList()
                    .LastOrDefault();
            categoryLabel.Text =
                db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.Category)
                    .ToList()
                    .LastOrDefault();
            minimumBidLabel.Text =
                db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.MinimumBid)
                    .ToList()
                    .LastOrDefault().ToString() + "/=";
            detailsLabel.Text =
                db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.Details)
                    .ToList()
                    .LastOrDefault();
            dateLabel.Text =
                db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.LastDate)
                    .ToList()
                    .LastOrDefault();
            productCodeLabel.Text =
                db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.ProductCode)
                    .ToList()
                    .LastOrDefault();
            productImage.ImageUrl = db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.ProductImage)
                    .ToList()
                    .LastOrDefault();



        }

        protected void bidButton_Click(object sender, EventArgs e)
        {
            var productCode = Session["ProductCode"].ToString();
            var minimumBid = db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.MinimumBid)
                    .ToList()
                    .LastOrDefault().ToString();
            var uploaderUserName =
                db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.UserName)
                    .ToList()
                    .LastOrDefault();


            if (string.IsNullOrEmpty(Session["UserName"] as string))
            {
               // MessageBox.Show("Login First");
                Response.Write("<script>alert('Login First');</script>");
            }
            else if (Session["UserName"].ToString() == uploaderUserName)
            {
                Response.Write("<script>alert('You cannot bid your own item ! Sorry !!');</script>");
            }
            else
            {
                try
                {
                    if (Convert.ToDouble(myMaxTextBox.Text) >= Convert.ToDouble(minimumBid))
                    {
                        bidingInfo.ProductCode = productCodeLabel.Text;
                        bidingInfo.UserName = Session["UserName"].ToString();
                        bidingInfo.DateHeBid = DateTime.Now.ToShortDateString();
                        bidingInfo.MaxBid = Convert.ToDouble(myMaxTextBox.Text);
                        db.BidingInfoes.Add(bidingInfo);
                        db.SaveChanges();
                        Response.Write("<script>alert('Successfully Bid !!!');</script>");
                    }
                    else
                    {
                      
                        Response.Write("<script>alert('Your bid can not be less than minimum bid');</script>");
                    }
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('You have to enter some amount');</script>");
                }

                
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