using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;

namespace GeenCompiler.Compiler {
    class NodeLinkedList {
        private ActionNode first;
        public ActionNode First {
            get { return first; }
            private set { first = value; }
        }
        private ActionNode last;
        public ActionNode Last {
            get { return last; }
            private set { last = value; }
        }
        public void Add(ActionNode node) {
            last.Next = node;
            node.Prev = last;
            last = node;
        }

        public void Add(NodeLinkedList nll) {
            last.Next = nll.first;
            nll.first.Prev = last;
            last = nll.last;
        }
    }
}
