using System;
using System.Linq;
using System.Net;

namespace StarWarsAPI.Helpers
{
    internal class RequestHelper
    {
        /// <summary>
        /// Evita o erro de cabeçalhos com caracteres CR e LF.
        /// </summary>
        /// <param name="request"></param>
        public static void ContainsVary(HttpWebRequest request)
        {
            if (request.Headers.AllKeys.Contains("Vary"))
                request.Headers["Vary"] = "Accept";
            else
                request.Headers.Add("Vary", "Accept");
        }

        /// <summary>
        /// Verifica de existe autenticação via proxy.
        /// </summary>
        /// <param name="request"></param>
        public static void ProxyAuthentication(HttpWebRequest request)
        {
            IWebProxy proxy = request.Proxy;

            if (proxy != null)
            {
                WebProxy myProxy = new WebProxy();
                string uri = proxy.GetProxy(request.RequestUri).ToString();
                Uri newUri = new Uri(uri);
                myProxy.Address = newUri;
                myProxy.Credentials = new NetworkCredential("proxyLogin", "proxyPass");
                request.Proxy = myProxy;
                request.ProtocolVersion = HttpVersion.Version10;
            }
        }
    }
}
