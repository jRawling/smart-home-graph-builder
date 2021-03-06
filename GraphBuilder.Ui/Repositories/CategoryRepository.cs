﻿using GraphBuilder.Ui.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphBuilder.Ui.Repositories
{
    public class CategoryRepository : Neo4jRepository
    {
        public Category CreateCategory(string cateogryName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            // parameters.Add("id", categ.Id.ToString());
            parameters.Add("name", cateogryName);
            var result = Execute("CREATE (c:" + Category.Label + " {id: {id}, name: {name}})", parameters);
            return new Category(cateogryName);
        }

        public void DeleteAll()
        {
            DeleteAll(Category.Label);
        }
    }
}