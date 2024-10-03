using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace UMC_Nocoes_Projeto.src.templates
{
    public abstract class TemplateMethod()
    {
        public void run(string op)
        {
            limparTela();
            executarAcao(op);
        }
        public abstract void executarAcao(string op);
        public void limparTela()
        {
            Console.Clear();
            AnsiConsole.Clear();
        }

    }

}