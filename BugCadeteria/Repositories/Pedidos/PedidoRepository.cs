using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Models;

namespace Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        readonly string? _connectionString;
        public PedidoRepository(IConnectionString connectionString){
            _connectionString = connectionString.GetString();
        }

        private SQLiteConnection GetConnection(){
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
        private void Consulta(string? consulta){
            var connection = GetConnection();
            var command = new SQLiteCommand(consulta, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Save(Pedido pedido, int id){
            var queryString = $"INSERT INTO Pedidos (details_ped, state_ped, id_cad1,id_client1) VALUES ('{pedido.Obs}','pendiente',1,{id});";
            Consulta(queryString);
        }

        private Pedido GetPedido(SQLiteDataReader reader){
            var pedido = new Pedido();
            pedido.Id = Convert.ToInt32(reader["id_ped"]);
            pedido.Obs = reader["details_ped"].ToString();
            return pedido;
        }
        public List<Pedido> GetAll() {
            var pedidos = new List<Pedido>();
            var connection = GetConnection();
            var queryString = $"SELECT * FROM Pedidos WHERE id_client1 > 0;";
            var command = new SQLiteCommand (queryString, connection);
            using (var reader = command.ExecuteReader()){
                while(reader.Read()){
                    pedidos.Add(GetPedido(reader));
                }
            }
            connection.Close();
            return pedidos;
        }
    }
}