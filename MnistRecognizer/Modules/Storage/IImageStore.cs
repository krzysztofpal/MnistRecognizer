namespace MnistRecognizer.Modules.Storage
{
    public interface IImageStore
    {
        string SaveImage(byte[] image, int image_class);
        int ImagesCount();
        string GetAbsolutePath(string type, string name);
        string[] GetAllImagesNames(int type);
        string ZipRepo();
        string ZipImagesOfType(int type);
    }
}