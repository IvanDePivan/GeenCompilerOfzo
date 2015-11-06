using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Compilers;
using GeenCompiler.Compiler.Nodes;

namespace GeenCompiler.Compiler {
    public class TheCompiler {
        public static NodeLinkedList Compiled;
        public static NodeLinkedList compile(LinkedListNode<Token> firstToken) {
            CompiledStatement cs = CompilerFactory.Instance.CreateCompiledStatement(firstToken);
            Compiled = cs.compile(ref firstToken);
            while (firstToken != null)
            {
                cs = CompilerFactory.Instance.CreateCompiledStatement(firstToken);
                NodeLinkedList nll = cs.compile(ref firstToken);
                Compiled.Add(nll);
            }
            ActionNode a = Compiled.First;
            while (a != null)
            {
                Console.WriteLine(a.GetType());
                a = a.Next;
            }
            return Compiled;
        }
    }
}
