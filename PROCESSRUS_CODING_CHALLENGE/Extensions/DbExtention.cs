namespace PROCESSRUS_CODING_CHALLENGE.Extensions;
public static class DbExtention
{
    public static void ConfigureDBContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<APIContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("DbConnection"), 
                    b => b.MigrationsAssembly("PROCESSRUS_CODING_CHALLENGE")));

}
