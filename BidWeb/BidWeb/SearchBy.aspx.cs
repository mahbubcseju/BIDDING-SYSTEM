using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BidWeb
{
    public partial class SearchBy : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(Session["UserName"] as string))
            //{
            //    if (!IsPostBack)
            //    {
            //        var viewAllItem = db.ProductInfoes.Select(x => x).ToList();
            //        searchedGridView.DataSource = viewAllItem;
            //        searchedGridView.DataBind();
            //    }
            //}
            //else
            //{
            //    userNameLabel.Text = "Hello " + Session["UserName"].ToString();
            //}

            if (!string.IsNullOrEmpty(Session["UserName"] as string))
            {
                userNameLabel.Text = "Hello " + Session["UserName"].ToString();
                registerLabel.Text = "";
                loginLabel.Text = "";
                registerLabel.Visible = false;
                loginLabel.Visible = false;
                logoutButton.Visible = true;
                menuLabel.Visible = true;

                if (!IsPostBack)
                {
                    var viewAllItem = db.ProductInfoes.Select(x => x).ToList();
                    searchedGridView.DataSource = viewAllItem;
                    searchedGridView.DataBind();
                }
            }
            else
            {
                menuLabel.Visible = false;
                registerLabel.Visible = true;
                loginLabel.Visible = true;
                logoutButton.Visible = false;
                registerLabel.Text = "Register";
                loginLabel.Text = "Login";
                if (!IsPostBack)
                {
                    var viewAllItem = db.ProductInfoes.Select(x => x).ToList();
                    searchedGridView.DataSource = viewAllItem;
                    searchedGridView.DataBind();
                }
            }


        }

        protected void searchByProductButton_Click(object sender, EventArgs e)
        {
            var product = productTextBox.Text;
            if (db.ProductInfoes.Any(x => x.ProductName == product))
            {
                var searchedList = db.ProductInfoes.Where(x => x.ProductName == product).Select(x => x).ToList();
                searchedGridView.DataSource = searchedList;
                searchedGridView.DataBind();
            }
            else if (db.ProductInfoes.Any(x => x.Category == product))
            {
                var searchedList = db.ProductInfoes.Where(x => x.Category == product).Select(x => x).ToList();
                searchedGridView.DataSource = searchedList;
                searchedGridView.DataBind();
            }
            else if (db.ProductInfoes.Any(x => x.ProductCode == product))
            {
                var searchedList = db.ProductInfoes.Where(x => x.ProductCode == product).Select(x => x).ToList();
                searchedGridView.DataSource = searchedList;
                searchedGridView.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Not Found !!!!');</script>");
            }
        }

        protected void searchMinimumButton_Click(object sender, EventArgs e)
        {
            double minimumThen = Convert.ToDouble(minimumThenTextBox.Text);
            var minimumList =
                db.ProductInfoes.Where(x => x.MinimumBid <= minimumThen).Select(x => x).ToList();
            searchedGridView.DataSource = minimumList;
            searchedGridView.DataBind();

        }

        protected void searchedGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(searchedGridView, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void searchedGridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = searchedGridView.SelectedRow;
            string productCode = row.Cells[1].Text;
            //MessageBox.Show(name);
            Session["ProductCode"] = productCode;
            Response.Redirect("ItemDetails.aspx");
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