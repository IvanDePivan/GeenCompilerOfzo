using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;

namespace GeenCompiler.Compiler.Compilers {
    class CompiledPlusPlus : CompiledStatement {

        public override NodeLinkedList compile(ref LinkedListNode<Token> currentToken) {
            Token leftToken = currentToken.Value;
            string leftName = leftToken.value;
            string rightName = getUniqueId();
            string templeftName = leftName;
            //Temp variable for left
            if(leftToken.type == TokenType.Number) {
                templeftName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.CONSTANTTORETURN, leftToken));
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.RETURNTOVARIABLE, templeftName));
            }

            Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.CONSTANTTORETURN, "1"));
            Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.RETURNTOVARIABLE, rightName));

            currentToken = currentToken.Next;

            if(currentToken.Value.type == TokenType.Add || currentToken.Value.type == TokenType.AddOne){
                Compiled.Add(new FunctionCallNode("Add", leftName, rightName));
            }
            Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.RETURNTOVARIABLE, leftName));
            currentToken = currentToken.Next.Next;
            return Compiled;
        }

        public override CompiledStatement clone() {
            return new CompiledPlusPlus();
        }

        public override bool isMatch(LinkedListNode<Token> currentToken) {
            // matched if current is a variable or number, next is a plus en third is also a number or variable.
            if(currentToken.Next != null) {
                return (currentToken.Value.type == TokenType.Variable || currentToken.Value.type == TokenType.Number)
                    && currentToken.Next.Value.type == TokenType.AddOne;
            } else {
                return false;
            }
        }
    }
}
