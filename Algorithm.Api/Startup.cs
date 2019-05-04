using Algorithm.Api.DataContexts;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Algorithm API", Version = "v1" });
            });

            services.AddElmah();

            switch (Configuration.GetSection("ActiveProvider").Value)
            {
                case "MSSQL":
                    services.AddDbContext<AlgorithmContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AlgorithmMSSQLContext")));
                    break;
                case "PostgreSQL":
                    services.AddEntityFrameworkNpgsql().AddDbContext<AlgorithmContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AlgorithmPostgreSQLContext")));
                    break;
                default:
                    break;
            }


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var key = Encoding.ASCII.GetBytes(Configuration["Application:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Audience = "SomeCustomApp";
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.ClaimsIssuer = "mineplaJWT.api.demo";
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = true
                };
                x.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = (context) =>
                    {
                        //context.Principal.Identity is ClaimsIdentity
                        //So casting it to ClaimsIdentity provides all generated claims
                        //And for an extra token validation they might be usefull
                        var name = context.Principal.Identity.Name;
                        if (string.IsNullOrEmpty(name))
                        {
                            context.Fail("Unauthorized. Please re-login");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Algorithm API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseElmah();

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
