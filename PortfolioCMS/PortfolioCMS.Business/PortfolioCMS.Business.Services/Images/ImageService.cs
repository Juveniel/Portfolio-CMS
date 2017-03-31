using System.IO;
using System.Linq;
using System.Web;
using PortfolioCMS.Business.Services.Images.Contracts;

namespace PortfolioCMS.Business.Services.Images
{
    public class ImageService : IImageService
    {
        public bool IsImageFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return true;
            }

            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (allowedExtensions.Contains(fileExtension))
            {
                return true;
            }

            return false;
        }

        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}
