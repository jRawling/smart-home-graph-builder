using GraphBuilder.Ui.Entities;
using System.Collections.Generic;

namespace GraphBuilder.Ui.Repositories
{
    public class AppStoreRepository : Neo4jRepository
    {
        public AppStore Create(AppStore appStore)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", appStore.Id.ToString());
            parameters.Add("name", appStore.Name);
			parameters.Add("brandId", appStore.Brand.Id.ToString());

			var result = Execute("MATCH (b:Brand {id:{brandId}}) CREATE (as:" + AppStore.Label + " {id: {id}, name: {name}}), (as)-[:made_by]->(b)", parameters);
            return appStore;
        }

        public void DeleteAll()
        {
            DeleteAll(AppStore.Label);
        }
    }
}