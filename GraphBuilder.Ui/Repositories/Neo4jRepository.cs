using Neo4j.Driver.V1;
using System.Collections.Generic;

namespace GraphBuilder.Ui.Repositories
{
    public abstract class Neo4jRepository
    {
        private readonly string Server = "bolt://localhost:32768";
        private readonly IAuthToken AuthToken = AuthTokens.Basic("neo4j", "password");

        protected IStatementResult Execute(string statement)
        {
            using (var driver = GraphDatabase.Driver(Server, AuthToken))
            using (var session = driver.Session())
            {
                return session.Run(statement);
            }
        }

        protected IStatementResult Execute(string statement, Dictionary<string, object> parameters)
        {
            using (var driver = GraphDatabase.Driver(Server, AuthToken))
            using (var session = driver.Session())
            {
                return session.Run(statement, parameters);
            }
        }

        protected void GetAll(string label)
        {
            Execute(string.Format("MATCH (n:{0}) RETURN n", label));
        }

        protected void DeleteAll(string label)
        {
            Execute(string.Format("MATCH (n:{0}) DETACH DELETE n", label));
        }

        protected void AddIdsToParameters(Dictionary<string, object> parameters, Dictionary<string, string> nodes)
        {
            foreach (KeyValuePair<string, string> node in nodes)
            {
                parameters.Add(string.Format("{0}Id", node.Key), node.Value);
            }
        }
    }
}