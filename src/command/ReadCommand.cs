using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMC_Nocoes_Projeto.src.repositories;

namespace UMC_Nocoes_Projeto.src.command
{
    public class ReadCommand : Command
    {
        Repository repository;

        public ReadCommand(string sql) : base(sql)
        {


        }

        public override void Execute()
        {
            if (base.Sql.Contains("SELECT"))
            {
                using (repository = new Repository())
                {

                    repository.executeQuery(base.Sql);

                }
            }
        }
    }
}