using System.IO;
using System.Linq;
using System.Web;
using PortfolioCMS.Business.Services.Images.Contracts;

namespace PortfolioCMS.Business.Services.Images
{
    public class ImageService : IImageService
    {
        public const string PageContentSavePath = "~/Images/PageContent/";

        public bool IsImageFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return false;
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

        public bool ProcessImage(HttpPostedFileBase imageToProcess)
        {
            var isSuccessful = true;

            if (imageToProcess != null && this.IsImageFile(imageToProcess))
            {
                var path = Path.Combine(PageContentSavePath + imageToProcess.FileName);
                imageToProcess.SaveAs(path);
            }
            else
            {
                isSuccessful = false;
            }

            return isSuccessful;
        }
    }
}
