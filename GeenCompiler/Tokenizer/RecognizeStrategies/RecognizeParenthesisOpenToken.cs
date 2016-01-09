using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizeParenthesisOpenToken : RecognizeTokenStrategy
    {

        public Token match(string name, Token lastToken) {
            Token token = null;
            if(name[0] == '('){
                token = new Token();
                token.type = TokenType.ParenthesisOpen;
                token.value = "(";
            }
            return token;
        }
    }
}
