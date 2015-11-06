using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler;
using GeenCompiler.Tokens;

namespace GeenCompiler.Virtual_Machine {
    class CompareCommand : BaseCommand {
        public override void Execute(VirtualMachine vm, Compiler.Nodes.FunctionCallNode node) {
            Variable leftVariable = vm.getVariable(node.Left);
            Variable rightVariable = vm.getVariable(node.Right);

            if((leftVariable.Type == VariableType.Number && rightVariable.Type == VariableType.Number)) 
            {
                int left = Int32.Parse(leftVariable.Value);
                int right = Int32.Parse(rightVariable.Value);

                switch(node.Name) {
                    case "AreEqual":
                        vm.Return = new Variable(VariableType.Boolean, (left == right).ToString());
                        break;
                    case "IsSmaller":
                        vm.Return = new Variable(VariableType.Boolean, (left < right).ToString());
                        break;
                    case "IsLarger":
                        vm.Return = new Variable(VariableType.Boolean, (left > right).ToString());
                        break;
                    case "IsSmallerOrEqual":
                        vm.Return = new Variable(VariableType.Boolean, (left <= right).ToString());
                        break;
                    case "IsLargerOrEqual":
                        vm.Return = new Variable(VariableType.Boolean, (left <= right).ToString());
                        break;
                }
            }
        }

        public override bool Match(string name) {
            return name == "Divide";
        }
    }
}
