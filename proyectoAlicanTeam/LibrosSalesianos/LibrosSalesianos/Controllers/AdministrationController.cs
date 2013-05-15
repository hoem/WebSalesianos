using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClasesAlicanTeam.EN;

namespace LibrosSalesianos.Controllers
{
    public class AdministrationController : Controller
    {
        //
        // GET: /Administration/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TableBooks()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
        }

        public JsonResult BookList()
        {
            try
            {
                var reader = new ENBook();
                var list = reader.ReadAll();
                /*
                var list = new List<Models.Book>();
                list.Add(new Models.Book("1", "The First", 3.05f, "url/to/first.img"));
                list.Add(new Models.Book("2", "The Second", 21.95f, "url/to/second.img"));
                list.Add(new Models.Book("3", "The Third", 70.25f, "url/to/third.img"));
                */
                return Json(new { Result = "OK", Records = list, TotalRecordCount = list.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult BookCreate(ENBook newBook)
        {
            try
            {
                newBook.Save();
                return Json(new { Result = "OK", Record = newBook });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult BookUpdate(ENBook updatedBook)
        {
            try
            {
                updatedBook.Save();
                return Json(new { Result = "OK", Record = updatedBook });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult BookDelete(int bookID)
        {
            try
            {
                (new ENBook()).Read(bookID).Delete();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult BookSubjectOptions()
        {
            try
            {
                var subjectList = (new ENSubject()).ReadAll();
                var subjects = subjectList.Select(c => new { DisplayText = c.Name + " " + c.Course.Courses, Value = c.Id });
                return Json(new { Result = "OK", Options = subjects });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult BookPublisherOptions()
        {
            try
            {
                var publishersList = (new ENPublisher()).ReadAll();
                var publisher = publishersList.Select(c => new { DisplayText = c.Name, Value = c.IdBusiness });
                return Json(new { Result = "OK", Options = publisher });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}
