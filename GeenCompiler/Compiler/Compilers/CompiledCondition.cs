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

            if(leftToken.type == TokenType.Number) {
                leftName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", leftToken.value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", leftName));
            }

            if(rightToken.type == TokenType.Number) {
                rightName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", leftToken.value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", rightName));
            }

            switch(operatorToken.type) {
                case TokenType.Equals: 
                    Compiled.Add(new FunctionCallNode("AreEqual", leftName, rightName));
                    break;
                case TokenType.SmallerThan: 
                    Compiled.Add(new FunctionCallNode("IsSmaller", leftName, rightName));
                    break;
                case TokenType.Largerthan: 
                    Compiled.Add(new FunctionCallNode("IsLarger", leftName, rightName));
                    break;
                case TokenType.SmallerOrEqualThan: 
                    Compiled.Add(new FunctionCallNode("IsSmallerOrEqual", leftName, rightName));
                    break;
                case TokenType.LargerOrEqualThan: 
                    Compiled.Add(new FunctionCallNode("IsLargerOrEqual", leftName, rightName));
                    break;
                default:
                    break;
            }
            currentToken = currentToken.Next;
            return Compiled;
        }

        public override bool isMatch(LinkedListNode<Token> currentToken) {
            if(currentToken.Next != null) {
                return (currentToken.Next.Value.type == TokenType.LargerOrEqualThan || currentToken.Next.Value.type == TokenType.Largerthan ||
                     currentToken.Next.Value.type == TokenType.SmallerOrEqualThan || currentToken.Next.Value.type == TokenType.SmallerThan ||
                     currentToken.Next.Value.type == TokenType.Equals);
            } else {
                return false;
            }

        }

        public override CompiledStatement clone() {
            return new CompiledCondition();
        }
    }    
}
