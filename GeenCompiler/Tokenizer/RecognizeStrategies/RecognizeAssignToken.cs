using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizeAssignToken : RecognizeTokenStrategy {


        public Token match(string name, Token lastToken) {
            Token token = null;
            // There is no need for checking !=, +=, >= etc 
            if(name[0] == '=' && name[1] != '=') { //assigment is an = except for ==
                token = new Token();
                token.type = VariableType.Assign;
                token.value = name.Substring(0, 1);
            }
            return token;
        }
    }
}
