using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Query query = new Query();
            DataTable dt;
            dt = query.GetCities();
            if (!Page.IsPostBack)
            {
                DropDownList1.DataTextField = "city";
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
            }
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Query query = new Query();
            bool isChecked = CheckBoxAddFriends.Checked;
            if (isChecked)
            {
                query.InsertLink(TextBoxLink.Text);
            }
            else
            {
                query.InsertEmptyLink();
            }           
        }

        protected void UpdateGridView (DataTable dt)
        {
            GridView.DataSource = dt;
            GridView.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Query query = new Query();
            DataTable dt;
            bool isChecked = Topweek.Checked;
            if (isChecked)
            {
                dt = query.GetTopWeek();
                UpdateGridView(dt);
            }
            else
            {
                dt = query.GetTopDay();
                UpdateGridView(dt);
            }
        }

        protected void DateButton_Click(object sender, EventArgs e)
        {
            Query query = new Query();
            DataTable dt;
            dt = query.GetTopBetween(DateStart.Text, DateStop.Text);
            UpdateGridView(dt);

        }

        protected void DateStart_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateStart.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            DateStop.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
            Calendar2.Visible = false;
        }

        protected void imgPopup_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void imgPopup2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void TextBoxCity_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void ButtonCity_Click(object sender, EventArgs e)
        {
            Query query = new Query();
            DataTable dt;
            dt = query.GetTopCity(DropDownList1.SelectedValue);
            UpdateGridView(dt);
        }
    }
}