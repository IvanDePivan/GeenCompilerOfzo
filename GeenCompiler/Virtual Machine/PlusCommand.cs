using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Tokens;

namespace GeenCompiler.Virtual_Machine {
    public class PlusCommand : BaseCommand {
        public override void Execute(VirtualMachine vm, IList<string> parameterNames) {
            //var variable1 = compiler.GetVariable(parameterNames[1]);
            //var variable2 = compiler.GetVariable(parameterNames[2]);

//             if(variable1.Type == VariableType.NUMBER && variable2.Type == VariableType.NUMBER)
//                 vm.ReturnValue = (Int32.Parse(variable1.Value) + Int32.Parse(variable2.Value))
//                                   .ToString();
//             else
//                 vm.ReturnValue = variable1.Value + variable2.Value;
        }
    }

}
