using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;

namespace GeenCompiler.Compiler {
    public abstract class CompiledStatement {
        public NodeLinkedList Compiled;
        public NodeLinkedList compile(ref LinkedListNode<Token> currentToken);
        ActionNode getLastNode();
        public CompiledStatement clone();
        public bool isMatch(LinkedListNode<Token> token);

        public static string getUniqueId() {
            return Guid.NewGuid().ToString();
        }
    }
}
