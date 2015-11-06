using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;

namespace GeenCompiler.Compiler.Compilers {
    public class CompiledCondition : CompiledStatement {

        public override NodeLinkedList compile(ref LinkedListNode<Token> currentToken) {

            Token leftToken = currentToken.Value;
            string leftName = leftToken.value;
            currentToken = currentToken.Next;
            Token operatorToken = currentToken.Value;
            currentToken = currentToken.Next;
            Token rightToken = currentToken.Value;
            string rightName = rightToken.value;

            if(leftToken.type != VariableType.Variable || leftToken.type != VariableType.Number) {
                leftName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", leftToken.value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", leftName));
            }
            if(rightToken.type != VariableType.Variable || rightToken.type != VariableType.Number) {
                rightName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", leftToken.value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", leftName));
            }

            switch(operatorToken.type) {
                case VariableType.Equals: 
                    Compiled.Add(new FunctionCallNode("AreEqual", leftName, rightName));
                    break;
                case VariableType.SmallerThan: 
                    Compiled.Add(new FunctionCallNode("IsSmaller", leftName, rightName));
                    break;
                case VariableType.Largerthan: 
                    Compiled.Add(new FunctionCallNode("IsLarger", leftName, rightName));
                    break;
                case VariableType.SmallerOrEqualThan: 
                    Compiled.Add(new FunctionCallNode("IsSmallerOrEqual", leftName, rightName));
                    break;
                case VariableType.LargerOrEqualThan: 
                    Compiled.Add(new FunctionCallNode("IsLargerOrEqual", leftName, rightName));
                    break;
                default:
                    break;
            }
            return null;
        }

        public override bool isMatch(LinkedListNode<Token> currentToken) {
            return (currentToken.Next.Value.type == VariableType.LargerOrEqualThan || currentToken.Next.Value.type == VariableType.Largerthan ||
                 currentToken.Next.Value.type == VariableType.SmallerOrEqualThan || currentToken.Next.Value.type == VariableType.SmallerThan ||
                 currentToken.Next.Value.type == VariableType.Equals);
        }

        public override CompiledStatement clone() {
            return new CompiledCondition();
        }
    }    
}
