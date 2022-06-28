using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace CorconAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetPaperDetails(string regId, string username, string type)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            DataTable dtqty = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.GetPaperDetails", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@RegId", regId);
                    sqlCommand.Parameters.AddWithValue("@Username", username);
                    sqlCommand.Parameters.AddWithValue("@Type", type);
                    connection.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        dtqty.Load(sdr);
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            string jsonString = JsonConvert.SerializeObject(new { dtqty });
            return Content(jsonString, "application/json");
        }

        public JsonResult CheckEmail(string email)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.CheckEmail", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateProfile(string regId, string username, string userid, string email, string password)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.UpdateProfile", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@RegId", regId);
                    sqlCommand.Parameters.AddWithValue("@FullName", username);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.Parameters.AddWithValue("@UserId", userid);
                    sqlCommand.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUsername(string username)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.CheckUserName", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSymposiaResult()
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            DataTable dtqty = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.GetSymposiaListSP", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        dtqty.Load(sdr);
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            string jsonString = JsonConvert.SerializeObject(new { dtqty });
            return Content(jsonString, "application/json");
        }

        public ActionResult SetUserLogin(string id, string pwd)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            DataTable userDetails = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.SetUserLogin", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlCommand.Parameters.AddWithValue("@Pwd", pwd);
                    connection.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        userDetails.Load(sdr);
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            string jsonString = JsonConvert.SerializeObject(new { userDetails });
            return Content(jsonString, "application/json");
        }

        public JsonResult SetSymposiaUserDetails(string Reg_Id, string SymposiaName, string PaperTitle)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.Set_SymposiaDetails2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Reg_Id", Reg_Id);
                    sqlCommand.Parameters.AddWithValue("@SymposiaName", SymposiaName);
                    sqlCommand.Parameters.AddWithValue("@PaperTitle", PaperTitle);
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSymposiaUserList(string Reg_Id)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            DataTable dtqty = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.GetSymposiaUserList2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Reg_Id", Reg_Id);
                    connection.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        dtqty.Load(sdr);
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            string jsonString = JsonConvert.SerializeObject(new { dtqty });
            return Content(jsonString, "application/json");
        }

        public JsonResult SetRegistration(string reg_id, string name, string email, string mobile, string username, string password, string presentationType)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.Set_AppRegistration2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Reg_Id", reg_id);
                    sqlCommand.Parameters.AddWithValue("@Name", name);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.Parameters.AddWithValue("@Mobile", mobile);
                    sqlCommand.Parameters.AddWithValue("@Username", username);
                    sqlCommand.Parameters.AddWithValue("@Password", password);
                    sqlCommand.Parameters.AddWithValue("@PresentationType", presentationType);
                    sqlCommand.Parameters.AddWithValue("@Type", "Insert");
                    sqlCommand.Parameters.AddWithValue("@SponsorType", "Exhibitor");
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }


        // 21-04-2022
        public JsonResult SponsorRegistration(string reg_id, string name, string email, string mobile, string username, string password, string companyMobile, string companyEmail, string website, string faciaName, HttpPostedFileBase companyLogo, HttpPostedFileBase visitingCard, HttpPostedFileBase companyProfile, HttpPostedFileBase advertise)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {

                    try
                    {
                        string filename = companyProfile.FileName.ToString();
                        string path = @"D:\www.websites\CorconAPI\App_Data\Files\CompanyProfile\";
                        string tempFile = path + filename;
                        companyProfile.SaveAs(tempFile);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }

                    try
                    {
                        string filename = advertise.FileName.ToString();
                        string path = @"D:\www.websites\CorconAPI\App_Data\Files\Advertise\";
                        string tempFile = path + filename;
                        advertise.SaveAs(tempFile);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }

                    try
                    {
                        string filename = companyLogo.FileName.ToString();
                        string path = @"D:\www.websites\CorconAPI\App_Data\Files\CompanyLogo\";
                        string tempFile = path + filename;
                        companyLogo.SaveAs(tempFile);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }

                    try
                    {
                        string filename = visitingCard.FileName.ToString();
                        string path = @"D:\www.websites\CorconAPI\App_Data\Files\VisitingCard\";
                        string tempFile = path + filename;
                        visitingCard.SaveAs(tempFile);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }

                    SqlCommand sqlCommand = new SqlCommand("dbo.Set_AppRegistration2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Reg_Id", reg_id);
                    sqlCommand.Parameters.AddWithValue("@Name", name);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.Parameters.AddWithValue("@Mobile", mobile);
                    sqlCommand.Parameters.AddWithValue("@Username", username);
                    sqlCommand.Parameters.AddWithValue("@Password", password);
                    sqlCommand.Parameters.AddWithValue("@CompanyEmail", companyEmail);
                    sqlCommand.Parameters.AddWithValue("@CompanyNumber", companyMobile);
                    sqlCommand.Parameters.AddWithValue("@FaciaName", faciaName);
                    sqlCommand.Parameters.AddWithValue("@Website", website);
                    sqlCommand.Parameters.AddWithValue("@CompanyProfile", @"App_Data/Files/" + companyProfile.FileName.ToString());
                    sqlCommand.Parameters.AddWithValue("@Advertisement", @"App_Data/Files/" + advertise.FileName.ToString());
                    sqlCommand.Parameters.AddWithValue("@CompanyLogo", @"App_Data/Files/" + companyLogo.FileName.ToString());
                    sqlCommand.Parameters.AddWithValue("@VisitingCard", @"App_Data/Files/" + visitingCard.FileName.ToString());
                    sqlCommand.Parameters.AddWithValue("@Type", "Insert");
                    sqlCommand.Parameters.AddWithValue("@SponsorType", "Company");
                    sqlCommand.Parameters.AddWithValue("@InsertType", "Sponsor");
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        // 21-04-2022
        public JsonResult DelegateRegistration(string reg_id, string name, string email, string mobile, string username, string password, string companyMobile, string companyEmail, string website, HttpPostedFileBase companyLogo, HttpPostedFileBase visitingCard)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {

                    try
                    {
                        string filename = companyLogo.FileName.ToString();
                        string path = @"D:\www.websites\CorconAPI\App_Data\Files\CompanyLogo\";
                        string tempFile = path + filename;
                        companyLogo.SaveAs(tempFile);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }

                    try
                    {
                        string filename = visitingCard.FileName.ToString();
                        string path = @"D:\www.websites\CorconAPI\App_Data\Files\VisitingCard\";
                        string tempFile = path + filename;
                        visitingCard.SaveAs(tempFile);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }

                    SqlCommand sqlCommand = new SqlCommand("dbo.Set_AppRegistration2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Reg_Id", reg_id);
                    sqlCommand.Parameters.AddWithValue("@Name", name);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.Parameters.AddWithValue("@Mobile", mobile);
                    sqlCommand.Parameters.AddWithValue("@Username", username);
                    sqlCommand.Parameters.AddWithValue("@Password", password);
                    sqlCommand.Parameters.AddWithValue("@Website", website);
                    sqlCommand.Parameters.AddWithValue("@CompanyLogo", @"App_Data/Files/"+companyLogo.FileName.ToString());
                    sqlCommand.Parameters.AddWithValue("@VisitingCard", @"App_Data/Files/" + visitingCard.FileName.ToString());
                    sqlCommand.Parameters.AddWithValue("@CompanyEmail", companyEmail);
                    sqlCommand.Parameters.AddWithValue("@CompanyNumber", companyMobile);
                    sqlCommand.Parameters.AddWithValue("@Type", "Insert");
                    sqlCommand.Parameters.AddWithValue("@SponsorType", "Company");
                    sqlCommand.Parameters.AddWithValue("@InsertType", "Delegate");
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        // 29-04-2022
        public JsonResult NoLastPageRegistration(string reg_id, string name, string email, string mobile, string username, string password, string companyMobile, string companyEmail)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {


                    SqlCommand sqlCommand = new SqlCommand("dbo.Set_AppRegistration2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Reg_Id", reg_id);
                    sqlCommand.Parameters.AddWithValue("@Name", name);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.Parameters.AddWithValue("@Mobile", mobile);
                    sqlCommand.Parameters.AddWithValue("@Username", username);
                    sqlCommand.Parameters.AddWithValue("@Password", password);
                    sqlCommand.Parameters.AddWithValue("@Website", "");
                    sqlCommand.Parameters.AddWithValue("@CompanyLogo", "");
                    sqlCommand.Parameters.AddWithValue("@VisitingCard","");
                    sqlCommand.Parameters.AddWithValue("@CompanyEmail", companyEmail);
                    sqlCommand.Parameters.AddWithValue("@CompanyNumber", companyMobile);
                    sqlCommand.Parameters.AddWithValue("@Type", "Insert");
                    sqlCommand.Parameters.AddWithValue("@SponsorType", "Company");
                    sqlCommand.Parameters.AddWithValue("@InsertType", "Delegate");
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetBoothDetails()
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            DataTable dtqty = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {

                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertBoothDetails2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@queryType", "Select");
                    connection.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        dtqty.Load(sdr);
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            string jsonString = JsonConvert.SerializeObject(new { dtqty });
            return Content(jsonString, "application/json");
        }

        public JsonResult SetBoothDetails(string boothName, string sqmType, string isOccupied, string regId, string boothStatus, string listNo, string actualAmount, string discount, string discountAmnt, string totalAmount)
        {

            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertBoothDetails2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@boothName", boothName);
                    sqlCommand.Parameters.AddWithValue("@sqmType", sqmType);
                    sqlCommand.Parameters.AddWithValue("@isOccupied", isOccupied);
                    sqlCommand.Parameters.AddWithValue("@regId", regId);
                    sqlCommand.Parameters.AddWithValue("@boothStatus", boothStatus);
                    sqlCommand.Parameters.AddWithValue("@listNo", listNo);
                    sqlCommand.Parameters.AddWithValue("@actualAmount", actualAmount);
                    sqlCommand.Parameters.AddWithValue("@discount", discount);
                    sqlCommand.Parameters.AddWithValue("@discountAmnt", discountAmnt);
                    sqlCommand.Parameters.AddWithValue("@totalAmount", totalAmount);
                    sqlCommand.Parameters.AddWithValue("@queryType", "Insert");
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetDelegateList(string regId, string delegateNo, string delegateName, string uploadedPhoto, string emailid, string mobileno, string role, HttpPostedFileBase delegateFile)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    try
                    {
                        string filename = delegateFile.FileName.ToString();
                        string path = @"D:\www.websites\CorconAPI\App_Data\Files\DelegateFile\";
                        string tempFile = path + filename;
                        delegateFile.SaveAs(tempFile);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }

                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertDelegateList2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@regId", regId);
                    sqlCommand.Parameters.AddWithValue("@delegateNo", delegateNo);
                    sqlCommand.Parameters.AddWithValue("@delegateName", delegateName);
                    sqlCommand.Parameters.AddWithValue("@uploadedPhoto", @"App_Data/Files/" + delegateFile.FileName.ToString());
                    sqlCommand.Parameters.AddWithValue("@emailId", emailid);
                    sqlCommand.Parameters.AddWithValue("@mobileNo", mobileno);
                    sqlCommand.Parameters.AddWithValue("@role", role);
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetRoomList(string regId, string roomNo, string name, string uploadedPhoto, string emailid, string mobileno)
        {
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertRoomList2022", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@regId", regId);
                    sqlCommand.Parameters.AddWithValue("@roomNo", roomNo);
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@uploadedPhoto", uploadedPhoto);
                    sqlCommand.Parameters.AddWithValue("@emailId", emailid);
                    sqlCommand.Parameters.AddWithValue("@mobileNo", mobileno);
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetSymposiaDataUpload(string title, string papername, string uploadedby, string empcode, string regid, string type, string emailid,  HttpPostedFileBase file)
        {
            
            var connectionstring = "data source=IOC;initial catalog=CICINDIA2022;user id=sa;password=master@008;multipleactiveresultsets=True;application name=EntityFramework";
            int k = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    try
                    {
                        string filename = file.FileName.ToString();
                        string path = @"D:\www.websites\CorconAPI\App_Data\Files\Symposia\";
                        string tempFile = path + filename;
                        file.SaveAs(tempFile);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }

                    SqlCommand sqlCommand = new SqlCommand("dbo.SetSymposiaAbstractData", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@title", title);
                    sqlCommand.Parameters.AddWithValue("@papername", papername);
                    sqlCommand.Parameters.AddWithValue("@uploadedfile", file.FileName);
                    sqlCommand.Parameters.AddWithValue("@uploadedby", uploadedby);
                    sqlCommand.Parameters.AddWithValue("@empcode", empcode);
                    sqlCommand.Parameters.AddWithValue("@regid", regid);
                    sqlCommand.Parameters.AddWithValue("@type", type);
                    sqlCommand.Parameters.AddWithValue("@emailid", emailid);
                    connection.Open();
                    k = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return Json(new[] { new { sts = k } }, JsonRequestBehavior.AllowGet);
        }

        
    }
}
