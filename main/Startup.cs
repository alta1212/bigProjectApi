using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using BUS;
using DAL;
using DAL.Helper;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace main
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "main", Version = "v1" });
            });
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            
            IServiceCollection serviceCollections = services.AddTransient<IDatabaseHelper, DatabaseHelper>();
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)    
                    .AddJwtBearer(options =>    
                    {    
                        options.TokenValidationParameters = new TokenValidationParameters    
                        {    
                            ValidateIssuer = true,    
                            ValidateAudience = true,    
                            ValidateLifetime = true,    
                            ValidateIssuerSigningKey = true,    
                            ValidIssuer = Configuration["Jwt:Issuer"],    
                            ValidAudience = Configuration["Jwt:Issuer"],    
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))    
                        };    
                    });   
          
            services.AddTransient< DAL.Interface.IproductDAL , productRepository>();
            services.AddTransient<BUS.Interface.IproductBUS, productBusiness>();
             services.AddTransient< DAL.Interface.IcategorytDAL , CategoryRepository>();
            services.AddTransient<BUS.Interface.ICategoriesBUS, CategoriesBusiness>();

            services.AddTransient< DAL.Interface.IuserDAL , userRepository>();
            services.AddTransient<BUS.Interface.IuserBUS, userBusiness>();

             services.AddTransient< DAL.Interface.IadminDAL , adminRepository>();
            services.AddTransient<BUS.Interface.IadminBUS, adminBusiness>();
            services.AddCors(options =>options.AddPolicy("*",
                builder=>builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                             
            ));
                  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "main v1"));
            }

            app.UseHttpsRedirection();

           
            app.UseCors("*");
         
           
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}