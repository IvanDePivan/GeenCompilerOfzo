using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizeNumberToken : RecognizeTokenStrategy {
        Regex numberRegex = new Regex(@"^\d"); //Starts with a number
        public Token match(string name, Token lastToken) {
            Token token = null;
            Match m = numberRegex.Match(name);
            if(m.Success) {
                token = new Token();
                token.type = TokenType.Number;
                token.value = m.Value;
            }
            return token;
        }
    }
}
