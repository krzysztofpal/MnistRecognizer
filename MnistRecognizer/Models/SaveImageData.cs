using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MnistRecognizer.Models
{
    public class SaveImageData
    {
        public string Base64 { get; set; }
        public int Number { get; set; }
        public byte[] ImageBytes()
        {
            return Convert.FromBase64String(Base64);
        }
    }
}
