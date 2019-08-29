using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarWarsAPI.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace StarWarsAPI.Controllers
{
    /// <summary>
    /// https://swapi.co
    /// </summary>
    internal class StarWarsController
    {
        /// <summary>
        /// Planets, Spaceships, Vehicles, People, Films and Species
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        internal static string SwApi(string p1, int p2)
        {
            var conteudo = String.Empty;

            //ProtocolsHelper.SecurityProtocol();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://swapi.co/api/{p1}/{p2}/");
            //request.Headers.Add("header1", "value1");
            //request.Headers.Add("header2", "value2");
            request.Method = "GET";
            request.Accept = "application/json";

            //RequestHelper.ProxyAuthentication(request);

            //RequestHelper.ContainsVary(request);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();

                return JToken.Parse(conteudo).ToString(Formatting.Indented);
            }
        }
    }
}
