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

            List<Movie> movieTestList = new List<Movie>();
            List<Actor> actorTestList1 = new List<Actor>();
            List<Actor> actorTestList2 = new List<Actor>();
            List<Director> directorTestList = new List<Director>();

            //Branch Olson
            //Connect to the graph database
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"));

            client.Connect();
            //My test actor
            Actor ac = new Actor();
            ac.name = "Keanu Reeves";
            /*
            ac.id = 4646464;
            ac.imageUrl = "http://www.pandaworkthis.bear";
            ac.lastModified = 342545246;
            ac.version = 1; */
            //ac.biography = "This is mr Panda WITHOUT any update done to it";
            //ac.biography = "This is mr Panda WITH update done to it, YEAH BABY";

            //updateActor(client, ac);

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
            //actorInfo(client, ac, actorTestList);
            //movieInfo(client, mc, movieTestList);

            actorsWhoPlayedMoreThanTwoFilms(client,ac,actorTestList1, actorTestList2);

            foreach(Actor a in actorTestList2)
            {
                Console.WriteLine("This is the nodes that you get" + a.name + " " + a.imageUrl);
            }

            Console.ReadKey();
        }

        public static void actorInfo(GraphClient client, Actor act, List<Actor> actList)
        {
            var result =
                client.Cypher
                .Match("(a:Actor)")
                .Where((Actor a) => a.name == act.name)
                .Return(a => a.As<Actor>())
                .Results;
            foreach (Actor a in result)
            {
                actList.Add(a);
            }


        }

        public static void directorInfo(GraphClient client, Director dir,List<Director> dirList)
        {
            var result =
                client.Cypher
                .Match("(d:Director)")
                .Where((Director d) => d.name == dir.name)
                .Return(d => d.As<Director>())
                .Results;
            foreach (Director d in result)
            {
                dirList.Add(d);
            }


        }

        public static void movieInfo(GraphClient client, Movie mov, List<Movie> movList)
        {
            var result =
                client.Cypher
                .Match("(m:Movie)")
                .Where((Movie m) => m.title == mov.title)
                .Return(m => m.As<Movie>())
                .Results;
            foreach (Movie m in result)
            {
                movList.Add(m);
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



            /* Welke acteurs hebben meer dan 2 keer met elkaar gespeeld?

        MATCH (a:Actor)-[:ACTS_IN]-(x)-[:ACTS_IN]-(ac:Actor)
        WHERE a.name = "Keanu Reeves" AND NOT ac.name = "Keanu Reeves "
        RETURN a, ac, COUNT(x) > 2
        ORDER BY COUNT(x) DESC
        LIMIT 3; */

        public static void actorsWhoPlayedMoreThanTwoFilms(GraphClient client, Actor ac, List<Actor> listActor1, List<Actor> listActor2)
        {
            var result = client.Cypher
                .Match("(a:Actor) -[:ACTS_IN]-(x)-[:ACTS_IN]-(act:Actor)")
                .Where((Actor a) => a.name == ac.name)
                .AndWhere((Actor act) => act.name != ac.name)
                .Return((a, act, x) => new
                {
                    listActor1 = a.As<Actor>(),
                    listActor2 = act.As<Actor>(),
                    numberOfMovies = x.Count()
                })
                .OrderBy("numberOfMovies DESC")
                .Limit(3)
                .Results;

            foreach(var a in result)
            {
                listActor1.Add(a.listActor1);
                listActor2.Add(a.listActor2);
            }
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

