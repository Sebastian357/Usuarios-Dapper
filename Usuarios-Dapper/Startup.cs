using Usuarios_Dapper.DBOperaciones;

namespace Usuarios_Dapper
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = new ConexionDB(Configuration.GetConnectionString("testing"));
            services.AddSingleton(dbConnectionString);
            services.AddSingleton<IUsuariosSQL, UsuariosSQL>();
            services.AddSingleton<IClaimcitoSQL, ClaimcitoSQL>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting(); //lo agregamos, no viene de program

            app.UseAuthorization();

            //app.MapControllers(); no va, lo sacamos

            app.UseEndpoints(endpoints =>   //agregamos este
            {
                endpoints.MapControllers();
            });
        }

    }

}
