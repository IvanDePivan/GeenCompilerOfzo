using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Tokens;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Compiler;

namespace GeenCompiler.Virtual_Machine {
    public class PrintCommand : BaseCommand {
        public override void Execute(VirtualMachine vm, FunctionCallNode node) {

            Console.WriteLine(vm.Return.Value);
        }

        public override bool Match(string name)
        {
            return name == "Print";
        }
    }

}
