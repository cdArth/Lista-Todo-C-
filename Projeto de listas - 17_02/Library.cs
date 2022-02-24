using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_listas___17_02
{
    public class Library
    {
        static string connStr =
            ConfigurationManager.ConnectionStrings["DTM"].ConnectionString;
        public List<Item> ObterItens(int id)
        {
            List<Item> items = new List<Item>();
            Item result;
            var strConn = connStr;

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"select * from Itens" +
                        $" where TodoId = @pId";
                    command.Parameters.AddWithValue("pId", id);

                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            result = new Item("");
                            result.id = Convert.ToInt32(reader["Id"]);
                            result.titulo = reader["Titulo"].ToString();
                            result.feito = Convert.ToBoolean(reader["Feito"]);
                            items.Add(result);
                        }
                }

            };

            return items;
        }
        public List<Todo> ObterListas()
        {
            List<Todo> result = new List<Todo>();
            Todo todo;
            var strConn = connStr;

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"select * from Todos";

                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            todo = new Todo();
                            todo.id = Convert.ToInt32(reader["Id"]);
                            todo.Nome = reader["Nome"].ToString();
                            result.Add(todo);


                        }
                }

            };

            return result;
        }
        public void AdicionarLista(string nome)
        {
            var strConn = connStr;

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"insert into Todos (Nome) values (@pNome)";
                    command.Parameters.AddWithValue("pNome", nome);
                    command.ExecuteNonQuery();
                }

            };

        }
        public void AdicionarItem(Item item)
        {
            var strConn = connStr;

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"insert into Itens (Titulo,TodoId) values (@pTitulo,@pTodoId)";
                    command.Parameters.AddWithValue("pTitulo", item.titulo);
                    command.Parameters.AddWithValue("pTodoId", item.id);
                    command.ExecuteNonQuery();
                }

            };

        }
        public void ExcluirItem(int id)
        {
            var strConn = connStr;

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"delete from Itens where Id=@pId";
                    command.Parameters.AddWithValue("pId", id);
                    command.ExecuteNonQuery();
                }

            };

        }

        public void EditarItem(Item item)
        {
            var strConn = connStr;

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"update Itens set Titulo=@pTitulo where Id=@pId";
                    command.Parameters.AddWithValue("pId", item.id);
                    command.Parameters.AddWithValue("pTitulo", item.titulo);
                    command.ExecuteNonQuery();
                }

            };

        }
        public void MarcarConcluido(int id)
        {
            var strConn = connStr;

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"update Itens set Feito = 1 where Id=@pId";
                    command.Parameters.AddWithValue("pId", id);
                    command.ExecuteNonQuery();
                }

            };

        }
        public void DesmarcarConcluido(int id)
        {
            var strConn = connStr;

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"update Itens set Feito = 0 where Id=@pId";
                    command.Parameters.AddWithValue("pId", id);
                    command.ExecuteNonQuery();
                }

            };
        }
    }
}
