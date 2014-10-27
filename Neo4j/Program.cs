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
            //My test actor
            Actor ac = new Actor();
            ac.name = "Panda stick";
            ac.id = 4646464;
            ac.imageUrl = "http://www.pandaworkthis.bear";
            ac.lastModified = 342545246;
            ac.version = 1;
            //ac.biography = "This is mr Panda WITHOUT any update done to it";
            //ac.biography = "This is mr Panda WITH update done to it, YEAH BABY";

            updateActor(client, ac);

            // My Test movie
            Movie mc = new Movie();
            mc.title = "Knife after dark2";
            mc.runtime = 200;
            mc.lastModified = 3243;
            mc.tagLine = "Scary";

            //createNode(client, ac,"Actor");
            
            //createNode(client, mc,"Movie");
            //actorInfo(client);
            //MovieInfo(client);
            //removeNode(client, ac);
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
                .Return(n => n.As<Director>())
                .Results;
            foreach (Director a in result)
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
                .Return(n => n.As<Movie>())
                .Results;
            foreach (Movie m in result)
            {
                Console.WriteLine(m.title + " " + m.runtime);
                Console.WriteLine(m.description);

            }
        }
        // CRUD operations for NEO4J
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

        // The following methods deletes the nodes in neo4j
        public static void removeActor(GraphClient client, Actor acteur)
        {
            client.Cypher
            .Match("(a:Actor)")
            .Where((Actor a) => a.name == acteur.name)
            .Delete("a")
            .ExecuteWithoutResults();
        }

        public static void removeDirector(GraphClient client, Director dir)
        {
            client.Cypher
            .Match("(d:Director)")
            .Where((Director d) => d.name == dir.name)
            .Delete("d")
            .ExecuteWithoutResults();
        }

        public static void removeMovie(GraphClient client, Movie mov)
        {
            client.Cypher
            .Match("(m:Movie)")
            .Where((Movie m) => m.title == mov.title)
            .Delete("m")
            .ExecuteWithoutResults();
        }

        //The following methods updates the nodes in neo4j
        public static void updateActor(GraphClient client, Actor acteur)
        {
            client.Cypher
                .Match("(a:Actor)")
                .Where((Actor a) => a.name == acteur.name)
                .Set("a = {updateActeur}")
                .WithParam("updateActeur", acteur)
                .ExecuteWithoutResults();
        }

        public static void updateDirector(GraphClient client, Director dir)
        {
            client.Cypher
                .Match("(d:Director)")
                .Where((Director d) => d.name == dir.name)
                .Set("d = {updateDir}")
                .WithParam("updateDir", dir)
                .ExecuteWithoutResults();
        }

        public static void updateMovie(GraphClient client, Movie mov)
        {
            client.Cypher
                .Match("(m:Movie)")
                .Where((Movie m) => m.title == mov.title)
                .Set("m = {updateMov}")
                .WithParam("updateMov", mov)
                .ExecuteWithoutResults();
        }


    }
    // The class Movie, Director and Actor represents the nodes in the neo4j database
    class Movie
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

    class Director
    {
        public string type { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public long lastModified { get; set; }
        public int version { get; set; }
        public string imageUrl { get; set; }
        public string biography { get; set; }

    }

    class Actor
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

