using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizeWhileToken : RecognizeTokenStrategy {
        public Token match(string name, Token lastToken) {
            if(name.StartsWith("terwijl")) { //Meets starting condition
                Token token = null;
                if(name[7] == ' ' || name[7] == '(') { //als is followed by a space or a (
                    token = new Token();
                    token.type = TokenType.While;
                    token.value = "terwijl";
                }
                
                return token;
            } else {
                return null;
            }
        }
    }
}
