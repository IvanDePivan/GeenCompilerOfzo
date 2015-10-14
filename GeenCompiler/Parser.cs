using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GeenCompiler.Tokens;

namespace GeenCompiler {
    class Parser {
        Token startToken;
        Token lastToken;
        String[] keys;
        int currentLevel;
        String[] openLevelKeys;
        String[] closeLevelKeys;
        List<String> stack;
        List<RecognizeTokenStrategy> tokenRecognizers;

        public Parser()
        {
            stack = new List<String>();
            currentLevel = 0;
            keys = new String[] { "als" };
            openLevelKeys = new String[] { "(", "{" };
            closeLevelKeys = new String[] { ")", "}" };

            tokenRecognizers = new List<RecognizeTokenStrategy>();
            tokenRecognizers.Add(new RecognizeIfToken());
        }
        public string[] readFile(string file){
            //Divide file in seperate lines for easy row counting
            string[] lines = System.IO.File.ReadAllLines(file);

            for(int i = 0; i < lines.Count(); i++) {
                lines[i] = Regex.Replace(lines[i], @"\s+", ""); // we don't need whitespace
            }

            return lines;
        }

    }
}
