using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MnistRecognizer.Models;
using MnistRecognizer.Modules.Database;
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

        public void Save(NetworkModel model, Db db)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();
            db.Entry(model).GetDatabaseValues();
            model.Layers.ToList().ForEach(x => x.NetworkID = model.ID);
            model.Layers.ToList().ForEach(x => db.Entry(x).State = Microsoft.EntityFrameworkCore.EntityState.Added);
            db.SaveChanges();
        }

        public List<NetworkModel> GetModels(Db db)
        {
            var n = db.Networks.Include(x=>x.Layers).Where(x=>x.Layers != null && x.Layers.Count >= 2).ToList();
            n.ForEach(x => x.Layers.ForEach(y => y.Network = null));
            return n;
        }

        /// <summary>
        /// Generates JSON file from all the history
        /// </summary>
        /// <returns></returns>
        public string Zip(Db db)
        {
            var models = GetModels(db);

            string temp = Path.Combine(host.ContentRootPath, "temp.json");
            if (File.Exists(temp))
                File.Delete(temp);

            var json = JsonConvert.SerializeObject(models);
            File.WriteAllText(temp, json);

            return temp;
        }
    }
}
