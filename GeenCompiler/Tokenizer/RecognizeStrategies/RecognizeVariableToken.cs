using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class RecognizeVariableToken : RecognizeTokenStrategy{
        private Regex alphanumeric = new Regex(@"^[a-zA-Z]+");
        public Token match(string name, Token lastToken) {
            //This needs to check if a string of only alphanumeric characters can be found.
            //Variables are checked last because they can be a catchall. e.g. als shouldn't match here before it matched 
            //if
            Token token = null;
            Match m = alphanumeric.Match(name);
            if(m.Success) { //Only matches the first set of characters up to something that isn't alphanumeric
                token = new Token();
                token.type = TokenType.Variable;
                token.value = m.Value;
            }
            return token;
        }
    }
}
