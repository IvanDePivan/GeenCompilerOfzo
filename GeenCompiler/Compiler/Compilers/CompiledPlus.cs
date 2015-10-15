using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;

namespace GeenCompiler.Compiler.Compilers {
    class CompiledPlus : CompiledStatement {

        public NodeLinkedList compile(ref LinkedListNode<Token> currentToken) {
            Token leftToken = currentToken.Value;
            string leftName = leftToken.value;
            Token rightToken = currentToken.Next.Next.Value;
            string rightName = rightToken.value;
            //Compile left of +
            //var leftCompiled = CompilerFactory.Instance.CreateCompiledStatement(currentToken);

            //Temp variable for left
            if(leftToken.type == VariableType.Number) {
                leftName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", leftToken.value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", leftName));
            } 

            //Temp variable for right
            if(rightToken.type == VariableType.Number) {
                rightName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", rightToken.value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", rightName));
            } 
            currentToken = currentToken.Next;

            if(currentToken.Value.type == VariableType.Add){
                Compiled.Add(new FunctionCallNode("Add", leftName, rightName));
            }

            currentToken = currentToken.Next.Next;
            return Compiled;
        }

        public override CompiledStatement Clone() {
            return new CompiledPlus();
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken) {
            // matched if current is a variable or number, next is a plus en third is also a number or variable.
            return (currentToken.Value.type == VariableType.Variable || currentToken.Value.type == VariableType.Number)
                && currentToken.Next.Value.type == VariableType.Equals
                && (currentToken.Next.Next.Value.type == VariableType.Variable || currentToken.Next.Next.Value.type == VariableType.Number);
        }
    }
}
