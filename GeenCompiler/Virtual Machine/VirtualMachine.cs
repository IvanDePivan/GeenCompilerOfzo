using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler;
using GeenCompiler.Compiler.Nodes;

namespace GeenCompiler.Virtual_Machine {
    public class VirtualMachine {
        public void Run(NodeLinkedList list) {
            ActionNode currentNode = list.First;

            while(currentNode != null) {
                // Doe iets met de huidige node: 
                //          Command pattern

                // Bepaal de volgende node: 
                //          Visitor pattern
            }
        }
    }

}
