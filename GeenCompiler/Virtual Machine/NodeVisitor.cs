using GeenCompiler.Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Virtual_Machine {
    public class NodeVisitor {
        //public void visit(PlusCommand command) {
            //Doe iets hiermee
        //}
        private VirtualMachine vm;
        private List<BaseCommand> commands;
        public NodeVisitor(VirtualMachine vm)
        {
            this.vm = vm;
            commands = new List<BaseCommand>();
            commands.Add(new MinCommand());
            commands.Add(new PlusCommand());
            commands.Add(new DivideCommand());
            commands.Add(new MultiplyCommand());
        }
        public void visit(DirectFunctionCallNode dfcn)
        {
            if (dfcn.Name == DirectFunctionCallNode.CONSTANTTORETURN)
                vm.Return = dfcn.Value;
            else if (dfcn.Name == DirectFunctionCallNode.RETURNTOVARIABLE)
                vm.setVariable(dfcn.Value.Value, vm.Return);
            else if (dfcn.Name == DirectFunctionCallNode.VARIABLETORETURN)
                vm.Return = vm.getVariable(dfcn.Value.Value);
        }

        public void visit(DoNothingNode dnn)
        {

        }

        public void visit(ConditionalJumpNode cjn)
        {
            throw new NotImplementedException();
        }

        public void visit(FunctionCallNode fcn)
        {
            foreach (BaseCommand bc in commands)
            {
                if (bc.Match(fcn.Name))
                {
                    bc.Execute(vm, fcn);
                }
            }
            //throw new NotImplementedException();
        }

    }
}
