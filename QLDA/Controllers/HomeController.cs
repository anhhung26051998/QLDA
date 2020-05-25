using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using OfficeOpenXml;


namespace QLDA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public FileResult Report()
        {
            BTL_QLDAEntities qlda = new BTL_QLDAEntities();
            var data = qlda.BanQLDAs.Select(x=>x).ToList();
           
                FileInfo file = new FileInfo(@"C:/Users/Admin/source/repos/QLDA/QLDA/Template/Report.xlsx");
                ExcelPackage pack = new ExcelPackage(file);
                ExcelWorksheet sheet = pack.Workbook.Worksheets[0];
                int row = 3;
                int stt = 1;

                foreach (var item in data)
                {
                    sheet.Row(row).Height = 20;
                    sheet.Cells[row, 1].Value = stt;
                    sheet.Cells[row, 2].Value = item.ID;
                    sheet.Cells[row, 3].Value = item.IdChudautu;
                    sheet.Cells[row, 4].Value = item.Mabanqlda;
                    sheet.Cells[row, 5].Value = item.Tenbanqlda;
                    sheet.Cells[row, 6].Value = item.Diachi;
                    sheet.Cells[row, 7].Value = item.Email;
                    sheet.Cells[row, 8].Value = item.Phone;
                    sheet.Cells[row, 9].Value = item.Mota;
                    sheet.Cells[row, 10].Value = item.Nguoitao;
                    sheet.Cells[row, 11].Value = item.Ngaytao;
                    sheet.Cells[row, 12].Value = item.Nguoisua;
                    sheet.Cells[row, 13].Value = item.Ngaysua;
                    row++;
                    stt++;
                }
                return File(pack.GetAsByteArray(), "application / vnd.openxmlformats - officedocument.spreadsheetml.sheet", "ReportDemo.xlsx");
            
            
           
        }
    }
}