using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    interface RecognizeTokenStrategy {
        //NOTE: lastToken is NOT guaranteed!
        Token match(string name, Token lastToken);
    }
}
