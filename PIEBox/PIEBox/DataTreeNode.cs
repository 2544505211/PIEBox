using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIEBox
{
    public class DataTreeNode
    {
        private string id;
        private string parentId;
        private string nodeText;


        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        public string NodeText
        {
            get { return nodeText; }
            set { nodeText = value; }
        }
    }
}
