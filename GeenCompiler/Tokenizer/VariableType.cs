using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    public enum VariableType {
        If,
        Else,
        ElseIf,
        Add,
        Subtract,
        Assign,
        Equals,
        Largerthan,
        SmallerThan,
        LargerOrEqualThan,
        SmallerOrEqualThan,
        Multiply,
        Divide,
        And,
        Or,
        Number,
        Variable,
        Endstatement,
        Print,
        ParenthesisOpen,
        ParenthesisClose,
        BracketOpen,
        BracketClose
    }
}
