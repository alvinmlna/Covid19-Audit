using System.Web;
using System.Web.Optimization;

namespace Covid19_Audit
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/ManagementWalkAbout").Include("~/Content/ManagementWalkAbout.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/dataTables.bootstrap.min.js",
                      "~/Scripts/jquery.fancybox.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/listboxScript").Include(
                        "~/Scripts/listbox.js"));

            bundles.Add(new StyleBundle("~/Content/listboxCss").Include(
                      "~/Content/listbox.css"
                      ));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/themes/base/dataTables.bootstrap.min.css",
                      "~/Content/jquery.fancybox.min.css",
                      "~/Content/icheck-bootstrap.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/ManagementWalkAboutJS").Include("~/Scripts/Sidebar.js"));
        }
    }
}
