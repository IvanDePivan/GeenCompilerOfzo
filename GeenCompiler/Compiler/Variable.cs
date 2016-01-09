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
            Value = t.value;
            defineType(t.value);
        }

        public Variable(string value)
        {
            defineType(value);
            Value = value;
        }

        public Variable(VariableType vt, string value)
        {
            this.Type = vt;
            this.Value = value;
        }

        private void defineType(string value){
            int i = 0;
            if(int.TryParse(value, out i))
                this.Type = VariableType.Number;
            else if(value.Equals("false") || value.Equals("true"))
                this.Type = VariableType.Boolean;
            else
                this.Type = VariableType.String;
        }
    }
}
