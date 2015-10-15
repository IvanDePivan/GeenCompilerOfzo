using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;

namespace GeenCompiler.Compiler {
    public class NodeLinkedList {
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
        public NodeLinkedList()
        {
            last = new DoNothingNode();
            first = new DoNothingNode();
            first.Next = last;
            last.Prev = first;
        }
        public void Add(ActionNode node) {
            ActionNode foreLast = last.Prev;
            last.Prev = node;
            node.Next = last;
            foreLast.Next = node;
            node.Prev = foreLast;
        }

        public void Add(NodeLinkedList nll) {
            last.Next = nll.first;
            nll.first.Prev = last;
            last = nll.last;
        }
    }
}
