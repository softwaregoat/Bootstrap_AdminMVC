using System.Web.Optimization;

namespace admindx
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/popper_umd.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //////////////////////////CREAR LOTE///////////////////////////////////
            bundles.Add(new ScriptBundle("~/bundles/loteCreate").Include(
                        "~/Scripts/loteCreate.js"));
            ////////////////////////MULTI SELECT/////////////////////////////////
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-select-js").Include(
                      "~/Scripts/bootstrap-select.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-select-js-es").Include(
                      "~/Scripts/i18n/defaults-es_ES.min.js"));
            bundles.Add(new StyleBundle("~/Content/bootstrap-select-css").Include(
                      "~/Content/bootstrap-select.min.css"));
        }
    }
}