using MnistRecognizer.Models;
using MnistRecognizer.Modules.Database;
using System.Collections.Generic;

namespace MnistRecognizer.Modules.Storage
{
    public interface INetworkProposalStorage
    {
        void Save(NetworkModel model, Db db);
        List<NetworkModel> GetModels(Db db);
        string Zip(Db db);
    }
}