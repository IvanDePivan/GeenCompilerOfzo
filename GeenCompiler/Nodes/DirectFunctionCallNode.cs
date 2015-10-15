using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Nodes {
    class DirectFunctionCallNode : AbstractFunctionCallNode{
        private string name;
        private string value;
        public DirectFunctionCallNode(string name, string value) {
            this.name = name;
            this.value = value;
        }
    }
}
