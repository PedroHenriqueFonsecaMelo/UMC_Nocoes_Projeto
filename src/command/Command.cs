using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMC_Nocoes_Projeto.src.command
{
    public abstract class Command
    {
        private string sql;

        protected Command(string sql)
        {
            this.sql = sql;
        }

        public string Sql { get => sql; set => sql = value; }

        public abstract void Execute();
    }
}