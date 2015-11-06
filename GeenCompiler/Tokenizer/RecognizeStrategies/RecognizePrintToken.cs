using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizePrintToken : RecognizeTokenStrategy{

        public Token match(string name, Token lastToken) {
            Token token = null;
            if(name.Length >= 5 && name.Substring(0, 5) == "print"){
                token = new Token();
                token.type = VariableType.Print;
                token.value = "Print";
            }
            return token;
        }
    }
}
