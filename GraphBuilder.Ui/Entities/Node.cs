using System;
using System.Collections.Generic;
using System.Text;

namespace GraphBuilder.Ui.Entities
{
    public abstract class Node
    {
        public Guid Id { get; private set; }

        public Node()
        {
            Id = Guid.NewGuid();
        }
    }
}
