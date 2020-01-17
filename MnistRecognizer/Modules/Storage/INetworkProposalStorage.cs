using MnistRecognizer.Models;
using System.Collections.Generic;

namespace MnistRecognizer.Modules.Storage
{
    public interface INetworkProposalStorage
    {
        void Save(SaveNetworkModel model);
        List<SaveNetworkModel> GetModels();
    }
}