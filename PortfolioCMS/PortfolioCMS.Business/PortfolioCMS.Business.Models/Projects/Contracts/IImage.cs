namespace PortfolioCMS.Business.Models.Projects.Contracts
{
    public interface IImage
    {
        int Id { get; set; }

        string Title { get; set; }

        string Path { get; set; }
    }
}