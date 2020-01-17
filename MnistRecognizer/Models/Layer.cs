using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MnistRecognizer.Models
{
    public class Layer
    {
        public int KernelLength { get; set; }
        public int KernelWidth { get; set; }
        public int Stride { get; set; }
        public int Padding { get; set; }
    }
}
