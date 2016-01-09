using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Compilers
{
    class CompiledAssignment : CompiledStatement
    {
        public override NodeLinkedList compile(ref LinkedListNode<Token> currentToken)
        {
            Token leftToken = currentToken.Value;
            string leftName = leftToken.value;
            Token rightToken = currentToken.Next.Next.Value;
            string rightName = rightToken.value;
            //Compile left of +
            //var leftCompiled = CompilerFactory.Instance.CreateCompiledStatement(currentToken);

            //simple assignment
            if(currentToken.Next.Next.Next.Value.type == TokenType.Endstatement)
            {
                //Temp variable for right
                if(rightToken.type == TokenType.Number)
                {
                    Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.CONSTANTTORETURN, rightToken));
                } else if(rightToken.type == TokenType.Variable)
                {
                    Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.VARIABLETORETURN, rightName));
                }
                currentToken = currentToken.Next.Next.Next.Next;
            }
            else
            {
                currentToken = currentToken.Next.Next;
                CompiledStatement cs = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
                NodeLinkedList nll = cs.compile(ref currentToken);
                Compiled.Add(nll);
                currentToken = currentToken.Next;
            }
            Compiled.Add(new DirectFunctionCallNode(DirectFunctionCallNode.RETURNTOVARIABLE, leftName));
            return Compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledAssignment();
        }

        public override bool isMatch(LinkedListNode<Token> currentToken)
        {
            if(currentToken.Next != null) {
                return (currentToken.Value.type == TokenType.Variable)
                    && currentToken.Next.Value.type == TokenType.Assign
                    && (currentToken.Next.Next.Value.type == TokenType.Variable || currentToken.Next.Next.Value.type == TokenType.Number);
            } else {
                return false;
            }
        }
    }
}
