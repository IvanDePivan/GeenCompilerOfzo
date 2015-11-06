using GeenCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Compiler
{
    public class Variable
    {
        public VariableType Type;
        public string Value;

        public Variable(Token t)
        {
            Type = t.type;
            Value = t.value;
        }

        public Variable(string value)
        {
            this.Type = VariableType.Variable;
            Value = value;
        }
    }
}
