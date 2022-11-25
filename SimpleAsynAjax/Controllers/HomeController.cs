using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleAsynAjax.Models;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using System.Threading;
using System.Web.Services.Description;


namespace SimpleAsynAjax.Controllers
    {

    public class HomeController : Controller
        {

        public ExampleDatabaseEntities db = new ExampleDatabaseEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExampleTable tbl)
        {
            var message = "";
            try
            {
                db.ExampleTables.Add(tbl); db.SaveChanges();
                message = "Success";
            }
            catch (Exception msg)
            {
                message = msg.Message;
            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public JsonResult GetExampleTable(ExampleTable obj)
        {
            List<ExampleTable> tables = new List<ExampleTable>(); 
            tables = db.ExampleTables.ToList();
            return Json(tables, JsonRequestBehavior.AllowGet);
        }
    }
   
}


