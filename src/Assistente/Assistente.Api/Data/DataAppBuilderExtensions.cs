namespace Assistente.Api.Data
{
    public static class DataAppBuilderExtensions
    {
        public static IApplicationBuilder ConfigureDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
                dbContext.Database.EnsureCreated();
            }

            return app;
        }
    }
}
