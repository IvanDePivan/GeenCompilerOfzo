using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeenCompiler {
    class Parser {
        Token startToken;
        Token lastToken;
        String[] keys;
        int currentLevel;
        String[] openLevelKeys;
        String[] closeLevelKeys;
        List<String> stack;

        public Parser()
        {
            stack = new List<String>();
            currentLevel = 0;
            keys = new String[] { "als" };
            openLevelKeys = new String[] { "(", "{" };
            closeLevelKeys = new String[] { ")", "}" };
        }
        public void readFile(){
            
            string[] lines = System.IO.File.ReadAllLines("code.ivaron");

            for(int i = 0; i < lines.Length; i++) {
                tokenizeLine(lines[i], i);
            }

            writeTokens();

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        private void writeTokens()
        {
            Token nextToken = startToken;
            while (nextToken != null)
            {
                Console.WriteLine(nextToken.level + " : " + nextToken.type);
                nextToken = nextToken.nextToken;
            }
        }
        Regex letter = new Regex(@"^[a-zA-Z]+");
        Regex cijfer = new Regex(@"^\d");
        
        private void tokenizeLine(string line, int lineNumber)
        {
            string[] words = line.Split(new char[0]);
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    Token t = new Token();
                    t.lineNumber = lineNumber;
                    t.type = "token: " + word;
                    t.level = currentLevel;
                    if (letter.IsMatch(word))
                    {
                        if (keys.Contains(word))
                        {
                            t.type = "keyword: " + word;
                        }
                        else
                        {
                            t.type = "variable: " + word;
                        }
                    }
                    else if (cijfer.IsMatch(word))
                        t.type = "cijfer: " + word;
                    else if (openLevelKeys.Contains(word))
                    {
                        stack.Add(word);
                        t.type = "open level";
                        currentLevel++;
                    }
                    else if (closeLevelKeys.Contains(word))
                    {
                        t.type = "close level";
                        currentLevel--;
                    }

                    addTokenToList(t);
                }
            }
            
            
            
        }

        private void addTokenToList(Token t)
        {
            if (startToken == null)
                startToken = t;
            if (lastToken == null)
                lastToken = t;
            else
            {
                lastToken.nextToken = t;
                lastToken = t;
            }
        }
    }
}
