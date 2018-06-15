using DocWorksQA.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocworksCmsQA.DatabaseScripts
{
    public class DatabaseScripts
    {
        String id;
        MongoClient Client;
       String dbName;
        
        public DatabaseScripts() {

            var conString = ConfigurationHelper.Get<String>("dbconnection") + "&ssl=true";
            dbName = ConfigurationHelper.Get<String>("dbname");
            Client = new MongoClient(new MongoUrl(conString));
                        

        }

        public void FindProjectAndDelete(String projectName) {
            Console.WriteLine("Finding the project to Delete. "+projectName);

            var DB = Client.GetDatabase(dbName);
            var collection = DB.GetCollection<BsonDocument>("Project");
            var Filter = new BsonDocument("ProjectName", projectName);
            var list = collection.Find(Filter).ToListAsync().Result.FirstOrDefault();

            Console.WriteLine("Projects Found : "+list);
            id = list.GetValue("_id").ToString();
            collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", id));
            System.Threading.Thread.Sleep(20000);
        
        }

        public void FindDistributionAndDelete(String distributionName)
        {
            Console.WriteLine("Finding the project to Delete. " + distributionName);

            var DB = Client.GetDatabase(dbName);
            var collection = DB.GetCollection<BsonDocument>("Distribution");
            var Filter = new BsonDocument("DistributionName", distributionName);
            var list = collection.Find(Filter).ToListAsync().Result.FirstOrDefault();

            Console.WriteLine("Distribution Found : " + list);
            id = list.GetValue("_id").ToString();
            collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", id));
            System.Threading.Thread.Sleep(10000);

        }


    }
}
