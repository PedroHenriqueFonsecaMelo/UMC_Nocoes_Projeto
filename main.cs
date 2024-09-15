using System;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

class Program {
  public static void Main (string[] args) {
     
    string cs = @"server=127.0.0.1;
    userid=root;
    database=test";

    using var con = new MySqlConnection(cs);
    con.Open();

    Console.WriteLine($"MySQL version : {con.ServerVersion}");
  }
}