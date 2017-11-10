using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using SampleNetCoreWebApi.Configuration;

namespace SampleNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [Route("GetCollectionData")]
        public ActionResult GetCollectionData()
        {
            //const string connectionString = "mongodb://192.168.2.90:27027";
            string connectionString = MongoDBSettings.DBConnectionString;

            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            //var database = client.GetDatabase("sampleMongoDockerDB");
            var database = client.GetDatabase(MongoDBSettings.DatabaseName);

            var collection = database.GetCollection<Entity>("people");
            var documents = collection.Find(_ => true).ToList();
            
            return Ok(documents);
        }

        [HttpPost]
        [Route("PostCollectionData")]
        public ActionResult PostCollectionData(string entityName)
        {
            string connectionString = MongoDBSettings.DBConnectionString;

            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            //var database = client.GetDatabase("sampleMongoDockerDB");
            var database = client.GetDatabase(MongoDBSettings.DatabaseName);

            var collection = database.GetCollection<Entity>("people");
            var entity = new Entity { Name = entityName };
            collection.InsertOneAsync(entity);
            var id = entity._id;

            return Ok(id);
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Entity
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
    }

}


