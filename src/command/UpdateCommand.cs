using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMC_Nocoes_Projeto.src.repositories;

namespace UMC_Nocoes_Projeto.src.command
{
    public class UpdateCommand : Command
    {
        Repository repository;
        public UpdateCommand(string sql) : base(sql)
        {
        }

        public override void Execute()
        {
            if (base.Sql.Contains("UPDATE"))
            {
                using (repository = new Repository())
                {
                    repository.executeScript(base.Sql);
                }
            }
        }
    }
}