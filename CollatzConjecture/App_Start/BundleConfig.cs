using System.Web;
using System.Web.Optimization;

namespace CollatzConjecture
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

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                      "~/Scripts/Chart.bundle.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //"~/Content/PagedList.css")); 
            //suggestion to use came from ASP tutorial
            // https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
            //index.cshtml: <link href="~/Content/PagedList.css" rel="stylesheet" type="text/css" />
            //I believe actual file came from PagedList NuGet package
            //not using because the verbatim code is duplicated in bootstrap.css
            //according to stack overflow post
            //https://stackoverflow.com/questions/5902858/order-of-prioritization-when-using-multiple-contradictory-css-files
            //which file gets used is based on the order that the .css
            //files are loaded, which could cause a confusing situation!
        }
    }
}
