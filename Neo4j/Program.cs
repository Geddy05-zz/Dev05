using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4j
{

    class Program
    {

        static void Main(string[] args)
        {
            //Connect to the graph database
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"));

            client.Connect();
            //removeActor(client);
            createActor(client);
            updateActor(client);
            actorInfo(client);
            MovieInfo(client);

            Console.ReadKey();
        }

        public static void actorInfo(GraphClient client)
        {
            var result =
                client.Cypher
                .Match("(n {name:'Olson Yarzagaray'})")
                .Return(n => n.As<actor>())
                .Results;
            foreach (actor a in result)
            {
                Console.WriteLine(a.name + " " + a.id);
            }


        }
        public static void MovieInfo(GraphClient client)
        {
            var title = "Independence Day";
            var result =
                client.Cypher
                .Match("(n {title:'"+title+"'})")
                .Return(n => n.As<movie>())
                .Results;
            foreach (movie m in result)
            {
                Console.WriteLine(m.title + " " + m.runtime);
                Console.WriteLine(m.description);

            }
        }
        public static void createActor(GraphClient client)
        {
            var actor = client.Create(new actor() { 
                name = "Geddy Schellevis", 
                id = 50500505 });
        }
        public static void removeActor(GraphClient client)
        {
            client.Cypher
            .Match("(n {name:'Geddy Schellevis'})")
            .Delete("n")
            .ExecuteWithoutResults();
        }
        public static void updateActor(GraphClient client)
        {
            client.Cypher
                .Match("(n {name:'Geddy Schellevis'})")
                .Set("n.name={name}")
                .WithParam("name", "Olson Yarzagaray")
                .ExecuteWithoutResults();
        }

    }
    class movie
    {
        public string type { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public long releaseDate { get; set; }
        public string title { get; set; }
        public string tagLine { get; set; }
        public string language { get; set; }
        public string imageUrl { get; set; }
        public long lastModified { get; set; }
        public string genre { get; set; }
        public string studio { get; set; }
        public string trailer { get; set; }
        public string imdbId { get; set; }
        public int version { get; set; }
        public string homepage { get; set; }
        public int runtime { get; set; }
    }

    class actor
    {
        public string type { get;set;}
        public string name {get;set;}
        public int id {get;set;}
        public long lastModified {get;set;}
        public int version {get;set;}
        public string imageUrl{get;set;}
        public string biography { get; set; }

    }
}

