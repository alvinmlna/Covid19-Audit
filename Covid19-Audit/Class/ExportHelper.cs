using ClosedXML.Excel;
using Covid19_Audit.Viewmodel.Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Covid19_Audit.Class
{
    public static class ExportHelper
    {
        public static void Export(IEnumerable<dynamic> result, AuditReportViewModel report)
        {
            if(result.Count() > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    var ws = wb.Worksheets.Add("Export");


                    PropertyInfo[] properties = result.First().GetType().GetProperties();
                    List<string> headerNames = properties.Select(prop => prop.Name).ToList();
                    for (int i = 0; i < headerNames.Count; i++)
                    {
                        ws.Cell(1, i + 1).Value = headerNames[i];
                    }

                    ws.Cell(2, 1).InsertData(result);
                    ws.Columns("A", "J").AdjustToContents();

                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Report.xlsx");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                }
            }
        }


        public static string ImageBuilder(string img)
        {
            var result = "";
            UrlHelper Url = new UrlHelper(HttpContext.Current.Request.RequestContext);

            if (String.IsNullOrEmpty(img) == false)
            {
                List<string> images = new List<string>();

                string[] imgArray = img.Split(',');
                for (int i = 0; i < imgArray.Length; i++)
                {
                    var url = Uri.EscapeUriString(imgArray[i]);
                    images.Add("<a id='singleImage' data-fancybox href=" + Url.Content(url) + "> <img src=" + Url.Content(url) + " alt='' style='max-width:70px;'/> </a>");
                }
                result = String.Join("", images);
            }


            return result;
        }
    }
}