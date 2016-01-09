using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;

namespace GeenCompiler.Compiler.Compilers {
    class CompiledPrint : CompiledStatement {

        public override NodeLinkedList compile(ref LinkedListNode<Token> currentToken) {
            Token valueToken = currentToken.Next.Next.Value;
            string valueName = valueToken.value;
            //Compile left of +
            //var leftCompiled = CompilerFactory.Instance.CreateCompiledStatement(currentToken);

            currentToken = currentToken.Next.Next;
            try
            {
                CompiledStatement cs = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
                NodeLinkedList nll = cs.compile(ref currentToken);
                Compiled.Add(nll);
            }
            catch 
            {
                if(valueToken.type == TokenType.Number) {
                    Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.CONSTANTTORETURN, valueToken));

                } else if(valueToken.type == TokenType.Variable)
                {
                    Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.VARIABLETORETURN, valueName));
                }
                currentToken = currentToken.Next;
            }

            Compiled.Add(new FunctionCallNode("Print"));

            currentToken = currentToken.Next.Next;
            return Compiled;
        }

        public override CompiledStatement clone() {
            return new CompiledPrint();
        }

        public override bool isMatch(LinkedListNode<Token> currentToken) {
            // matched if current is a variable or number, next is a plus en third is also a number or variable.
            return currentToken.Value.type == TokenType.Print
                && currentToken.Next.Value.type == TokenType.ParenthesisOpen;
        }
    }
}
