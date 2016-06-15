using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scyts.Shopping.Admin.Ui.Controllers
{
    public class FileController : Controller
    {
        [HttpPost]
        // GET: File
        public JsonResult Upload(HttpPostedFileBase file)
        {
            try
            {
                // 如果没有上传文件
                if (file == null ||
                    string.IsNullOrEmpty(file.FileName) ||
                    file.ContentLength == 0)
                {
                 
                    return Json(new { isError = 10, message = "没有文件", fileName = "" });
                }

                // 保存到 ~/photos 文件夹中，名称不变
                string filename = Guid.NewGuid().ToString() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                //string virtualPath =
                //    string.Format("~/Source/File/{0}", filename);
                // 文件系统不能使用虚拟路径
                string path = System.Configuration.ConfigurationManager.AppSettings["FileUploadPath"]+filename;// this.Server.MapPath(virtualPath);

                file.SaveAs(path);

                string linkPath= System.Configuration.ConfigurationManager.AppSettings["CustomPath"] + filename;
                return Json(new { isError = 0, message = "", link = linkPath });

            }
            catch (Exception ex)
            {

                return Json(new { isError = 10, message = "系统错误", link = "" });
            }
    
        }

        [HttpPost]
        // GET: File
        public JsonResult Upload2(HttpPostedFileBase filedata)
        {
            try
            {
                // 如果没有上传文件
                if (filedata == null ||
                    string.IsNullOrEmpty(filedata.FileName) ||
                    filedata.ContentLength == 0)
                {

                    return Json(new { isError = 10, message = "没有文件", fileName = "" });
                }

                // 保存到 ~/photos 文件夹中，名称不变
                string filename = Guid.NewGuid().ToString() + filedata.FileName.Substring(filedata.FileName.LastIndexOf("."));
                //string virtualPath =
                //    string.Format("~/Source/File/{0}", filename);
                // 文件系统不能使用虚拟路径
                string path = System.Configuration.ConfigurationManager.AppSettings["FileUploadPath"] + filename;// this.Server.MapPath(virtualPath);

                filedata.SaveAs(path);

                string linkPath = System.Configuration.ConfigurationManager.AppSettings["CustomPath"] + filename;
                return Json(new { code =200,isError = 0, msg = "", fileName = linkPath });

            }
            catch (Exception ex)
            {

                return Json(new { code = 300,isError = 10, msg = "系统错误", link = "" });
            }

        }


        [HttpPost]
        // GET: File
        public JsonResult EditorImgUpload(string imgStr)
        {

     
            try
            {
                // 如果没有上传文件
                Bitmap file = GetImageFromBase64(imgStr.Split(',')[1]);
              
                // 保存到 ~/photos 文件夹中，名称不变
                string filename = Guid.NewGuid().ToString()+".png";
                string virtualPath =
                    string.Format("~/Source/File/{0}", filename);
                // 文件系统不能使用虚拟路径
                string path = this.Server.MapPath(virtualPath);

                file.Save(path,ImageFormat.Png);
                var linkPath = string.Format("/Source/File/{0}", filename); ;

                return Json(new { isError = 0, message = "", link = linkPath });

            }
            catch (Exception ex)
            {

                return Json(new { isError = 10, message = "系统错误", link = "" });
            }

        }


        public Bitmap GetImageFromBase64(string base64string)
        {
            byte[] b = Convert.FromBase64String(base64string);
            MemoryStream ms = new MemoryStream(b);
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;
        }
    }
}

