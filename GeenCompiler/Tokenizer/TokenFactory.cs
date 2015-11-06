using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class TokenFactory {
        private List<RecognizeTokenStrategy> tokenRecognizer;
        Token lastToken = null;
        public TokenFactory() {
            tokenRecognizer = new List<RecognizeTokenStrategy>();
            tokenRecognizer.Add(new RecognizeIfToken());
            tokenRecognizer.Add(new RecognizeAssignToken());
            tokenRecognizer.Add(new RecognizeBinaryPlusToken());
            tokenRecognizer.Add(new RecognizeBinaryMinToken());
            tokenRecognizer.Add(new RecognizeBinaryMultiplyToken());
            tokenRecognizer.Add(new RecognizeBinaryDivideToken());
            tokenRecognizer.Add(new RecognizeNumberToken());
            tokenRecognizer.Add(new RecognizeEndstatementToken());
            tokenRecognizer.Add(new RecognizeVariableToken()); // MUST BE LAST
            
        }

        public LinkedListNode<Token> create(string line) {
            Token token = null;
             // Only remembered per line right now
            foreach(RecognizeTokenStrategy strategy in tokenRecognizer) {
                token = strategy.match(line, lastToken);
                if(token != null) {
                    lastToken = token;
                    break; //if a strategy found a match and created a token, break
                }
            }
            
            return new LinkedListNode<Token>(token);
        }
    }
}
