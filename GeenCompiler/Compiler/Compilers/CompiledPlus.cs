using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;

namespace GeenCompiler.Compiler.Compilers {
    class CompiledPlus : CompiledStatement {

        public override NodeLinkedList compile(ref LinkedListNode<Token> currentToken) {
            Token leftToken = currentToken.Value;
            string leftName = leftToken.value;
            Token rightToken = currentToken.Next.Next.Value;
            string rightName = rightToken.value;
            //Compile left of +
            //var leftCompiled = CompilerFactory.Instance.CreateCompiledStatement(currentToken);

            //Temp variable for left
            if(leftToken.type == TokenType.Number) {
                leftName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.CONSTANTTORETURN, leftToken));
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.RETURNTOVARIABLE, leftName));
            } 

            //Temp variable for right
            if(rightToken.type == TokenType.Number) {
                rightName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.CONSTANTTORETURN, rightToken));
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.RETURNTOVARIABLE, rightName));
            } 
            currentToken = currentToken.Next;

            if(currentToken.Value.type == TokenType.Add){
                Compiled.Add(new FunctionCallNode("Add", leftName, rightName));
            }

            currentToken = currentToken.Next.Next;
            return Compiled;
        }

        public override CompiledStatement clone() {
            return new CompiledPlus();
        }

        public override bool isMatch(LinkedListNode<Token> currentToken) {
            // matched if current is a variable or number, next is a plus en third is also a number or variable.
            if(currentToken.Next != null) {
                return (currentToken.Value.type == TokenType.Variable || currentToken.Value.type == TokenType.Number)
                    && currentToken.Next.Value.type == TokenType.Add
                    && (currentToken.Next.Next.Value.type == TokenType.Variable || currentToken.Next.Next.Value.type == TokenType.Number);
            } else {
                return false;
            }
        }
    }
}
