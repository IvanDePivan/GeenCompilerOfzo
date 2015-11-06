using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;

namespace GeenCompiler.Compiler.Compilers {
    public class CompiledWhile {
        private NodeLinkedList compiledStatement;
        private NodeLinkedList condition;
        private NodeLinkedList body;

        public CompiledWhile() {
            compiledStatement = new NodeLinkedList();
            condition = new NodeLinkedList();
            body = new NodeLinkedList();

            var conditionalJumpNode = new ConditionalJumpNode(compiledStatement.Last, body.First);
            var jumpBackNode = new JumpNode(compiledStatement.First);

            compiledStatement.Add(condition);
            compiledStatement.Add(conditionalJumpNode); // De body komt dus rechtstreeks na de conditionalJumpNode (dus op de .Next property)
            compiledStatement.Add(body);
            compiledStatement.Add(jumpBackNode);
        }
    }
}
