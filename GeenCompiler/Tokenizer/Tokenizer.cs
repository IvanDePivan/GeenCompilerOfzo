using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class Tokenizer {
        private static TokenFactory tokenFactory = new TokenFactory();
        public static LinkedList<Token> tokenize(string[] strings) {
            LinkedList<Token> tokens = new LinkedList<Token>();
            int currentLine = 0;
            foreach(string line in strings) {
                int currentCol = 0;
                while(currentCol < line.Length) {
                    //We pass the line to the factory
                    //The factory checks if the token matches any strategy.
                    LinkedListNode<Token> token = tokenFactory.create(line.Substring(currentCol));

                    if(token == null) {
                        throw new NullReferenceException("Could not identify code! line: " + (currentLine + 1) + ", col: " + (currentCol + 1) + "\n" + 
                                                            line[currentLine]);
                    } else {
                        token.Value.lineNumber = currentLine;
                        token.Value.colNumber = currentCol;
                        tokens.AddLast(token);

                        //move ahead the number of characters are in this token
                        currentCol += token.Value.value.Length;
                    }
                }
                currentLine++;
            }
            return tokens;
        }
    }
}
