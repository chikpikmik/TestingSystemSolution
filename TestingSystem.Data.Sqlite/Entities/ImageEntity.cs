namespace TestingSystem.Data.Sqlite.Entities
{
    public class ImageEntity
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        //public BitmapImage GetImage()
        //{
        //    if (Data == null || Data.Length == 0)
        //        return null;

        //    using var stream = new MemoryStream(Data);
        //    var image = new BitmapImage();
        //    image.BeginInit();
        //    image.CacheOption = BitmapCacheOption.OnLoad;
        //    image.StreamSource = stream;
        //    image.EndInit();
        //    image.Freeze();
        //    return image;
        //}
    }
}
