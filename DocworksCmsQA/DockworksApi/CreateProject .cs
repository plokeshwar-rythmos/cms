using NUnit.Framework;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using DocWorksQA.CmsApiMethods;

namespace DocWorksQA.DockworksApi
{
    [TestFixture]
    class TC_06_CreateProject
    {
      
        WSAPIClient client;

        String token;


       // [SetUp]
        public void Setup()
        {
            client = new WSAPIClient(Utilities.ConfigurationHelper.Get<String>("endpoint"));
            token = client.Login();
        }

      //  [Test]
        public void ValidateCreateProjectApiWithValidData()
        {
       
            var data = new Dictionary<string, object>
            {
                {"projectName","APITestGitLab" },
                {"RepositoryId", "6090611"},
                {"RepositoryName", "Docworks"},
                {"typeOfContent", 3},
                {"Description", "Project Description"},
                {"PublishedPath", "This is awesome"},
                {"SourceControlProviderType", "1"}
            };


            JObject c = CmsCommonMethods.CreateProject(client, data, token);
            Assert.NotNull(c);
            var responseID = c.GetValue("responseId").ToString();
            Console.WriteLine("Response ID " +responseID);
         
            try
            {
                String responseStatus = CmsCommonMethods.GetResponseCompleteExecution(client, responseID, token);
                Console.WriteLine(responseStatus);
         /*       if (responseStatus.Equals("1"))
                {
                    test.Fail("Still the process did not complete");
                }
                else if (responseStatus.Equals("3"))
                {
                    test.Fatal("Error Occurred");
                }
                else if (responseStatus.Equals("2"))
                {
                    test.Pass("The Create Project Completed Successfully");
                }

    */

            }
            catch (AssertionException)
            {
              //  test.Fail("Assertion failed");
                throw;
            }
        }

       // [TearDown]
        public void TearDown()
        {
        }

    }
}