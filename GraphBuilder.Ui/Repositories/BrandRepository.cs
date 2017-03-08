using GraphBuilder.Entities;
using System.Collections.Generic;

namespace GraphBuilder.Repositories
{
    public class BrandRepository : Neo4jRepository
    {
        public Brand Create(Brand brand)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", brand.Id.ToString());
            parameters.Add("name", brand.Name);
            var result = Execute("CREATE (b:" + Brand.Label + " {id: {id}, name: {name}})", parameters);
            return brand;
        }

        internal void DeleteAll()
        {
            DeleteAll(Brand.Label);
        }
    }
}