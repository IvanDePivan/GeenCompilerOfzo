﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Tokens;
using GeenCompiler.Compiler;

namespace GeenCompiler {
    class Program {
        private static Stack<string> errors = new Stack<string>(); 
        static void Main(string[] args) {
            Parser p = new Parser();
            string[] codeLines = p.readFile("code.ivaron"); //Read code
            LinkedList<Token> list = new LinkedList<Token>();
            try {
                list = Tokenizer.tokenize(codeLines); //Tokenize code
            } catch(CompilerException e) {
                foreach (string error in e.Errors)
	            {
                    Console.WriteLine(error);
	            }
            }

            if(list.Count > 0) {
                LinkedListNode<Token> token = list.First;
                while(token != null ) {
                    Console.Write(token.Value.value + " ");
                    if(token.Value.value == "{" || token.Value.value == ";") {
                        Console.Write("\n");
                    }
                    token = token.Next;
                }
            }


            TheCompiler.compile(list.First);
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
