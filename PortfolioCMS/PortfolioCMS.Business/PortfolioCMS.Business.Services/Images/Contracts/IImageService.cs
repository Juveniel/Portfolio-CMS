using System.Web;

namespace PortfolioCMS.Business.Services.Images.Contracts
{
    public interface IImageService
    {      
        bool IsImageFile(HttpPostedFileBase file);

        string MapPath(string path);

        bool ProcessImage(HttpPostedFileBase imageToProcess);
    }
}