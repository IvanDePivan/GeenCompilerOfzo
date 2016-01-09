using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    public enum TokenType {
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
        Boolean,
        Print,
        ParenthesisOpen,
        ParenthesisClose,
        BracketOpen,
        BracketClose
    }
}
