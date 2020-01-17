using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MnistRecognizer.Modules.Storage;

namespace MnistRecognizer.Controllers
{
    public class StorageController : Controller
    {
        INetworkProposalStorage storage;

        public StorageController(INetworkProposalStorage storage)
        {
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetFiles()
        {
            var models = storage.GetModels();
            return Json(models);
        }
    }
}