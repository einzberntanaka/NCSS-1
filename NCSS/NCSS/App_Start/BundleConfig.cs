using System.Web;
using System.Web.Optimization;
namespace NCSS.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/AdminPage").Include(
            ));
            bundles.Add(new ScriptBundle("~/js/Chart").Include(
            ));
            bundles.Add(new ScriptBundle("~/Content/CK").Include(
            ));
        }
    }
}