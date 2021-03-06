﻿namespace PortfolioCMS.Business.Services.Mappings.Contracts
{
    public interface IMappingService
    {
        T Map<T>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        TDestination Map<TSource, TDestination>(TSource newObject);
    }
}