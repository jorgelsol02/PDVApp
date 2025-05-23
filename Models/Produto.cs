using System;
using Microsoft.Data.SqlClient;

namespace PDVApp.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    

    public List<Produto> ListarProdutos()
        {
            List<Produto> produtos = new();
            Database db = new();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Produtos", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    produtos.Add(new Produto
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Preco = (decimal)reader["Preco"],
                        Estoque = (int)reader["Estoque"]
                    });
                }
            }

            return produtos;
        }

    }
}

