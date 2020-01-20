using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MnistRecognizer.Models;
using MnistRecognizer.Modules.Database;
using MnistRecognizer.Modules.NeuralNetwork;
using MnistRecognizer.Modules.Storage;

namespace MnistRecognizer.Controllers
{
    public class MnistController : Controller
    {
        IMnistInterpreter mnist;
        IImageStore image_store;
        INetworkProposalStorage network_store;
        private Db db;

        public MnistController(IMnistInterpreter mnist, IImageStore image_store, INetworkProposalStorage network_store, Db db)
        {
            this.mnist = mnist ?? throw new ArgumentNullException(nameof(mnist));
            this.image_store = image_store ?? throw new ArgumentNullException(nameof(image_store));
            this.network_store = network_store ?? throw new ArgumentNullException(nameof(network_store));
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NetworkDesigner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveImage([FromBody]SaveImageData postdata)
        {
            var path = image_store.SaveImage(postdata.ImageBytes(), postdata.Number);
            var image = new Bitmap(path);
            var result = mnist.Evaluate(image);


            var name = Path.GetFileName(path);
            var history = new HistoryModel()
            {
                nazwaObrazka = name,
                numerPrzedstawiany = postdata.Number,
                results = result
            };
            db.Entry(history).State = EntityState.Added;
            db.SaveChanges();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult SaveNetwork([FromBody] NetworkModel model)
        {
            if(model == null) 
                throw new ArgumentNullException(nameof(model));

            network_store.Save(model, db);

            return Ok();
        }

        public IActionResult History()
        {
            var names = image_store.GetAllImagesNames(1);

            var h = db.History.ToList();

            return Json(h);
        }
    }
}