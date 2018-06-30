using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BidWeb
{
    public partial class ViewMyItem : System.Web.UI.Page
    {
        BidDBEntities db = new BidDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = Session["UserName"].ToString();
            var itemList = db.ProductInfoes.Where(x => x.UserName == userName).Select(x => x).ToList();
            ItemListGridView.DataSource = itemList;
            ItemListGridView.DataBind();
            userNameLabel.Text = "Hello " + Session["UserName"].ToString();
        }

        protected void deleteButton_OnClick(object sender, EventArgs e)
        {
            var userName = Session["UserName"].ToString();
            try
            {
                var rows = db.ProductInfoes.Where(x => x.UserName == userName).Select(x => x).ToList();
                foreach (var dr in rows)
                {
                    db.ProductInfoes.Remove(dr);
                }
                db.SaveChanges();
                Response.Write("<script>alert('Delete Successfully   !!!!');</script>");
                Response.Redirect("ViewMyItem.aspx");

            }
            catch (Exception)
            {

                MessageBox.Show("An Error Occurred");
            }
            
        }

        protected void ItemListGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ItemListGridView, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void ItemListGridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ItemListGridView.SelectedRow;
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