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

        public CompiledIf() {
            
        }


        public override NodeLinkedList compile(ref LinkedListNode<Token> currentToken) {
            currentToken = currentToken.Next.Next;
            CompiledStatement cs = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
            NodeLinkedList nll = cs.compile(ref currentToken);
            Compiled.Add(nll);
            currentToken = currentToken.Next;
            int currentLvl = currentToken.Value.level;
            currentToken = currentToken.Next;
            CompiledStatement csbody = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
            NodeLinkedList body = csbody.compile(ref currentToken);
            while(currentToken.Value.level > currentLvl) {
                csbody = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
                body.Add(csbody.compile(ref currentToken));
            }
            var conditionalJumpNode = new ConditionalJumpNode(body.First, body.Last);
            Compiled.Add(conditionalJumpNode);
            Compiled.Add(body);
             // De body komt dus rechtstreeks na de conditionalJumpNode (dus op de .Next property)
            currentToken = currentToken.Next;

            return Compiled;
        }

        public override CompiledStatement clone() {
            return new CompiledIf();
        }

        public override bool isMatch(LinkedListNode<Token> currentToken) {
            return (currentToken.Value.type == TokenType.If);
        }
    }
}
