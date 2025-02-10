using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPI_LM.Delegates;
using CustomerAPI_LM.Interfaces;
using CustomerAPI_LM.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomerAPI_LM
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.AddSingleton<GetCustomerByIdDelegate>(CustomerDelegates.GetCustomerById);
            services.AddSingleton<UpdateCustomerDelegate>(CustomerDelegates.UpdateCustomer);

            services.AddSingleton<GetEmployeeByIdDelegate>(EmployeeDelegates.GetEmployeeById);
            services.AddSingleton<UpdateEmployeeDelegate>(EmployeeDelegates.UpdateEmployee);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
