using MP2_IT114L.App_Code.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP2_IT114L
{
    public partial class Login_Client : Page
    {
        protected void LogAccount_Click(object sender, EventArgs e)
        {
            string email = TB_email.Text;
            string password = TB_password.Text;
            string type;

            UserRepository userRepository = new UserRepository();

            if (userRepository.CheckUser(email, password))
            {
                type = userRepository.CheckUserType(email, password);
                Session["LoggedInUserEmail"] = email;
                Session["UserType"] = type;
                if (type == "Admin")
                {
                    Response.Redirect("~/Admin/Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("Index.aspx");
                    Response.Redirect("~/Index.aspx");
                    Session["UserType"] = type;
                    Response.Redirect("~/Index.aspx");
                    Session["UserType"] = type;
                    Response.Redirect("~/Index.aspx");
                    Session["UserType"] = type;
                    Response.Redirect("~/Index.aspx");
                    Session["UserType"] = type;
                    Response.Redirect("~/Index.aspx");
                }
            }
            else
            {
                Response.Write("Invalid email or password.");
            }
        }
    }
}
