namespace CleanArchitecture.Web.Extentions;

public static class BuilderExtentions
{
    public static void AddDI(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<>();
    }
}
