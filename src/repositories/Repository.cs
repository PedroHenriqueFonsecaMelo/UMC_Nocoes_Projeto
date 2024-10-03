using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using MySql.Data.MySqlClient;
using Spectre.Console;


namespace UMC_Nocoes_Projeto.src.repositories
{
    public class Repository : IDisposable
    {
        private MySqlConnection con;
        //static NpgsqlConnection con = new NpgsqlConnection("Persist Security Info=False;server=127.0.0.1;username=postgres;database=Umc;");
        public void executeScript(string sql)
        {

            //verificva se a conexão esta aberta
            if (con.State == ConnectionState.Open)
            {
                //Console.WriteLine("connection Open!");
                using var cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public Repository()
        {
            con = null;
            con = new("Persist Security Info=False;server=127.0.0.1;userid=root;database=test");
            try
            {
                con.Open();
                //Console.WriteLine($"MySQL version : {con.ServerVersion}");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                //MessageBox.Show(e.Message.ToString());
            }
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Close();
            }
            con = null;
        }

        public void executeQuery(string sql)
        {
            var table = new Table();
            try
            {
                //verificva se a conexão esta aberta
                if (con.State == ConnectionState.Open)
                {
                    //Console.WriteLine("connection Open!");
                    using var cmd = new MySqlCommand(sql, con);

                    using MySqlDataReader rdr = cmd.ExecuteReader();

                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        table.AddColumn(rdr.GetName(i).ToString());

                        //Console.Write(rdr.GetName(i).ToString() + "\t");
                    }

                    Console.WriteLine();

                    while (rdr.Read())
                    {
                        List<string> rows = new List<string>();

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            rows.Add(rdr.GetValue(i).ToString());

                        }

                        table.AddRow(rows.ToArray());
                        //Console.WriteLine(rdr.GetType());
                    }

                    AnsiConsole.Write(table);

                    Console.WriteLine();
                }
            }
            catch (System.Exception e)
            {
                string msg = "ERROR: When Tried to execute [" + sql + "]";
                msg += " | execption Error: " + e.Message.ToString();
                Console.WriteLine(msg);
            }
        }
        public void CreateTableX(Type classe)
        {
            Object obj = Activator.CreateInstance(classe);

            FieldInfo[] Fields = classe.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder table = new StringBuilder();
            String name, tipo;
            int i = 0;
            table.Append("create table " + obj.GetType().Name + " (");


            foreach (FieldInfo f in Fields)
            {

                i++;
                name = f.Name;
                tipo = f.FieldType.Name;

                if (i <= Fields.Length - 1)
                {
                    table.Append(extracted(name, tipo) + " , ");
                }
                else
                {
                    table.Append(extracted(name, tipo) + ");");
                }
            }

            Console.WriteLine(table.ToString());
            executeScript(table.ToString());

        }

        private static String extracted(String name, String tipo)
        {
            switch (tipo)
            {
                case "String":
                    return " " + name + " VARCHAR(100) ";
                case "Int32":
                    return " " + name + " INT ";
                case "Date":
                    return " " + name + " DATE ";
                case "float":
                    return " " + name + " NUMERIC(20, 2) ";
                case "ID":
                    return " " + name + " INT PRIMARY KEY AUTO_INCREMENT ";
                default:
                    return "";
            }
        }
    }
}