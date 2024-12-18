﻿using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Models;
using System.ComponentModel;
using System.Text.Json.Nodes;


namespace Negocio
{
    public class ProductsAPI
    {
        private const string connStr = "Server=db4free.net;Database=lasnieves110424;Uid=lasnieves110424;Pwd=lasnieves110424;";

        public List<Product> GetAll()
        {
            List<Product> listaProducts = new List<Product>();
            using (MySqlConnection myConn = new MySqlConnection(connStr))
            {
                myConn.Open();

                string sql = "SELECT * FROM Products";

                listaProducts = myConn.Query<Product>(sql).ToList();
            }
            return listaProducts;
        }
        public List<string> GetAllCategories()
        {
            List<string> listaCategories = new List<string>();
            using (MySqlConnection myConn = new MySqlConnection(connStr))
            {
                myConn.Open();

                string sql = "SELECT Category FROM Categories";

                listaCategories = myConn.Query<string>(sql).ToList();
            }
            return listaCategories;
        }
        public Product GetById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT * FROM Products WHERE Id = @Id";

                return conn.QueryFirstOrDefault<Product>(sql, new { Id = id });
            }
        }
        public int Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "DELETE FROM Products WHERE Id = @Id";
                int rowsAffected = conn.Execute(sql, new { Id = id });

                return rowsAffected; 
            }
        }

        public Product Put(Product prod)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "UPDATE Products SET Title = @Title, Description = @Description, Category = @Category, Price = @Price WHERE Id = @Id";
                int rowsAffected = conn.Execute(sql, prod);


                if (rowsAffected > 0)
                {
                    return prod; 
                }
                else
                {
                    return null;
                }
            }
        }
        public Product Post(Product prod)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "INSERT INTO Products (Title, Description, Category, Price) VALUES (@Title, @Description, @Category, @Price)";
                conn.Execute(sql, prod);
                
                return prod;
            }
        }

    }
}