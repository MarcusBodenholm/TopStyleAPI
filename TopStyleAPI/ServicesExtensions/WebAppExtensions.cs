namespace TopStyleAPI.ServicesExtensions
{
    public static class WebAppExtensions
    {
        public static void ConfigureWebApp(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
