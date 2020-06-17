using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjPortadorSindromeIrlen.Startup))]
namespace ProjPortadorSindromeIrlen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }


      
}
