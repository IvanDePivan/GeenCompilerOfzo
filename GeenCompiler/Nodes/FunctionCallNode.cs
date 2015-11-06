using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Nodes {
    public class FunctionCallNode : ActionNode{
        private string name;
        private string left;
        private string right;
        public string Name{
            get
            {
                return name;
            }
        }
        public string Left
        {
            get
            {
                return left;
            }
        }
        public string Right
        {
            get
            {
                return right;
            }
        }
        public FunctionCallNode(string name, string left, string right) {
            this.name = name;
            this.left = left;
            this.right = right;
        }
        public FunctionCallNode(string name, string left)
        {
            this.name = name;
            this.left = left;
        }

        public FunctionCallNode(string name)
        {
            this.name = name;
        }
        public override void accept(Virtual_Machine.NodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
