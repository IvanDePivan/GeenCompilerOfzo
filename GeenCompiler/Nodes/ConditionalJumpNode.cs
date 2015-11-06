using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Nodes {
    
    public class ConditionalJumpNode : ActionNode{
        private ActionNode nextOnTrue;
        private ActionNode nextOnFalse;

        public ActionNode NextOnTrue {
            get { return nextOnTrue; }
        }
        public ActionNode NextOnFalse {
            get { return nextOnFalse; }
        }

        public ConditionalJumpNode(ActionNode trueNode, ActionNode falseNode) {
            nextOnFalse = falseNode;
            nextOnTrue = trueNode;
        }

        public override void accept(Virtual_Machine.NodeVisitor visitor) {
            throw new NotImplementedException();
        }
    }
}
