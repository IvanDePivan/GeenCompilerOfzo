using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class CompilerException : Exception{
        private Stack<string> errors;
        public Stack<string> Errors {
            get {
                return errors;
            }
            set {
                errors = value;
            }
        }
        public CompilerException(Stack<string> errors) {
            this.errors = errors;
        }
    }
}
