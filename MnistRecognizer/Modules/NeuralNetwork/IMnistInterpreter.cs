using System.Drawing;

namespace MnistRecognizer.Modules.NeuralNetwork
{
    public interface IMnistInterpreter
    {
        double[] Evaluate(Bitmap img);
    }
}