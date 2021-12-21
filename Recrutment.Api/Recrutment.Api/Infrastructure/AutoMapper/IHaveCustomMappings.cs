namespace Recrutment.Api.Infrastructure.AutoMapper
{
    using global::AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
