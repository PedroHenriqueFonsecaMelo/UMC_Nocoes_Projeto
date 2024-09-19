using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Spectre.Console;

namespace main.src.dbcon
{
    public static class Connectiondb
    {
        static MySqlConnection con = new("Persist Security Info=False;server=127.0.0.1;userid=root;database=test");
        //static NpgsqlConnection con = new NpgsqlConnection("Persist Security Info=False;server=127.0.0.1;username=postgres;database=Umc;");
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
                using var cmd = new MySqlCommand(sql, con);
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
                    using var cmd = new MySqlCommand(sql, con);
                    
                    using MySqlDataReader rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            table.AddColumn(rdr.GetName(i).ToString());
                            
                            //Console.Write(rdr.GetName(i).ToString() + "\t");
            
                        }
                        Console.WriteLine();
                        for (int i = 0; i < rdr.FieldCount - 1; i++)
                        {
                            table.AddRow(rdr);
                            //Console.Write(rdr[i].ToString() + "\t");
                        }
                        AnsiConsole.Write(table);
                        //Console.WriteLine(rdr.GetType());
                    }

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