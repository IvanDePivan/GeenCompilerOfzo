using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Nodes {
    class FunctionCallNode : AbstractFunctionCallNode{
        private string name;
        private string left;
        private string right;
        public FunctionCallNode(string name, string left, string right) {
            this.name = name;
            this.left = left;
            this.right = right;
        }
    }
}
