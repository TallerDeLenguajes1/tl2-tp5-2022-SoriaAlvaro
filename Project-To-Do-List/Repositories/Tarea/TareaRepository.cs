using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Project_To_Do_List.Models;

namespace Project_To_Do_List.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        readonly string? _connectionString;
        public TareaRepository(IConnectionString connectionString){
            _connectionString = connectionString.GetString();
        }
        private SQLiteConnection GetConnection(){
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
        private void Consulta(string? queryString){
            var connection = GetConnection();
            var command = new SQLiteCommand(queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Create(Tarea task){
            string queryString = $"INSERT INTO tareas (title, description) VALUES ('{task.title}', '{task.description}');";
            Consulta(queryString);
        }

        public void Remove(int id){
            string queryString = $"DELETE FROM tareas WHERE id={id};";
            Consulta(queryString);
        }

        public void Update(Tarea task){
            var queryString = $"UPDATE tareas SET title='{task.title}', description='{task.description}' WHERE id={task.id};";
            System.Console.WriteLine("esde es el id desde UPDATE" + task.id);
            Consulta(queryString);
        }

        private Tarea GetTask(SQLiteDataReader reader){
            return new Tarea(){
                id = Convert.ToInt32(reader["id"]),
                title = reader["title"].ToString(),
                description = reader["description"].ToString()
            };
        }

        public List<Tarea> GetAll(){
            var tasks = new List<Tarea>();
            var connection = GetConnection();
            var queryString = $"SELECT * FROM tareas;";
            var command = new SQLiteCommand (queryString, connection);
            using (var reader = command.ExecuteReader()){
                while(reader.Read()){
                    tasks.Add(GetTask(reader));
                }
            }
            connection.Close();
            return tasks;
        }

        public Tarea GetById(int? id){
            Tarea? task = null;
            var connection = GetConnection();
            var queryString = $"SELECT * FROM tareas WHERE id = {id};";
            var command = new SQLiteCommand(queryString, connection);
            using(var reader = command.ExecuteReader()){
                while(reader.Read()){
                    task = GetTask(reader);
                }
            }
            connection.Close();
            return task;
        }
    }
}