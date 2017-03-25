namespace PortfolioCMS.Business.Models.Content.Contracts
{
    public interface IPageContent
    {
        int Id { get; set; }

        string SectionName { get; set; }
   
        string Title { get; set; }

        string Content { get; set; }

        string Image { get; set; }
    }
}