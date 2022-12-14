using System.Web;
using System.Web.Optimization;

namespace Project_Manager
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/jquery.min.js",
                      "~/Content/js/popper.min.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/jquery.magnific-popup.min.js",
                      "~/Content/js/jquery.pogo-slider.min.js",
                      "~/Content/js/slider-index.js",
                      "~/Content/js/smoothscroll.js",
                      "~/Content/js/form-validator.min.js",
                      "~/Content/js/contact-form-script.js",
                      "~/Content/js/isotope.min.js",
                      "~/Content/js/images-loded.min.js" ,
                      "~/Content/js/custom.js")); 

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/pogo-slider.min.css",
                      "~/Content/css/style.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/custom.css"));
        }

    }
}
