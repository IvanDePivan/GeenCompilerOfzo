using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Tokens {
    class Tokenizer {
        private static TokenFactory tokenFactory = new TokenFactory();
        public static List<Token> tokenize(string[] strings) {
            List<Token> tokens = new List<Token>();
            int currentLine = 0;
            foreach(string line in strings) {
                int currentCol = 0;
                while(currentCol < line.Length) {
                    //We pass the line to the factory
                    //The factory checks if the token matches any strategy.
                    Token token = tokenFactory.create(line.Substring(currentCol));

                    if(token == null) {
                        throw new NullReferenceException("Could not identify code! line: " + (currentLine + 1) + ", col: " + (currentCol + 1) + "\n" + 
                                                            line[currentLine]);
                    } else {
                        token.lineNumber = currentLine;
                        token.colNumber = currentCol;

                        tokens.Add(token);

                        //move ahead the number of characters are in this token
                        currentCol += token.value.Length;
                    }
                }
                currentLine++;
            }
            return tokens;
        }
    }
}
