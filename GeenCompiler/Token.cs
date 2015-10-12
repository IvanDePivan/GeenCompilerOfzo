using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler
{
    class Token
    {
        public String type;
        public String value;
        public int lineNumber;
        public int colNumber;
        public Token partner;
        public int level;
        public Token nextToken;
        

    }
}
