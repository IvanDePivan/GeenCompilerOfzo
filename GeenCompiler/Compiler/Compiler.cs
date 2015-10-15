using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler.Compilers;

namespace GeenCompiler.Compiler {
    class Compiler {
        public static NodeLinkedList Compiled;
        public static void compile(LinkedListNode<Token> firstToken) {
            CompiledStatement cs = CompilerFactory.Instance.CreateCompiledStatement(firstToken);
            Compiled = cs.compile(ref firstToken);
            
        }
    }
}
