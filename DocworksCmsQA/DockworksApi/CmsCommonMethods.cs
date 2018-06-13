using DocWorksQA.DockworksApi;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocWorksQA.CmsApiMethods
{
    public class CmsCommonMethods
    {
        public static JObject CreateProject(WSAPIClient client, Dictionary<string, object> data, string token)
        {
            JObject c = (JObject)client.SendPost("api/Projects", data, token);
            Assert.NotNull(c);
            return c;
        }


        public JObject GetProjects(WSAPIClient client, string token)

        {
            JObject c = (JObject)client.SendGet("api/Projects", token);
            Assert.NotNull(c);
            return c;
        }

        public static JObject GetResponse(WSAPIClient client, String responseID, string token)
        {
            JObject c = (JObject)client.SendGet("api/Responses/" + responseID, token);
            Assert.NotNull(c);
            return c;
        }


        public static string GetResponseCompleteExecution(WSAPIClient client, String responseID, string token)
        {

            string status = "";
            for (int i = 0; i < 50; i++)
            {
                JObject r = CmsCommonMethods.GetResponse(client, responseID, token);
                Console.WriteLine(r);


                status = r.GetValue("status").ToString();

                Console.WriteLine("Current Status of Response ID (" + responseID + ") : " + status);
                if (!status.Equals("1"))
                {
                    Console.WriteLine("Current Status of Response ID (" + responseID + ") : " + status);
                    System.Threading.Thread.Sleep(4000);
                }
                else
                {
                    break;
                }

            }
            return status;
        }


    



    }
}
