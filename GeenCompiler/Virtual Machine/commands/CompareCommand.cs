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

            if(leftVariable.Type == VariableType.Number && rightVariable.Type == VariableType.Number) //values are parsable as numbers.
            {
                int left = int.Parse(leftVariable.Value);
                int right = int.Parse(rightVariable.Value);

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

            //TODO: compare strings?
        }

        public override bool Match(string name) {
            return name == "AreEqual" || name == "IsSmaller" || name == "IsLarger" || name == "IsSmallerOrEqual" || name == "IsLargerOrEqual";
        }
    }
}
