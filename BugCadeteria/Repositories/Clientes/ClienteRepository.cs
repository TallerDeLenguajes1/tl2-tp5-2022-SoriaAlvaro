using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.Data.SQLite;
using AutoMapper;

namespace Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        readonly string? _connectionString;
        readonly IMapper _mapper;
        public ClienteRepository(IConnectionString connectionString, IMapper mapper){
            _connectionString = connectionString.GetString();
            _mapper = mapper;
        }

        private SQLiteConnection GetConnection(){
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
        private void Consulta(string? consulta){
            var connection = GetConnection();
            var queryString = consulta;
            var command = new SQLiteCommand(queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Save(Cliente cliente){
            var queryString = $"INSERT INTO clientes (name_client, address_client, phone_client) VALUES ('{cliente.Name}', '{cliente.Address}', '{cliente.Phone}');";
            Consulta(queryString);
        }
        public void Update(Cliente cliente){
            var queryString = $"UPDATE clientes SET name_client='{cliente.Name}', address_client='{cliente.Address}', phone_client='{cliente.Phone}' WHERE id_client={cliente.Id};";
            Consulta(queryString);
        }
        public void Delete(int? id){
            var queryString = $"DELETE FROM clientes WHERE id_client = {id};";
            Consulta(queryString);
        }
        private Cliente GetCliente(SQLiteDataReader reader){
            return new Cliente(){
                Id = Convert.ToInt32(reader["id_client"]),
                Name = reader["name_client"].ToString(),
                Address = reader["address_client"].ToString(),
                Phone = reader["phone_client"].ToString()
            };
        }
        public Cliente? GetById(int? id){
            Cliente? cliente = null;
            var connection = GetConnection();
            var queryString = $"SELECT * FROM clientes WHERE id_client = {id};";
            var command = new SQLiteCommand(queryString, connection);
            using(var reader = command.ExecuteReader()){
                while(reader.Read()){
                    cliente = GetCliente(reader);
                }
            }
            connection.Close();
            return cliente;
        }

        public List<Cliente> GetAll() {
            var clientes = new List<Cliente>();
            var connection = GetConnection();
            var queryString = $"SELECT * FROM clientes;";
            var command = new SQLiteCommand (queryString, connection);
            using (var reader = command.ExecuteReader()){
                while(reader.Read()){
                    clientes.Add(GetCliente(reader));
                }
            }
            connection.Close();
            return clientes;
        }
    }
}