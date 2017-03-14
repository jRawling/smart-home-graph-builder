using GraphBuilder.Ui.Entities;
using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphBuilder.Ui.Repositories
{
    public class AppRepository : Neo4jRepository
    {
        public App Create(App app)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", app.Id.ToString());
            parameters.Add("brandId", app.Brand.Id.ToString());
            parameters.Add("name", app.Name);
            Dictionary<string, string> appStoreNodes = GetAppStoreNodes(app.AvailableOn);
            AddIdsToParameters(parameters, appStoreNodes);

            string clause = "MATCH ";

            foreach (string key in appStoreNodes.Keys)
            {
                clause += string.Format("({0}:{1} {{id: {{{0}Id}}}}), ", key, Store.Label);
            }

            clause += "(b:Brand {id: {brandId}})";
            clause += string.Format(" \nCREATE (app:{0} {{id: {{id}}, name: {{name}}}}), (app)-[:made_by]->(b)", App.Label);

            foreach (string key in appStoreNodes.Keys)
            {
                clause += string.Format(", (app)-[:available_on]->({0})", key);
            }

            var result = Execute(clause, parameters);
            return app;
        }

        public void DeleteAll()
        {
            DeleteAll(App.Label);
        }

        private Dictionary<string, string> GetAppStoreNodes(IEnumerable<Store> stores)
        {
            Dictionary<string, string> nodes = new Dictionary<string, string>();
            int index = 0;
            foreach (Store store in stores)
            {
                nodes.Add(string.Format("appStore{0}", index), store.Id.ToString());
                index++;
            }

            return nodes;
        }
    }
}