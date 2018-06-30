using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BidWeb
{
    public partial class MyProductBidingList : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        MyBoughtList myBoughtList = new MyBoughtList();
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = Session["UserName"].ToString();
            //var userName = "mahabur";
            var productCode =
                db.ProductInfoes.Where(x => x.UserName == userName).Select(x => x.ProductCode).ToList().LastOrDefault();
            var bidingList = db.BidingInfoes.Where(x => x.ProductCode == productCode).Select(x => x).ToList();
            bidingListGridView.DataSource = bidingList;
            bidingListGridView.DataBind();
            ViewState["ProductCode"] = productCode;
            userNameLabel.Text = "Hello" + Session["UserName"].ToString();
        }

        protected void soldButton_Click(object sender, EventArgs e)
        {
            var productCode = ViewState["ProductCode"].ToString();
            var maxBid = db.BidingInfoes.Where(x => x.ProductCode == productCode).Max(x => x.MaxBid);

            var userName =
                db.BidingInfoes.Where(x => x.ProductCode == productCode && x.MaxBid == maxBid)
                    .Select(x => x.UserName)
                    .ToList()
                    .LastOrDefault();
            var productName =
                db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.ProductName)
                    .ToList()
                    .LastOrDefault();
            var picture = db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.ProductImage)
                    .ToList()
                    .LastOrDefault();
            var details = db.ProductInfoes.Where(x => x.ProductCode == productCode)
                    .Select(x => x.Details)
                    .ToList()
                    .LastOrDefault();

            var email = db.UserInfoes.Where(x => x.UserName == userName).Select(x => x.Email).ToList().LastOrDefault();
            var emailSubject = "This is my Bid.com";
            var emailBody = "Hello Sir, we congratulate you as our buyer of the product that you bid!!! We will contact with you later soon about the payment details.";



            if (db.MyBoughtLists.Any(x => x.ProductCode == productCode))
            {
                Response.Write("<script>alert('This product is already sold !!!!');</script>");
            }
            else
            {
                myBoughtList.UserName = userName;
                myBoughtList.ProductCode = productCode;
                myBoughtList.ProductName = productName;
                myBoughtList.Picture = picture;
                myBoughtList.Details = details;
                myBoughtList.BidMoney = maxBid.ToString();
                db.MyBoughtLists.Add(myBoughtList);
                db.SaveChanges();


                var rows = db.ProductInfoes.Where(x => x.ProductCode == productCode).Select(x => x).ToList();
                foreach (var dr in rows)
                {
                    db.ProductInfoes.Remove(dr);
                }
                db.SaveChanges();

                var rowsbid = db.BidingInfoes.Where(x => x.ProductCode == productCode).Select(x => x).ToList();

                foreach (var r in rowsbid)
                {
                    db.BidingInfoes.Remove(r);
                }
                db.SaveChanges();


                MessageBox.Show("An Email Sent to The Buyer!!");
                Response.Redirect("MyProductBidingList.aspx");

                //try
                //{
                //    var client = new SmtpClient("smtp.mail.yahoo.com", 587)
                //    {
                //        Credentials = new NetworkCredential("mahbuburrahman2111@yahoo.com", "loolvaiyalool"),
                //        EnableSsl = true
                //    };
                //    client.Send("nuranpagla@yahoo.com", email, emailSubject, emailBody);





                //    MessageBox.Show("An Email Sent to The Buyer!!");
                //}
                //catch (Exception msException)
                //{

                //    MessageBox.Show(msException.ToString());
                //}
            }

        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Response.Redirect("HomePage.aspx");
        }
    }
}