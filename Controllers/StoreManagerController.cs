using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeaMVC.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;

namespace TeaMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoreManagerController : Controller
    {
        private TeaEntities db = new TeaEntities();

        // GET: StoreManager/Upload/5
        public async Task<ActionResult> Upload(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea Tea = await db.Teas.FindAsync(id);
            if (Tea == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupId = new SelectList(db.Sups, "SupId", "Name", Tea.SupId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", Tea.TypeId);
            return View(Tea);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload([Bind(Include = "TeaId,TypeId,SupId,Title,Price,TeaArtUrl")] Tea Tea, int id, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tea.TeaId = id;
                   
                    if (file.ContentLength > 0)
                    {
                        //Lưu thư mục
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Images"),   fileName);
                        file.SaveAs(path);

                        Tea.TeaArtUrl = path;

                        db.Entry(Tea).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                }
                //ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                //return RedirectToAction("Uploads");
                ViewBag.SupId = new SelectList(db.Sups, "SupId", "Name", Tea.SupId);
                ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", Tea.TypeId);
                return View(Tea);
            }
        }

        private void SaveImage(HttpPostedFileBase data)
        {
            CloudBlockBlob blob = this.GetContainer().GetBlockBlobReference(data.FileName);
            blob.Properties.ContentType = data.ContentType;
            using (var fileStream = data.InputStream)
            {
                blob.UploadFromStream(fileStream);
            } 
        }

        private void SaveImage(string id, string fileName, string contentType, byte[] data)
        {
            CloudBlockBlob blob = this.GetContainer().GetBlockBlobReference(fileName);            
            //Lưu trữ loại
            blob.Properties.ContentType = contentType;
            blob.UploadFromByteArray(data,0,data.Length);  
        }

        private CloudBlobContainer GetContainer()
        {
            //Nhận tài khoản lưu trữ
            CloudStorageAccount account = CloudStorageAccount.Parse( 
                                 ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            //Nhận client 
            CloudBlobClient client = account.CreateCloudBlobClient();
           
            return client.GetContainerReference("photos");
        }

        private void CreateContainerExists()
        {
            CloudBlobContainer container = this.GetContainer();
            
            container.CreateIfNotExists();

            container.SetPermissions(
             new BlobContainerPermissions
             {
                    PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }


        // GET: StoreManager
        public async Task<ActionResult> Index()
        {
            var Teas = db.Teas.Include(a => a.Sup).Include(a => a.Type);
            return View(await Teas.ToListAsync());
        }

        // GET: StoreManager/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea Tea = await db.Teas.FindAsync(id);
            if (Tea == null)
            {
                return HttpNotFound();
            }
            return View(Tea);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.SupId = new SelectList(db.Sups, "SupId", "Name");
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TeaId,TypeId,SupId,Title,Price,TeaArtUrl")] Tea Tea, HttpPostedFileBase file)
        {
            if (ModelState.IsValid&& file!=null)
            {
                //Đường dẫn hình ảnh, thư mục lưu trữ:
                
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/Upload"), fileName);
                    file.SaveAs(path);
                    Tea.TeaArtUrl = "/Content/Images/Upload/" + fileName;


                    db.Teas.Add(Tea);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = Tea.TeaId });   
            }

            


            ViewBag.SupId = new SelectList(db.Sups, "SupId", "Name", Tea.SupId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", Tea.TypeId);
            ViewBag.uploadInfo = "請選擇Đường dẫn hình ảnh: ！";
            return View(Tea);
        }

        // GET: StoreManager/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea Tea = await db.Teas.FindAsync(id);
            if (Tea == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupId = new SelectList(db.Sups, "SupId", "Name", Tea.SupId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", Tea.TypeId);
            return View(Tea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TeaId,TypeId,SupId,Title,Price,TeaArtUrl")] Tea Tea, int id, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Tea.TeaId = id;

                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/Upload"), fileName);
                    file.SaveAs(path);
                    Tea.TeaArtUrl = "/Content/Images/Upload/" + fileName;
                }
                db.Entry(Tea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new {id = Tea.TeaId });
            }
            ViewBag.SupId = new SelectList(db.Sups, "SupId", "Name", Tea.SupId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", Tea.TypeId);
            return View(Tea);
        }

        // GET: StoreManager/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea Tea = await db.Teas.FindAsync(id);
            if (Tea == null)
            {
                return HttpNotFound();
            }
            return View(Tea);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tea Tea = await db.Teas.FindAsync(id);
            db.Teas.Remove(Tea);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
