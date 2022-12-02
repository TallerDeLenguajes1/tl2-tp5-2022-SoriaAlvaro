using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Models;

namespace Repositories
{
    public class RepoCadete : IRepoCadete
    {
        private SQLiteConnection GetConnection(){
            var cadConnection = @"Data Source=cadeteriabug.db;Version=3;";
            var connection = new SQLiteConnection(cadConnection);
            connection.Open();
            return connection;
        }

        public void Save(Cadete cadete){
            var connection = GetConnection();
            var queryString = $"INSERT INTO cadetes (name_cad, address_cad, phone_cad, id_cadeteria1) VALUES ('{cadete.Name}', '{cadete.Address}', '{cadete.Phone}', 1);";
            var command = new SQLiteCommand (queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Cadete GetById(int? id){
            Cadete? cadete = null;
            var connection = GetConnection();
            var queryString = $"SELECT * FROM cadetes WHERE id_cad={id};";
            var command = new SQLiteCommand (queryString, connection);
            using (var reader = command.ExecuteReader()){
                while (reader.Read()){
                    cadete = GetCadete(reader);
                }
            }
            connection.Close();
            return cadete;
        }

        public List<Cadete>? GetAll() {
            var cadetes = new List<Cadete>();
            var connection = GetConnection();
            var queryString = $"SELECT * FROM cadetes;";
            var command = new SQLiteCommand (queryString, connection);
            using (var reader = command.ExecuteReader()){
                Cadete newCadete;
                while(reader.Read()){
                    newCadete = GetCadete(reader);
                    cadetes.Add(newCadete);
                }
            }
            connection.Close();
            return cadetes;
        }

        public Cadete GetCadete(SQLiteDataReader reader){
            return new Cadete(){
                Id = Convert.ToInt32(reader["id_cad"]),
                Name = reader["name_cad"].ToString(),
                Address = reader["address_cad"].ToString(),
                Phone = reader["phone_cad"].ToString()
            };
        }
        public void Update(Cadete cadete){
            string? name = cadete.Name,
            address = cadete.Address,
            phone = cadete.Phone;
            int cadId = cadete.Id;
            var connection = GetConnection();
            var queryString = $"UPDATE cadetes SET name_cad = '{name}', address_cad = '{address}', phone_cad = '{phone}' WHERE id_cad = {cadId};";
            var command = new SQLiteCommand (queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int id){
            var connection = GetConnection();
            var queryString = $"DELETE FROM cadetes WHERE id_cad = {id};";
            var command = new SQLiteCommand (queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}