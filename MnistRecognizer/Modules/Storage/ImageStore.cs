using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace MnistRecognizer.Modules.Storage
{
    public class ImageStore : IImageStore
    {
        private readonly IWebHostEnvironment host;

        public ImageStore(IWebHostEnvironment _host)
        {
            host = _host;
        }

        public string SaveImage(byte[] image, int image_class)
        {
            string content_path = host.ContentRootPath;

            string path_to_storage = Path.Combine(content_path, "image_store");

            if (Directory.Exists(path_to_storage) == false)
                Directory.CreateDirectory(path_to_storage);

            string path_to_destination = Path.Combine(path_to_storage, image_class.ToString());

            if (Directory.Exists(path_to_destination) == false)
                Directory.CreateDirectory(path_to_destination);

            string file_path = Path.Combine(path_to_destination, Guid.NewGuid().ToString() + ".png");

            File.WriteAllBytes(file_path, image);

            return file_path;
        }

        public int ImagesCount()
        {
            string content_path = host.ContentRootPath;

            string path_to_storage = Path.Combine(content_path, "image_store");
            if (Directory.Exists(path_to_storage) == false)
                return 0;

            int count = 0;

            for(int i = 0; i < 10; i++)
            {
                string directory_path = Path.Combine(path_to_storage, i.ToString());

                if (Directory.Exists(directory_path))
                {
                    count += Directory.GetFiles(directory_path).Length;
                }
            }

            return count;
        }

        public string GetAbsolutePath(string type, string name)
        {
            string path = Path.Combine(host.ContentRootPath, "image_store", type, name);
            if (System.IO.File.Exists(path))
                return path;
            else
                return null;
        }

        public string[] GetAllImagesNames(int type)
        {
            if (type < 0 || type > 9)
                return null;

            string path = Path.Combine(host.ContentRootPath, "image_store", type.ToString());

            if (Directory.Exists(path) == false)
                return null;

            var files = Directory.GetFiles(path);

            files = files.Select(x => Path.GetFileName(x)).ToArray();

            return files;
        }

        public string ZipRepo()
        {
            string temp = Path.Combine(host.ContentRootPath, "temp.zip");
            if (File.Exists(temp))
                File.Delete(temp);

            string path = Path.Combine(host.ContentRootPath, "image_store");

            ZipFile.CreateFromDirectory(path, temp, CompressionLevel.Optimal, true);

            return temp;
        }

        public string ZipImagesOfType(int type)
        {
            if (type < 0 || type > 9)
                return null;

            string path = Path.Combine(host.ContentRootPath, "image_store", type.ToString());

            if (Directory.Exists(path) == false)
                return null;

            string temp = Path.Combine(host.ContentRootPath, "temp.zip");
            if (File.Exists(temp))
                File.Delete(temp);

            ZipFile.CreateFromDirectory(path, temp, CompressionLevel.Optimal, true);
            return temp;
        }
    }
}
