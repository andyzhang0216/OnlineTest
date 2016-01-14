using Microsoft.Azure.ActiveDirectory.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectToAuzre();
            Console.ReadLine();
        }

        static void ConnectToAuzre()
        {
            string u = "andyzhang@gaoojian1.onmicrosoft.com";
            try
            {
                MicrosoftOnlineInstanceDetail detail = MicrosoftOnlineInstance.FromDomainOrPrincipalName(u);
                LogOnServiveAndGetToken(detail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static void LogOnServiveAndGetToken(MicrosoftOnlineInstanceDetail detail)
        {

            string u = "andyzhang@gaoojian1.onmicrosoft.com";
            string p = "1qaz2wsxE";
            string f = detail.FederationProviderIdentifier;
            string m = "ps." + detail.MsodsEndpointDomainNameSuffix;
            string po = "MCMBI";
            AzureNativeMethods
        }
    }
}
