using Microsoft.AspNetCore.Hosting;
using NNSharp.DataTypes;
using NNSharp.IO;
using NNSharp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MnistRecognizer.Modules.NeuralNetwork
{
    public class MnistCnnNetwork : IMnistInterpreter
    {
        string cnn_nn => Path.Combine(host.ContentRootPath, "cnn-release.json");
        SequentialModel model;
        IWebHostEnvironment host;

        public MnistCnnNetwork(IWebHostEnvironment host)
        {
            this.host = host;
        }

        public double[] Evaluate(Bitmap img)
        {
            if (model == null)
            {
                var reader = new ReaderKerasModel(cnn_nn);
                model = reader.GetSequentialExecutor();
            }

            var array = new Data2D(28, 28, 1, 1);

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    Color pixel = img.GetPixel(j, i);
                    double value = 255 - pixel.A;
                    value = value / 255;

                    array[i, j, 0, 0] = value;
                }
            }

            var result = model.ExecuteNetwork(array) as Data2D;

            double[] toreturn = new double[10];

            for (int i = 0; i < 10; i++)
            {
                toreturn[i] = result[0, 0, i, 0];
            }

            return toreturn;
        }
    }
}
