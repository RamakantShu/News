using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webapi.IRepository;
using webapi.Repository;

namespace Angular6Project
{
  public class Startup
  {
    public IConfiguration Configuration { get; set; }
    public Startup(IHostingEnvironment env) 
    {   
      var builder = new ConfigurationBuilder()
      .SetBasePath(env.ContentRootPath)
      .AddJsonFile("appsettings.json");

      Configuration = builder.Build();  
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940    
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddSingleton<IConfiguration>(Configuration); 

      services.AddTransient<IAdminRepository, AdminRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }
      app.UseMvc();

      // app.Run(context => {  
      //           var status = Configuration["status"];   
      //           var connectionString = Configuration["ConnectionStrings:DefaultConnection"];  
      //           // context.Response.WriteAsync("Default Connection: " + connectionString);  
      //           // context.Response.WriteAsync("<br/>");  
      //            return context.Response.WriteAsync("Status: "+status);   
      //       });  
        
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseCookiePolicy();
    }
  }
}
