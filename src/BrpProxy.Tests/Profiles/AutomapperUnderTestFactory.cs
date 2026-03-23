using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace BrpProxy.Tests.Profiles;

public static class AutomapperUnderTestFactory
{
    public static IMapper CreateSut<T>() where T : Profile, new()
    {
        MapperConfiguration config = new(cfg =>
        {
            cfg.AddProfile<T>();
        }, NullLoggerFactory.Instance);
        return config.CreateMapper();
    }
}
