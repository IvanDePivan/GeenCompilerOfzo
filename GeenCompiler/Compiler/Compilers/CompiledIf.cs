using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;

namespace GeenCompiler.Compiler.Compilers {
    public class CompiledIf : CompiledStatement {
        private NodeLinkedList compiledStatement;
        private NodeLinkedList condition;
        private NodeLinkedList body;

        public CompiledIf() {
            
        }


        public override NodeLinkedList compile(ref LinkedListNode<Token> currentToken) {
            currentToken = currentToken.Next.Next;
            CompiledStatement cs = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
            NodeLinkedList nll = cs.compile(ref currentToken);
            Compiled.Add(nll);
            

            var conditionalJumpNode = new ConditionalJumpNode(compiledStatement.Last, body.First);
            Compiled.Add(conditionalJumpNode); // De body komt dus rechtstreeks na de conditionalJumpNode (dus op de .Next property)
            currentToken = currentToken.Next.Next;
            //var body =

            
//            Compiled.Add(body);

            return compiledStatement;
        }

        public override CompiledStatement clone() {
            return new CompiledIf();
        }

        public override bool isMatch(LinkedListNode<Token> currentToken) {
            return (currentToken.Value.type == TokenType.If);
        }
    }
}
