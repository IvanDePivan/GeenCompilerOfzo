using GeenCompiler.Virtual_Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Nodes {
    public abstract class ActionNode {
        private ActionNode prev;
        public ActionNode Prev {
            get { return prev; }
            set { prev = value; }
        }
        private ActionNode next;
        public ActionNode Next {
            get { return next; }
            set { next = value; }
        }

        public abstract void accept(NodeVisitor visitor);
        
    }
}
