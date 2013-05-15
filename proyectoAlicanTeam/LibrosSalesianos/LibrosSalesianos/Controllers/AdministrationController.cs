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

        public JsonResult BookUpdate()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult BookDelete()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}
