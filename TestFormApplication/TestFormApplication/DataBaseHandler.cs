using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormApplication
{
    class DataBaseHandler
    {
        private GraphClient client;

        private void initClientConnection()
        {
            if(this.client != null)
            {
                return;
            }

            this.client = new GraphClient(new Uri("http://localhost:7474/db/data"));
            this.client.Connect();
        }

        /*
        public DateTime longToDate(long releaseDate)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(releaseDate).ToLocalTime();
            return date;
        }*/

        // CRUD operations for NEO4J
        // This is a generic function that creates all the node necessary for this assignment
        public void createNode(Object newNode, String typeOfNode)
        {
            var nodeType = " ";
            initClientConnection();

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
            this.client.Cypher
                .Create("(" + nodeType + "{newNode})")
                .WithParam("newNode", newNode)
                .ExecuteWithoutResults();
        }

        //these functions reads data from neo4j
        public void actorInfo(Actor act, List<Actor> actList)
        {
            initClientConnection();
            var result =
                this.client.Cypher
                .Match("(a:Actor)")
                .Where((Actor a) => a.name == act.name)
                .Return(a => a.As<Actor>())
                .Results;
            foreach (Actor a in result)
            {
                actList.Add(a);
            }


        }

        public void directorInfo(Director dir, List<Director> dirList)
        {
            initClientConnection();
            var result =
                this.client.Cypher
                .Match("(d:Director)")
                .Where((Director d) => d.name == dir.name)
                .Return(d => d.As<Director>())
                .Results;
            foreach (Director d in result)
            {
                dirList.Add(d);
            }


        }

        public void movieInfo(Movie mov, List<Movie> movList)
        {
            initClientConnection();
            var result =
                this.client.Cypher
                .Match("(m:Movie)")
                .Where((Movie m) => m.title == mov.title)
                .Return(m => m.As<Movie>())
                .Results;
            foreach (Movie m in result)
            {
                movList.Add(m);
            }
        }

        //The following methods updates the nodes in neo4j
        public void updateActor(Actor acteur)
        {
            initClientConnection();
            this.client.Cypher
                .Match("(a:Actor)")
                .Where((Actor a) => a.name == acteur.name)
                .Set("a = {updateActeur}")
                .WithParam("updateActeur", acteur)
                .ExecuteWithoutResults();
        }

        public void updateDirector(Director dir)
        {
            initClientConnection();
            this.client.Cypher
                .Match("(d:Director)")
                .Where((Director d) => d.name == dir.name)
                .Set("d = {updateDir}")
                .WithParam("updateDir", dir)
                .ExecuteWithoutResults();
        }

        public void updateMovie(Movie mov)
        {
            initClientConnection();
            this.client.Cypher
                .Match("(m:Movie)")
                .Where((Movie m) => m.title == mov.title)
                .Set("m = {updateMov}")
                .WithParam("updateMov", mov)
                .ExecuteWithoutResults();
        }

        // The following methods deletes the nodes in neo4j
        public void removeActor(Actor acteur)
        {
            initClientConnection();
            this.client.Cypher
            .Match("(a:Actor)")
            .Where((Actor a) => a.name == acteur.name)
            .Delete("a")
            .ExecuteWithoutResults();
        }

        public void removeDirector(Director dir)
        {
            initClientConnection();
            this.client.Cypher
            .Match("(d:Director)")
            .Where((Director d) => d.name == dir.name)
            .Delete("d")
            .ExecuteWithoutResults();
        }

        public void removeMovie(Movie mov)
        {
            initClientConnection();
            this.client.Cypher
            .Match("(m:Movie)")
            .Where((Movie m) => m.title == mov.title)
            .Delete("m")
            .ExecuteWithoutResults();
        }

        //these are the four main queries for the assignment
        public void actorsWhoPlayedMoreThanTwoFilms(Actor ac, List<Actor> listActor1, List<Actor> listActor2)
        {
            initClientConnection();
            var result = this.client.Cypher
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

        public void actorWhoDirectedOwnMovie(List<Actor> listActor,List<long> listCount)
        {
            initClientConnection();
            var result = this.client.Cypher
                .Match("(a:Actor)-[:ACTS_IN]-(m)-[r:DIRECTED]-(d:Director)")
                .Where((Actor a, Director d) => a.name == d.name)
                .Return((a, r) => new { listActor = a.As<Actor>(), numberOfMovies = r.Count()})
                .OrderBy("numberOfMovies DESC")
                .Limit(15)
                .Results;

            foreach (var a in result)
            {
                listActor.Add(a.listActor);
            }

            foreach (var a in result)
            {
                listCount.Add(a.numberOfMovies);
            }
        }

        public void mostRecentMovies(List<Movie> listMovie)
        {
            initClientConnection();
            var result = this.client.Cypher
                .Match("(m:Movie)")
                .Return((m) => new
                {
                    listMovie = m.As<Movie>(),
                })
                .OrderBy("m.ReleaseDate DESC")
                .Limit(10)
                .Results;

            foreach (var a in result)
            {
                listMovie.Add(a.listMovie);
            }

        }

        public void mostRecentMoviesByGenre(Movie movie, List<Movie> listMovie)
        {
            initClientConnection();
            var result = this.client.Cypher
                .Match("(m:Movie)")
                .Where((Movie m) => m.genre == movie.genre)
                .Return((m) => new
                {
                    listMovie = m.As<Movie>(),
                })
                .OrderBy("m.ReleaseDate DESC")
                .Limit(10)
                .Results;

            foreach (var a in result)
            {
                listMovie.Add(a.listMovie);
            }

        }

    }

}
