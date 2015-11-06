using GeenCompiler.Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Virtual_Machine {
    public abstract class BaseCommand {
        public abstract void Execute(VirtualMachine vm, FunctionCallNode node);
        public abstract bool Match(string name);
    }

}
