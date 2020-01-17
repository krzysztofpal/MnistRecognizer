using Microsoft.AspNetCore.Hosting;
using MnistRecognizer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MnistRecognizer.Modules.Storage
{
    public class NetworkProposalStorage : INetworkProposalStorage
    {
        IWebHostEnvironment host;

        public NetworkProposalStorage(IWebHostEnvironment host)
        {
            this.host = host ?? throw new ArgumentNullException(nameof(host));
        }

        public void Save(SaveNetworkModel model)
        {
            string folder = Path.Combine(host.ContentRootPath, "network-proposals-storage");

            if (Directory.Exists(folder) == false)
                Directory.CreateDirectory(folder);

            string file_path = Path.Combine(folder, Guid.NewGuid().ToString());

            var json = JsonConvert.SerializeObject(model);

            File.WriteAllText(file_path + ".json", json);
        }

        public List<SaveNetworkModel> GetModels()
        {
            string folder = Path.Combine(host.ContentRootPath, "network-proposals-storage");

            if (Directory.Exists(folder) == false)
                return null;

            var models = new List<SaveNetworkModel>();

            foreach(var file in Directory.GetFiles(folder))
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var o = JsonConvert.DeserializeObject<SaveNetworkModel>(json);
                    models.Add(o);
                }
                catch (Exception) { }
            }

            return models;
        }
    }
}
