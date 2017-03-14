using GraphBuilder.Ui.Entities;
using System.Collections.Generic;

namespace GraphBuilder.Ui.Repositories
{
    public class StoreRepository : Neo4jRepository
    {
        public Store Create(Store appStore)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", appStore.Id.ToString());
            parameters.Add("name", appStore.Name);
			parameters.Add("brandId", appStore.Brand.Id.ToString());

			var result = Execute("MATCH (b:Brand {id:{brandId}}) CREATE (as:" + Store.Label + " {id: {id}, name: {name}}), (as)-[:made_by]->(b)", parameters);
            return appStore;
        }

        public void DeleteAll()
        {
            DeleteAll(Store.Label);
        }
    }
}