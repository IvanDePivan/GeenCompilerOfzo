using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Virtual_Machine;

namespace GeenCompiler.Compiler.Nodes {
    public class JumpNode : ActionNode{
        private ActionNode jumpNode;

        public ActionNode jump {
            get { return jumpNode; }
        }

        public JumpNode(ActionNode partner) {
            if(partner != null) {
                this.jumpNode = partner;
            } else {
                throw new Exception("JumpNode needs something to jump to.");
            }
        }
        public override void accept(NodeVisitor visitor) {
            visitor.visit(this);
        }
    }
}
