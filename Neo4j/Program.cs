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
            //Branch Olson
            //Connect to the graph database
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"));

            client.Connect();
            actor ac = new actor();
            ac.name = "Panda stick";
            ac.id = 4646464;
            ac.imageUrl = "http://www.pandaworkthis.bear";
            ac.lastModified = 342545246;
            ac.version = 1;

            

            movie mc = new movie();
            mc.title = "Knife after dark2";
            mc.runtime = 200;
            mc.lastModified = 3243;
            mc.tagLine = "Scary";

            //createNode(client, ac,"Actor");
            //createNode(client, mc,"Movie");
            actorInfo(client);
            MovieInfo(client);
            
            //removeActor(client);
            //createActor(client);
            //updateActor(client);
            //actorInfo(client);
            //MovieInfo(client);

            Console.ReadKey();
        }

        public static void actorInfo(GraphClient client)
        {
            var result =
                client.Cypher
                .Match("(n {name:'Panda stick'})")
                .Return(n => n.As<director>())
                .Results;
            foreach (director a in result)
            {
                Console.WriteLine(a.name + " " + a.id);
            }


        }
        public static void MovieInfo(GraphClient client)
        {
            var title = "Knife after dark2";
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
            var actor = client.Create(new director() { 
                name = "Geddy Schellevis", 
                id = 50500505 });
        }
        
        // This is a generic function that creates all the node necessary for this assignment
        public static void createNode(GraphClient client, Object newNode, String typeOfNode)
        {
            String nodeType;
            
            switch (typeOfNode)
            {
                case "Actor":
                    nodeType = "n:Actor";
                    break;
                case "Movie":
                    nodeType = "n:Movie";
                    break;
                case "Director":
                    nodeType = "n:Director";
                    break;
                default:
                    nodeType = "n";
                    break;

            }
            client.Cypher
                .Create("(" + nodeType + "{newNode})")
                .WithParam("newNode", newNode)
                .ExecuteWithoutResults();
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

    class director
    {
        public string type { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public long lastModified { get; set; }
        public int version { get; set; }
        public string imageUrl { get; set; }
        public string biography { get; set; }

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

