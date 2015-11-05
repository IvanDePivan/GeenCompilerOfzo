using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Nodes {
    public class DirectFunctionCallNode : ActionNode{
        public static string CONSTANTTORETURN = "ConstantToReturn";
        public static string RETURNTOVARIABLE = "ReturnToVariable";
        private string name;
        private Variable value;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Variable Value
        {
            get
            {
                return value;
            }
        }
        public DirectFunctionCallNode(string name, Token value) {
            this.name = name;
            this.value = new Variable(value);
        }

        public DirectFunctionCallNode(string name, string value)
        {
            this.name = name;
            this.value = new Variable(value);
        }
        public override void accept(Virtual_Machine.NodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
