using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BidWeb
{
    public partial class AddItem : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        ProductInfo productInfo = new ProductInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            userNameLabel.Text ="Hello"+ Session["UserName"].ToString();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (productNameTextBox.Text == "" || categoryTextBox.Text == "" || minimumBidTextBox.Text == "" || Request.Form["LastDate"] == "")
            {
                Response.Write("<script>alert('Enter data for every input field!');</script>");
            }
            else
            {
                string path = Server.MapPath("Images/");

                if (FileUpload1.HasFile)
                {
                    string ext = Path.GetExtension(FileUpload1.FileName);

                    if (ext == ".jpg" || ext == ".png")
                    {
                        FileUpload1.SaveAs(path + FileUpload1.FileName);
                        string picture = "Images/" + FileUpload1.FileName;
                        string stringuser = Session["UserName"].ToString();
                        if (db.ProductInfoes.Any(x => x.UserName == stringuser))
                        {

                            Response.Write("<script>alert('You have entered one product already!! You can add your next product after selling it');</script>");
                        }
                        else
                        {
                            var num = db.ProductInfoes.Select(x => x).ToList();
                            string code = string.Format("{0:D3}", num.Count + 1);
                            productInfo.ProductName = productNameTextBox.Text;
                            productInfo.Category = categoryTextBox.Text;
                            productInfo.ProductImage = picture;
                            productInfo.MinimumBid = Convert.ToDouble(minimumBidTextBox.Text);
                            productInfo.UserName = Session["UserName"].ToString();
                            productInfo.LastDate = Request.Form["LastDate"];
                            productInfo.Details = detailsTextBox.Text;
                            productInfo.ProductCode = productNameTextBox.Text + code;
                            db.ProductInfoes.Add(productInfo);
                            db.SaveChanges();

                            Response.Write("<script>alert('Item added successfully!');</script>");

                        }
                    }

                    else
                    {
                        Response.Write("<script>alert('Upload .jpg or .png format!');</script>");
                    }
                }

                else
                {
                    Response.Write("<script>alert('Upload image first!');</script>");
                }
            }


        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Response.Redirect("HomePage.aspx");
        }
    }
}