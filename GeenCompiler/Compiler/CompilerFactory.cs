﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler.Compilers {
    public class CompilerFactory {
        private List<CompiledStatement> _compilers;
        private static CompilerFactory instance;
        public static CompilerFactory Instance {
            get {
                if(instance == null) {
                    instance = new CompilerFactory(); 
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private CompilerFactory() {
            _compilers = new List<CompiledStatement>();
            _compilers.Add(new CompiledPlus());
            _compilers.Add(new CompiledPlusPlus());
            _compilers.Add(new CompiledMin());
            _compilers.Add(new CompiledDivide());
            _compilers.Add(new CompiledMultiply());
            _compilers.Add(new CompiledAssignment());
            _compilers.Add(new CompiledIf());
            _compilers.Add(new CompiledWhile());
            _compilers.Add(new CompiledPrint());
            _compilers.Add(new CompiledCondition());

        }

        public CompiledStatement CreateCompiledStatement(LinkedListNode<Token> currentToken) {
            foreach(var compiledStatement in _compilers) {
                if(compiledStatement.isMatch(currentToken)) {
                        return compiledStatement.clone();
                }
            }

            throw new Exception("Could not identify token: " + currentToken.Value.value);
        }
    }
}
