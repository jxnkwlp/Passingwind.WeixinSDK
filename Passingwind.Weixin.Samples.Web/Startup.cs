using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Passingwind.Weixin.MP;
using Passingwind.Weixin.Security;

namespace Passingwind.Weixin.Samples.Web
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

            WeixinServiceRegister.Register()
                .AddLogger<WeixinApiLogger>()
                .AddMpService();

            WeixinMpApiContainer.Register(new MPAccount()
            {
                AppId = Configuration.GetValue<string>("WeiXinMp:AppID"),
                AppSecret = Configuration.GetValue<string>("WeiXinMp:AppSecret"),
                Token = Configuration.GetValue<string>("WeiXinMp:Token"),
            });

            services.AddSingleton((s) => WeixinMpApiContainer.GetInstance("default"));
            services.AddSingleton<IBizMessageCryptService, BizMessageCryptService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
