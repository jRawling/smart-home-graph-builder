using GraphBuilder.Entities;
using System.Collections.Generic;

namespace GraphBuilder.Repositories
{
    public class AppStoreRepository : Neo4jRepository
    {
        public AppStore Create(AppStore appStore)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", appStore.Id.ToString());
            parameters.Add("name", appStore.Name);
            var result = Execute("CREATE (as:" + AppStore.Label + " {id: {id}, name: {name}})", parameters);
            return appStore;
        }

        public void DeleteAll()
        {
            DeleteAll(AppStore.Label);
        }
    }
}