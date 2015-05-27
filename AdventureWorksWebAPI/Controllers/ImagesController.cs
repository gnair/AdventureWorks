using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksWebAPI.Controllers
{
    public class ImagesController : Controller
    {
        private AdventureWorks2014Entities db = new AdventureWorks2014Entities();

        // GET: Images/Thumbnail/5
        public ActionResult Thumbnail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPhoto productPhoto = db.ProductPhotoes.Find(id);
            if (productPhoto == null)
            {
                return HttpNotFound();
            }

            return File(productPhoto.ThumbNailPhoto, "image/jpg");
        }

        // GET: Images/Photo/5
        public ActionResult Photo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPhoto productPhoto = db.ProductPhotoes.Find(id);
            if (productPhoto == null)
            {
                return HttpNotFound();
            }

            return File(productPhoto.LargePhoto, "image/jpg");
        }
    
    }
}