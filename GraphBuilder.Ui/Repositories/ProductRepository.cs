using System.Linq;
using System.Collections.Generic;
using GraphBuilder.Ui.Entities;

namespace GraphBuilder.Ui.Repositories
{
    public class ProductRepository : Neo4jRepository
    {
        public Product Create(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", product.Id.ToString());
            parameters.Add("brandId", product.Brand.Id.ToString());
            parameters.Add("name", product.Name);
            parameters.Add("price", product.Price);

            string clause = "MATCH (b:Brand {id: {brandId}})";
            string relationships = ", (p)-[:made_by]->(b)";

            if(product is Bundle)
            {
                Bundle bundle = product as Bundle;
                Dictionary<string, string> productNodes = GetNodes("product", bundle.Products);
                AddIdsToParameters(parameters, productNodes);
                foreach (string key in productNodes.Keys)
                {
                    clause += string.Format(", ({0}:{1} {{id: {{{0}Id}}}})", key, Product.Label);
                    relationships += string.Format(", (p)-[:contains]->({0})", key);
                }
            }

            if (product is Standalone)
            {
                Standalone standalone = product as Standalone;

                if (standalone.ThirdyPartyApps != null)
                {
                    Dictionary<string, string> appNodes = GetNodes("app", standalone.ThirdyPartyApps);
                    AddIdsToParameters(parameters, appNodes);
                    foreach (string key in appNodes.Keys)
                    {
                        clause += string.Format(", ({0}:{1} {{id: {{{0}Id}}}})", key, App.Label);
                        relationships += string.Format(", (p)-[:third_party_app]->({0})", key);
                    }
                }

                parameters.Add("nativeAppId", standalone.NativeApp.Id.ToString());
                clause += string.Format(", (nativeApp:{0} {{id: {{nativeAppId}}}})", App.Label);
                relationships += (", (p)-[:native_app]->(nativeApp)");
            }

            if (product is Accessory)
            {
                Accessory accessory = product as Accessory;
                parameters.Add("hubId", accessory.Requires.Id.ToString());
                clause += ", (requiredP:Hub {id: {hubId}})";
                relationships += ", (p)-[:requires]->(requiredP)";
            }


            clause += string.Format(" \nCREATE (p:{0} {{id: {{id}}, name: {{name}}, price: {{price}}}})", GetLabel(product));
            clause += relationships;

            Execute(clause, parameters);
            return product;
        }

        private string GetLabel(Product product)
        {
            if (product is Accessory) { return Accessory.Label; }
            else if (product is Standalone) { return Standalone.Label; }
            else if (product is Bundle) { return Bundle.Label; }
            else { return Hub.Label; }
        }

        private Dictionary<string, string> GetNodes(string prefix, IEnumerable<Node> nodes)
        {
            Dictionary<string, string> nodesToReturn = new Dictionary<string, string>();
            int index = 0;
            foreach (Node node in nodes)
            {
                nodesToReturn.Add(string.Format("{0}{0}{1}", prefix, index), node.Id.ToString());
                index++;
            }

            return nodesToReturn;
        }

        public void DeleteAll()
        {
            DeleteAll(Product.Label);
        }
    }
}