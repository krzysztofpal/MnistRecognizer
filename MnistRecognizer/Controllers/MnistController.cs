using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MnistRecognizer.Models;
using MnistRecognizer.Modules.NeuralNetwork;
using MnistRecognizer.Modules.Storage;

namespace MnistRecognizer.Controllers
{
    public class MnistController : Controller
    {
        IMnistInterpreter mnist;
        IImageStore image_store;
        INetworkProposalStorage network_store;

        public MnistController(IMnistInterpreter mnist, IImageStore image_store, INetworkProposalStorage network_store)
        {
            this.mnist = mnist ?? throw new ArgumentNullException(nameof(mnist));
            this.image_store = image_store ?? throw new ArgumentNullException(nameof(image_store));
            this.network_store = network_store ?? throw new ArgumentNullException(nameof(network_store));
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

            return Ok(result);
        }

        [HttpPost]
        public IActionResult SaveNetwork([FromBody] SaveNetworkModel model)
        {
            if(model == null) 
                throw new ArgumentNullException(nameof(model));

            network_store.Save(model);

            return Ok();
        }
    }
}