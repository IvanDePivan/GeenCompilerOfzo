using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Tokens;

namespace GeenCompiler
{
    class Token
    {
        public TokenType type;
        public String value;
        public int lineNumber;
        public int colNumber;
        public Token partner;
        public int level;
        public Token nextToken;
    }
}
