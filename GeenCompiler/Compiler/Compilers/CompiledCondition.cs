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

            //Hier ben ik gebleven:
            //Condition moet net als alles checken of de conditie uit meerdere stukken bestaat
            //check dus of je links apart moet compilen en rechts ook.
            //Misschien moet ook afgevangen worden als je per ongelijk iets probeerd te compilen dat alleen een variabele is.

            //Statment length geeft een idee over complexiteit, maar niet over waar iets is.
            //example:
            // 1 < 3 + 5
            // 3 + 3 > 2

            //Controleer dus de positie van het compare teken?
            int statementlength = getStatementLength(currentToken.Value);

            if(statementlength > 3) {
                //statement is composed of multiple parts.
            }

            leftName = compileOneSide(leftToken);
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

        private string compileOneSide(Token token){
            string name = CompiledStatement.getUniqueId();
            Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", token.value));
            Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", name));
            return name;
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

        private int getStatementLength(Token token) {
            int length = 0;
            while(token.type != TokenType.ParenthesisClose && token.type != TokenType.Endstatement) {
                length++;
            }
            return length;
        }

        public override CompiledStatement clone() {
            return new CompiledCondition();
        }
    }    
}
