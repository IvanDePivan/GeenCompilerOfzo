using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Nodes {
    abstract class ActionNode {
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

        void accept(NodeVisitor visitor);
        
    }
}
