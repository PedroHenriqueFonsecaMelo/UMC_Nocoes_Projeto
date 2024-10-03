using System;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using System.Data.SqlClient;
using Npgsql;


class main_teste
{
  public static void Main(string[] args)
  {

    /*Livro livro = new Livro();
    StringBuilder sql = new StringBuilder("create table Livro (");
    
    foreach(var prop in livro.GetType().GetProperties()) {
        sql.Append(prop.Name + "; ");
    }*/

    string cs = @"server=127.0.0.1;username=postgres;database=Umc;";

    using var con = new NpgsqlConnection(cs);
    con.Open();

    Console.WriteLine($"MySQL version : {con.ServerVersion}");

    con.Close();
  }
}