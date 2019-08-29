using System.Net;

namespace StarWarsAPI.Helpers
{
    internal class ProtocolsHelper
    {
        /// <summary>
        /// Utilizado para URL's que possuem nível de segurança (https).
        /// </summary>
        public static void SecurityProtocol()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Tls12
#pragma warning disable CS0618 // Type or member is obsolete
                | SecurityProtocolType.Ssl3;
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
