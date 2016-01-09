using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class Tokenizer {
        private static TokenFactory tokenFactory = new TokenFactory();
        private static Stack<string> errors = new Stack<string>();
        public static LinkedList<Token> tokenize(string[] strings) {
            LinkedList<Token> tokens = new LinkedList<Token>();
            Stack<Token> levelStack = new Stack<Token>();
            int currentLine = 0;
            foreach(string line in strings) {
                int currentCol = 0;
                while(currentCol < line.Length) {
                    //We pass the line to the factory
                    //The factory checks if the token matches any strategy.
                    LinkedListNode<Token> token = null;
                    try {
                        token = tokenFactory.create(line.Substring(currentCol));
                    } catch(InvalidTokenException e) {
                        errors.Push("L: [" + (currentLine) + "] C: [" + (currentCol + 1) + "] " + e.Message);
                    }

                    if(token != null) {
                        token.Value.lineNumber = currentLine;
                        token.Value.colNumber = currentCol;
                        tokens.AddLast(token);

                        //move ahead the number of characters are in this token
                        currentCol += token.Value.value.Length;
                        switch (token.Value.type)
                        {
                            case TokenType.BracketOpen:
                                levelStack.Push(token.Value);
                                break;
                            case TokenType.BracketClose:
                                {
                                    Token t = levelStack.Pop();
                                    if(t.type != TokenType.BracketOpen)
                                        errors.Push("unexpected " + token.Value.value + "on line " + token.Value.lineNumber);
                                    else
                                    {
                                        t.partner = token.Value;
                                        token.Value.partner = t;
                                    }
                                    break;
                                }

                            case TokenType.ParenthesisOpen:
                                levelStack.Push(token.Value);
                                break;
                            case TokenType.ParenthesisClose:
                                {
                                    Token t = levelStack.Pop();
                                    if(t.type != TokenType.ParenthesisOpen)
                                        errors.Push("unexpected " + token.Value.value + "on line " + token.Value.lineNumber);
                                    else
                                    {
                                        t.partner = token.Value;
                                        token.Value.partner = t;
                                    }
                                    break;
                                }  
                        }
                        token.Value.level = levelStack.Count;
                    }
                }
                currentLine++;
            }
            if(errors.Count > 0) {
                throw new CompilerException(errors);
            }
            return tokens;
        }
    }
}
