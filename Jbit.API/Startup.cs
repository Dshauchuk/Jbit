using Jbit.API.Data;
using Jbit.API.Services;
using Jbit.API.Services.Contracts;
using Jbit.Common.Auth;
using Jbit.Common.Auth.Extensions;
using Jbit.Common.Auth.Interfaces;
using Jbit.Common.Auth.Services;
using Jbit.Common.Data;
using Jbit.Common.Models;
using Jbit.Common.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jbit.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // db context registration
            var dbContextBuilder = new DbContextOptionsBuilder<JbitDbContext>();
            dbContextBuilder.UseNpgsql(Configuration.GetValue<string>("db:connectionString"));
            services.AddTransient<JbitDbContext>(i => new JbitDbContext(dbContextBuilder.Options));
            services.AddTransient<DbContext>(i => new JbitDbContext(dbContextBuilder.Options));

            var section = Configuration.GetSection("AuthOptions");
            var options = section.Get<AuthOptions>();
            var jwtOptions = new JwtOptions(options.Audience, options.Issuer, options.Secret, options.Lifetime);
            services.AddApiJwtAuthentication(jwtOptions);

            services.AddHttpContextAccessor();
            services.AddTransient<IRatingCalculator, RatingCalculator>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Person>, Repository<Person>>();
            services.AddTransient<IRepository<Identity>, Repository<Identity>>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
