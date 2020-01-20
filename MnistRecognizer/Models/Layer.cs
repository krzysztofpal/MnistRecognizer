using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MnistRecognizer.Models
{
    public class Layer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey(nameof(Network))]
        public int NetworkID { get; set; }
        public int KernelLength { get; set; }
        public int KernelWidth { get; set; }
        public int Stride { get; set; }
        public int Padding { get; set; }

        public virtual NetworkModel Network { get; set; }
    }
}
