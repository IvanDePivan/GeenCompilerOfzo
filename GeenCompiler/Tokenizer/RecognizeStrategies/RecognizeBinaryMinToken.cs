using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizeBinaryMinToken : RecognizeTokenStrategy{

        public Token match(string name, Token lastToken) {
            Token token = null;
            if(name[0] == '-'){
                if(lastToken != null && //lastToken could be NULL!
                (lastToken.type == VariableType.Variable || lastToken.type == VariableType.Number)) { //Binary operator condition
                    token = new Token();
                    token.type = VariableType.Subtract;
                    token.value = "-";
                }
            }
            return token;
        }
    }
}
