using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;

namespace GeenCompiler.Compiler {
    public abstract class CompiledStatement {
        public NodeLinkedList Compiled;
        public CompiledStatement()
        {
            Compiled = new NodeLinkedList();
        }
        public abstract NodeLinkedList compile(ref LinkedListNode<Token> currentToken);
        public ActionNode getLastNode()
        {
            return Compiled.Last;
        }
        public abstract CompiledStatement clone();
        public abstract bool isMatch(LinkedListNode<Token> token);

        public static string getUniqueId() {
            return Guid.NewGuid().ToString();
        }
    }
}
