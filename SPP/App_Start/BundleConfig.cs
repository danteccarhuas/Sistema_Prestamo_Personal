using System.Web;
using System.Web.Optimization;

namespace SPP
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
             /*<====================================>*/

            bundles.Add(new ScriptBundle("~/Jquery").Include(
                  "~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                  "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bootstrapValidator/js").Include(
                "~/Scripts/bootstrapValidator.js"));

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
