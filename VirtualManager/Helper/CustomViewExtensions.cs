using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualManager.Helper {
    public static class CustomViewExtensions {

        /// <summary>
        /// Create custom html section
        /// </summary>
        /// <param name="Helper"></param>
        /// <param name="url">Url</param>
        /// <param name="style">HTML CSS style</param>
        /// <returns>Return string</returns>
        public static string CustomUrl(this HtmlHelper Helper, string url, params string[] style){
            string tagStyle = string.Empty;
            try {
                foreach (var s in style) {
                    tagStyle += style;
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);        
            }

            return tagStyle;
        }


    }
}