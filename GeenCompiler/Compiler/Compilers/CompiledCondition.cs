using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;

namespace GeenCompiler.Compiler.Compilers {
   /* public class CompiledCondition : CompiledStatement {
        public override CompiledStatement Clone() {
            return new CompiledCondition();
        }

        public override void Compile(ref LinkedListNode<Token> currentToken) {
            // x == 2
            // y >= 0
            // 2 == x
            // etc
            // even kort door de bocht.

            Token leftToken = currentToken.Value;
            string leftName = leftToken.value;
            currentToken = currentToken.Next;
            Token operatorToken = currentToken.Value;
            currentToken = currentToken.Next;
            Token rightToken = currentToken.Value;
            string rightName = rightToken.value;

            if(leftToken.type != VariableType.Variable) {
                leftName = CompiledStatement.getUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", leftToken.value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", leftName));
            }
            // ... hetzelfde voor rightname

            switch(operatorToken.type) {
                //case VariableType.DOUBLE_EQUALS: Compiled.Add(new FunctionCallNode("AreEqual", leftName, rightName));
                // etc.
                default:
                    break;
            }
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken) { 
            return false;
            //TODO: add double equals to the list of possible tokens/nodes etc
           // return currentToken.Next.Value.type == VariableType.DOUBLE_EQUALS ;
        }
    }    */
}
