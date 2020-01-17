using NNSharp.DataTypes;
using NNSharp.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MnistTester.Testers
{
    public class XorTester
    {
        public const string xor_path = @"C:\Users\Admin\source\repos\MnistRecognizer\Models\xor-release.json";

        public IData Run()
        {
            var reader = new ReaderKerasModel(xor_path);
            var model = reader.GetSequentialExecutor();

            var arr = new Data2D(1, 1, 2, 4);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    arr[0, 0, j, i] = j == 0 ? i / 2 : i % 2;
                }
            }

            Data2D result = model.ExecuteNetwork(arr) as Data2D;
            return result;
        }
    }
}
