using Microsoft.Extensions.DependencyInjection;

namespace GoldenReports.API.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddGoldenReportsControllers(this IMvcBuilder mvcBuilder)
    {
        return mvcBuilder.AddApplicationPart(typeof(MvcBuilderExtensions).Assembly);
    }
}