﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeninsonPrimerParcial.Startup))]
namespace DeninsonPrimerParcial
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
