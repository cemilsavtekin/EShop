using System.Web;
using System.Web.Optimization;

namespace EShop.Web.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/content")
                .Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/prettyPhoto.css",
                "~/Content/css/price-range.css",
                "~/Content/css/animate.css",
                "~/Content/css/main.css",
                "~/Content/css/responsive.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/script")
                .Include(
                "~/Scripts/js/jquery.js",
                "~/Scripts/js/bootstrap.min.js",
                "~/Scripts/js/jquery.scrollUp.min.js",
                "~/Scripts/js/price-range.js",
                "~/Scripts/js/jquery.prettyPhoto.js",
                "~/Scripts/js/main.js",
                "~/Scripts/Utils.js"
                ));
        }

    }
}