using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMC_Nocoes_Projeto.src.command;

namespace UMC_Nocoes_Projeto.src.invoker
{
    public class Invoker
    {
        private Command command = null;

        public Invoker(Command command)
        {
            this.command = command;
        }

        public Command Command { get => command; set => command = value; }

        public void ExecuteCommand(){
            command.Execute();
        }
    }
}