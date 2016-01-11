using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizeBooleanToken : RecognizeTokenStrategy{
        public Token match(string name, Token lastToken) {
            if(name.StartsWith("True", StringComparison.OrdinalIgnoreCase) ||
               name.StartsWith("False", StringComparison.OrdinalIgnoreCase)) { //meets condition
                Token token = new Token();
                token.type = TokenType.Boolean;

                if(name.StartsWith("True", StringComparison.OrdinalIgnoreCase)){
                    token.value = name.ToLower().Substring(0, 4);
                } else{
                    token.value = name.ToLower().Substring(0, 5);
                }
                return token;
            } else {
                return null;
            }
        }
    }
}
