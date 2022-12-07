using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.Data.SQLite;

namespace Repositories
{
    public class CadeteRepository : ICadeteRepository
    {
        readonly string? _connectionString;
        public CadeteRepository(IConnectionString connectionString){
            _connectionString = connectionString.GetString();
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
        public void Save(Cadete cadete){
            var queryString = $"INSERT INTO cadetes (name_cad, address_cad, phone_cad, id_cadeteria1) VALUES ('{cadete.Name}', '{cadete.Address}', '{cadete.Phone}', 1);";
            Consulta(queryString);
        }
        public void Update(Cadete cadete){
            var queryString = $"UPDATE cadetes SET name_cad='{cadete.Name}', address_cad='{cadete.Address}', phone_cad='{cadete.Phone}' WHERE id_cad={cadete.Id};";
            Consulta(queryString);
        }
        public void Delete(int? id){
            var queryString = $"DELETE FROM cadetes WHERE id_cad = {id};";
            Consulta(queryString);
        }
        private Cadete GetCadete(SQLiteDataReader reader){
            return new Cadete(){
                Id = Convert.ToInt32(reader["id_cad"]),
                Name = reader["name_cad"].ToString(),
                Address = reader["address_cad"].ToString(),
                Phone = reader["phone_cad"].ToString()
            };
        }
        public Cadete? GetById(int? id){
            Cadete? cadete = null;
            var connection = GetConnection();
            var queryString = $"SELECT * FROM cadetes WHERE id_cad = {id};";
            var command = new SQLiteCommand(queryString, connection);
            using(var reader = command.ExecuteReader()){
                while(reader.Read()){
                    cadete = GetCadete(reader);
                }
            }
            connection.Close();
            return cadete;
        }

        public List<Cadete> GetAll() {
            var cadetes = new List<Cadete>();
            var connection = GetConnection();
            var queryString = $"SELECT * FROM cadetes;";
            var command = new SQLiteCommand (queryString, connection);
            using (var reader = command.ExecuteReader()){
                while(reader.Read()){
                    cadetes.Add(GetCadete(reader));
                }
            }
            connection.Close();
            return cadetes;
        }
    }
}