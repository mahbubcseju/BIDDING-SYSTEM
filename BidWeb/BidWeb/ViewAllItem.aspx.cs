using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BidWeb
{
    public partial class ViewAllItem : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            //var allItemList = db.ProductInfoes.Where(x => Convert.ToDateTime(x.LastDate).ToShortDateString() < DateTime.Now.ToShortDateString()).Select(x => x).ToList();
            var allItemList = db.ProductInfoes.Select(x => x).ToList();
            allItemGridView.DataSource = allItemList;
            allItemGridView.DataBind();
            userNameLabel.Text = "Hello" + Session["UserName"].ToString();
        }

        protected void allItemGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(allItemGridView, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void allItemGridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = allItemGridView.SelectedRow;
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
    }
}