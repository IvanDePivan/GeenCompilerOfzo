using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeenCompiler.Virtual_Machine {
    public class ReturnToVariableCommand : BaseCommand {
        public override void Execute(VirtualMachine vm, IList<string> parameters) {
            //vm.SetVariable(parameters[1], vm.ReturnValue);
        }
    }

}
