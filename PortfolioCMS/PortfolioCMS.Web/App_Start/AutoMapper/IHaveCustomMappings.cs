using AutoMapper;

namespace PortfolioCMS.Web.App_Start.AutoMapper
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}