using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(Swagger.Startup))]

namespace Swagger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //SwaggerConfig.Register();
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API")).EnableSwaggerUi();
            httpConfiguration.EnsureInitialized();
        }
    }
}
