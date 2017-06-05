using System.Web;
using System.Web.Optimization;

namespace MyCard
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/angular-material.css",
                      "~/Content/angular-material-icons/*.svg"
                      ));
           
            bundles.Add(new ScriptBundle("~/ng").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-material.js",
                "~/Scripts/angular-messages.js",
                "~/Scripts/angular-aria.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-touch.js"
                ));
            bundles.Add(new ScriptBundle("~/app").Include( 
                "~/Scripts/App/*.js",
                "~/Scripts/App/Controllers/*.js",
                "~/Scripts/App/Services/*.js"
                ));
        }
    }
}
