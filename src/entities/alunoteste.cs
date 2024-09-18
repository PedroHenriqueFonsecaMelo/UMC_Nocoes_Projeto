using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using main.src.services;

namespace main.src.entities
{
    public class AlunoTeste
    {

        private int rgm;
        private String senha;
        private String nome;
        private String gen;
        private String email;



        public AlunoTeste(int rgm, string senha, string nome, string gen, string email)
        {
            this.rgm = rgm;
            this.senha = senha;
            this.nome = nome;
            this.gen = gen;
            this.email = email;
        }

        public int Rgm { get => rgm; set => rgm = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Gen { get => gen; set => gen = value; }
        public string Email { get => email; set => email = value; }

        public AlunoTeste(Boolean alunomod)
        {
            if (alunomod)
            {
                EntityServices.AutoClassBuilder(this);
            }
            else
            {
                rgm = 0;
                senha = null;
                nome = null;
                gen = null;
                email = null;
            }
        }

        public static string ToStringInfo(){
            return EntityServices.ClassInfo(typeof(AlunoTeste));
        }
    }
}