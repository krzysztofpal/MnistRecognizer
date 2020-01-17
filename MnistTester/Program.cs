using NNSharp.DataTypes;
using NNSharp.IO;
using System;
using System.Drawing;

namespace MnistTester
{
    class Program
    {

        const string xor_nn = @"C:\Users\Admin\source\repos\MnistRecognizer\Models\xor-release.json";
        const string cnn_nn = @"C:\Users\Admin\source\repos\MnistRecognizer\Models\cnn-release.json";

        const string zero_test_path = @"C:\Users\Admin\source\repos\MnistRecognizer\TestSamples\0.png";

        static void Main(string[] args)
        {
            var reader = new ReaderKerasModel(cnn_nn);
            var model = reader.GetSequentialExecutor();

            var array = new Data2D(28, 28, 1, 1);

            Bitmap img = new Bitmap(zero_test_path);
            for(int i = 0; i < img.Height; i++)
            {
                for(int j = 0; j < img.Width; j++)
                {
                    Color pixel = img.GetPixel(j,i);
                    double value = (pixel.R + pixel.G + pixel.B) / 3;
                    value = value / 255;

                    array[i, j, 0, 0] = value;
                }
            }   

            var result = model.ExecuteNetwork(array);
            int a = 5;
        }
    }
}
