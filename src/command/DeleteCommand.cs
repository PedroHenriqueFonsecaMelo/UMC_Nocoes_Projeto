using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMC_Nocoes_Projeto.src.repositories;

namespace UMC_Nocoes_Projeto.src.command
{
    public class DeleteCommand : Command
    {
        Repository repository;
        public DeleteCommand(string sql) : base(sql)
        {
        }

        public override void Execute()
        {
            if (base.Sql.Contains("delete"))
            {
                using (repository = new Repository())
                {

                    repository.executeScript(base.Sql);

                }
            }
        }
    }
}