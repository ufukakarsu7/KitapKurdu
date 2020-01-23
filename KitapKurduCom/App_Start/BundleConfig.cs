using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace KitapKurdu.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/js/vendor/jquery-3.2.1.min.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/js/vendor/modernizr-3.5.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/popper").Include("~/js/popper.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/plugins").Include("~/js/plugins.js"));
            bundles.Add(new ScriptBundle("~/bundles/active").Include("~/js/active.js"));
            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include("~/Scripts/ckeditor/ckeditor.js"));

            bundles.Add(new StyleBundle("~/css").Include("~/css/bootstrap.min.css","~/css/custom.css","~/css/plugins.css", "~/style.css"));
        }
    }
}