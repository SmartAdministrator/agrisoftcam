﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using kiwi;

namespace kiwi
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code qui s'exécute au démarrage de l'application
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code qui s'exécute à l'arrêt de l'application

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code qui s'exécute lorsqu'une erreur non gérée se produit

        }
    }
}
