using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeenCompiler.Compiler;
using GeenCompiler.Compiler.Nodes;

namespace GeenCompiler.Virtual_Machine {
    public class VirtualMachine {
        private Dictionary<string, Variable> variables;
        public Variable Return;
        
        public void Run(NodeLinkedList list) {
            ActionNode currentNode = list.First;
            variables = new Dictionary<string, Variable>();
            NodeVisitor visitor = new NodeVisitor(this);
            while(currentNode != null) {
                currentNode.accept(visitor);
                currentNode = currentNode.Next;
                // Doe iets met de huidige node: 
                //          Command pattern

                // Bepaal de volgende node: 
                //          Visitor pattern
            }
        }

        public void setVariable(string key, Variable value)
        {
            variables.Add(key, value);
        }

        public Variable getVariable(string key)
        {
            if (variables.ContainsKey(key))
                return variables[key];
            return null;
        }
    }

}
