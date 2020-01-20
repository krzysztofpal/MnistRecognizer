using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MnistRecognizer.Models
{
    public class HistoryModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int numerPrzedstawiany { get; set; }
        public string nazwaObrazka { get; set; }
        [NotMapped]
        public double[] results
        {
            get => JsonConvert.DeserializeObject<double[]>(resultsString);
            set => resultsString = JsonConvert.SerializeObject(value);
        }
        public string resultsString { get; set; }
    }
}
