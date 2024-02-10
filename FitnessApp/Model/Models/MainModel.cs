using Model.Models;
using System;

namespace Model
{
    public class Program
    {
        static void MainModel(string[] args)
        {
            string host = "surus.db.elephantsql.com";
            string port = "5432";
            string database = "pcrerpgl";
            string username = "pcrerpgl";
            string password = "kyjKyeMkVKy4y-S544YNQ2CR-JZj3xF9";

            DBConnector connector = new DBConnector(host, port, database, username, password);

            connector.Connect();
        }
    }
}