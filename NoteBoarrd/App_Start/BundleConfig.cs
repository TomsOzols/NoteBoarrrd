using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace NoteBoarrd
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/bootstrap.js"
                ));

            bundles.Add(new StyleBundle("~/Content/Layout").Include(
                    "~/Content/LayoutStyle.css",
                    "~/Content/AuthenticationStyle.css",
                    "~/Content/bootstrap.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/board").Include(
                    "~/Scripts/BoardScripts.js"
                ));
        }
    }
}
