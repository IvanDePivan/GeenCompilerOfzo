using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;

namespace GeenCompiler.Compiler.Compilers {
    class CompiledMultiply : CompiledStatement {

        public override NodeLinkedList compile(ref LinkedListNode<Token> currentToken) {
            Token leftToken = currentToken.Value;
            string leftName = leftToken.value;
            Token rightToken = currentToken.Next.Next.Value;
            string rightName = rightToken.value;
            //Compile left of +
            //var leftCompiled = CompilerFactory.Instance.CreateCompiledStatement(currentToken);

            //Temp variable for left
            if(leftToken.type == VariableType.Number) {
                leftName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.CONSTANTTORETURN, leftToken));
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.RETURNTOVARIABLE, leftName));
            } 

            //Temp variable for right
            if(rightToken.type == VariableType.Number) {
                rightName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.CONSTANTTORETURN, rightToken));
                Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.RETURNTOVARIABLE, rightName));
            } 
            currentToken = currentToken.Next;

            if(currentToken.Value.type == VariableType.Multiply){
                Compiled.Add(new FunctionCallNode("Multiply", leftName, rightName));
            }

            currentToken = currentToken.Next.Next;
            return Compiled;
        }

        public override CompiledStatement clone() {
            return new CompiledMultiply();
        }

        public override bool isMatch(LinkedListNode<Token> currentToken) {
            // matched if current is a variable or number, next is a plus en third is also a number or variable.
            if(currentToken.Next != null) {
                return (currentToken.Value.type == VariableType.Variable || currentToken.Value.type == VariableType.Number)
                    && currentToken.Next.Value.type == VariableType.Multiply
                    && (currentToken.Next.Next.Value.type == VariableType.Variable || currentToken.Next.Next.Value.type == VariableType.Number);
            } else {
                return false;
            }
        }
    }
}
