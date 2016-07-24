using hazi2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace hazi2.Controllers
{
    public class HomeController : Controller
    {
        private static List<Item> _items = new List<Item>();
       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CsvFileModel model)
        {
            if (model.Cikk == null)
            {
                return View();
            }

            List<Item> items = new List<Item>();

            using (StreamReader reader = new StreamReader(model.Cikk.InputStream))
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] elements = line.Split(';');

                    Item item = new Item();

                    item.Name = elements[0];
                    item.Name = item.Name.Trim(new Char[] { '"'});
                    item.ItemNumber = elements[1];
                    item.ItemNumber = item.ItemNumber.Trim(new Char[] { '"' });
                    item.BarCode = elements[2];
                    item.BarCode = item.BarCode.Trim(new Char[] { '"' });
                    item.Piece = elements[3];
                    item.Piece = item.Piece.Trim(new Char[] { '"' });
                    items.Add(item);
                    
                }
            }
            _items = items;


            return RedirectToAction("Lista");

        }

        

        public ActionResult Lista()
        {
            
            return View(_items);
        }

        

        [HttpGet]
        public ActionResult UjElem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UjElem(Item item)
        {
           
            _items.Add(item);
            return RedirectToAction("Lista");
        }

        public ActionResult Letoltes()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in _items)
            {
                builder.AppendFormat("{0};{1};{2};{3}", item.Name, item.ItemNumber,item.BarCode,item.Piece);
                builder.AppendLine();
            }

            string csvFileContent = builder.ToString();
            byte[] content = Encoding.UTF8.GetBytes(csvFileContent);
            return new FileContentResult(content, "text/csv")
            {
                FileDownloadName = "Cikkek.csv"
            };

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}