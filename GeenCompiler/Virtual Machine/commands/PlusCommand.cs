using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Tokens;
using GeenCompiler.Compiler.Nodes;
using GeenCompiler.Compiler;

namespace GeenCompiler.Virtual_Machine {
    public class PlusCommand : BaseCommand {
        public override void Execute(VirtualMachine vm, FunctionCallNode node) {
            Variable variable1 = vm.getVariable(node.Left);
            Variable variable2 = vm.getVariable(node.Right);

            if (variable1.Type == VariableType.Number && variable2.Type == VariableType.Number)
                vm.Return = new Variable((Int32.Parse(variable1.Value) + Int32.Parse(variable2.Value)).ToString());
            else
                vm.Return = new Variable(variable1.Value + variable2.Value);
        }

        public override bool Match(string name)
        {
            return name == "Add";
        }
    }

}
