using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TestingSystem.Wpf.Utils
{
    public class ImageConverter
    {

        public static ImageSource ByteArrayToImageSource(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            using var stream = new MemoryStream(imageData);
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();
            image.Freeze();
            return image;
        }

    }
}
