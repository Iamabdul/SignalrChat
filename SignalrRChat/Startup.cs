using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SignalrRChat
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();
            services.AddCors(options =>
            {
                options.AddPolicy("ClientPermission", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        //.WithOrigins("http://localhost:5000")
                        .AllowCredentials();
                });
            });
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseCors("ClientPermission");
            application.UseRouting();
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/hubs/chat");
            });
        }
    }
}