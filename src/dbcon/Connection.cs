using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Npgsql;
using Spectre.Console;

namespace main.src.dbcon
{
    public static class Connectiondb
    {
        //static MySqlConnection con = new("Persist Security Info=False;server=127.0.0.1;userid=root;database=test");
        static NpgsqlConnection con = new NpgsqlConnection("Persist Security Info=False;server=127.0.0.1;username=postgres;database=Umc;");
        public static void executeScript(string sql){
            try
            {
                con.Open();
                //Console.WriteLine($"MySQL version : {con.ServerVersion}");
            }
            catch (System.Exception e)
            {
                Console.WriteLine (e.Message.ToString());
                //MessageBox.Show(e.Message.ToString());
            }

            //verificva se a conexão esta aberta
            if (con.State == ConnectionState.Open)
            {
                Console.WriteLine("connection Open!");
                using var cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery(); 
                con.Close();
            }

           
        }

        public static void executeQuery(string sql)
        {
            var table = new Table();
            try
            {
                con.Open();
                //verificva se a conexão esta aberta
                if (con.State == ConnectionState.Open)
                {
                    //Console.WriteLine("connection Open!");
                    using var cmd = new NpgsqlCommand(sql, con);
                    
                    using NpgsqlDataReader rdr = cmd.ExecuteReader();
                    string[] numb;
                    numb = new string[rdr.FieldCount];

                    
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

                    con.Close();
                }
            }
            catch (System.Exception e)
            {
                string msg = "ERROR: When Tried to execute [" + sql + "]";
                msg += " | execption Error: " + e.Message.ToString();
                Console.WriteLine(msg);
            }
        }
    }
}