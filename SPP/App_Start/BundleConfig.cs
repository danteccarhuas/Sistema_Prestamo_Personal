using System.Web;
using System.Web.Optimization;

namespace SPP
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
              "~/Content/bootstrap.css",
              "~/Content/site.css"));

            /*<====================================>*/

            bundles.Add(new ScriptBundle("~/Jquery").Include(
                  "~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                  "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/datepicker/js").Include(
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/bootstrap-datepicker.es.min.js"));

            bundles.Add(new ScriptBundle("~/menu/js").Include(
                  "~/Scripts/plugins/morris/raphael.min.js",
                  "~/Scripts/plugins/morris/morris.min.js"));

            bundles.Add(new StyleBundle("~/loguin/css").Include(
                            "~/css/login.css"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                "~/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/datepicker/css").Include(
                "~/css/datepicker.css"));

            bundles.Add(new StyleBundle("~/menu/css").Include(
                "~/css/sb-admin.css",
                "~/css/plugins/morris.css",
                "~/font-awesome/css/font-awesome.min.css"));
        }
    }
}
