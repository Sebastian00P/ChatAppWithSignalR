using System.Drawing;

namespace ChatAppWithSignalR.Helpers
{
    public static class DefaultImageSetter
    {
        private readonly static string ImgPath = "./Images/default.png";

        public static string GetDefaultPhoto()
        {
            using (Image image = Image.FromFile(ImgPath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}
