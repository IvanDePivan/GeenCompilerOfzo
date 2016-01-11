using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizeIfToken : RecognizeTokenStrategy{
        public Token match(string name, Token lastToken) {
            if(name.StartsWith("als")) { //Meets starting condition
                Token token = null;
                if(name[3] == ' ' || name[3] == '(') { //als is followed by a space or a (
                    token = new Token();
                    token.type = TokenType.If;
                    token.value = "als";
                }
                
                return token;
            } else {
                return null;
            }
        }
    }
}
