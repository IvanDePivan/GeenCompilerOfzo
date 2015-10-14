using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Tokens;

namespace GeenCompiler {
    class Program {
        static void Main(string[] args) {
            Parser p = new Parser();
            string[] codeLines = p.readFile("code.ivaron"); //Read code

            List<Token> list = new List<Token>();
            try {
                list = Tokenizer.tokenize(codeLines); //Tokenize code
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            if(list.Count > 0) {
                foreach(Token token in list) {
                    Console.WriteLine("Token: " + token.value);
                }
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
