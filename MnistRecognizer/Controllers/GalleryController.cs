using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MnistRecognizer.Modules.Storage;

namespace MnistRecognizer.Controllers
{
    public class GalleryController : Controller
    {
        IImageStore store;
        public GalleryController(IImageStore store)
        {
            this.store = store;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Images(int type)
        {
            var data = store.GetAllImagesNames(type);
            data = data.Select(x => $"/Gallery/GetImage?type={type}&name={x}").ToArray();
            var model = new GalleryRequest()
            {
                Names = data,
                Type = type
            };
            return View(model);
        }

        public class GalleryRequest
        {
            public int Type { get; set; }
            public string[] Names { get; set; }
        }

        public IActionResult GetImage(string type, string name)
        {
            var path = store.GetAbsolutePath(type, name);
            if(path != null)
                return PhysicalFile(path, "image/png");
            else return NotFound();
        }

        public IActionResult GetRepo()
        {
            var path = store.ZipRepo();

            return PhysicalFile(path, "application/zip", "Repozytorium testowe.zip");
        }

        public IActionResult ZipImages(int type)
        {
            var path = store.ZipImagesOfType(type);

            return PhysicalFile(path, "application/zip", $"Repozytorium testowe - {type}.zip");
        }
    }
}