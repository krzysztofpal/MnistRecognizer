using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MnistRecognizer.Modules.Database;
using MnistRecognizer.Modules.Storage;

namespace MnistRecognizer.Controllers
{
    public class StorageController : Controller
    {
        INetworkProposalStorage storage;
        private Db db;

        public StorageController(INetworkProposalStorage storage, Db db)
        {
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetFiles()
        {
            var models = storage.GetModels(db);
            return Json(models);
        }

        public IActionResult Zip()
        {
            var path = storage.Zip(db);
            return PhysicalFile(path, "application/octet-stream", "Projekty_sieci.json");
        }
    }
}