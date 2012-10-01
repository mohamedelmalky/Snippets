using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace LogView.Helpers
{
    public static class HtmlHelperMethods
    {
        const string tag = "RequiredScripts";

        /// <summary>
        /// Requests a script to be added to the page
        /// </summary>
        /// <param name="html"></param>
        /// <param name="path">Path to the script file</param>
        public static void RequireScript(this HtmlHelper html, string path)
        {
            var requiredScripts = HttpContext.Current.Items[tag] as List<string>;
            
            if(requiredScripts == null)
                HttpContext.Current.Items[tag] = requiredScripts = new List<string>();

            if(!requiredScripts.Contains(path))
                requiredScripts.Add(path);
        }

        /// <summary>
        /// Loads all required scripts in the appropriate Scripts razor section
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static HtmlString IncludeRequiredScripts(this HtmlHelper html)
        {
            var requiredScripts = HttpContext.Current.Items[tag] as List<string>;
            if(requiredScripts == null)
                return null;

            string result = string.Empty;

            requiredScripts.ForEach(x => result += String.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", x));

            return new HtmlString(result);
        }
    }
}