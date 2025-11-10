using practice1.Repository.Interface;
using practice1.Models;
using Microsoft.Data.SqlClient;

namespace practice1.Repository.Implementation
{
    public class StudentRepo : IStudentInterface
    {
        private readonly SqlConnection _conn;

        public StudentRepo(SqlConnection conn) 
        {
            _conn = conn;
        }

        public async Task<int> AddStudentRepo(Student data)
        {
            try
            {
                string query = "INSERT INTO Students(Name,Age,City) VALUES (@Name,@Age,@city)";

                await _conn.OpenAsync();
                int result = -1;

                using(var cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("Name",data.Name);
                    cmd.Parameters.AddWithValue("Age", data.Age);
                    cmd.Parameters.AddWithValue("City", data.City);

                    result = await cmd.ExecuteNonQueryAsync();
                }
                await _conn.CloseAsync();
                return result;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in AddStudent: {ex.Message}");
                await _conn.CloseAsync();
                return 0;
            }

        }

        public async Task<List<Student>> GetAllStudentRepo()
        {
            try
            {
                string query = "SELECt * FROM Students";

                await _conn.OpenAsync();
                List<Student> result = new List<Student>();

                using (var cmd = new SqlCommand(query, _conn))
                {
                    var reader = await cmd.ExecuteReaderAsync();

                    while(await  reader.ReadAsync())
                    {
                        var student = new Student
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Age = Convert.ToInt32(reader["Age"]),
                            Name = reader["Name"].ToString(),
                            City = reader["City"].ToString()
                        };
                        result.Add(student);

                    }

                }
                await _conn.CloseAsync();
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddStudent: {ex.Message}");
                await _conn.CloseAsync();
                return null;
            }

        }

        public async Task<List<Student>> GetStateData()
        {
            try
            {
                string query = "SELECt StateId As Value,StateName As Text FROM StateMaster";

                await _conn.OpenAsync();
                List<Student> result = new List<Student>();

                using (var cmd = new SqlCommand(query, _conn))
                {
                    var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        var student = new Student
                        {
                            Value = Convert.ToInt32(reader["Value"]),                            
                            Text = reader["Text"].ToString()
                        };
                        result.Add(student);

                    }

                }
                await _conn.CloseAsync();
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddStudent: {ex.Message}");
                await _conn.CloseAsync();
                return null;
            }

        }
        public async Task<List<Student>> GetCityData(int StateID)
        {
            var result = new List<Student>();

            try
            {
                string query = "SELECT CityId AS Value, CityName AS Text FROM CityMaster WHERE StateId = @StateID";

                using (var conn = _conn)
                {
                    await conn.OpenAsync();

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StateID", StateID);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var student = new Student
                                {
                                    Value = Convert.ToInt32(reader["Value"]),
                                    Text = reader["Text"].ToString()
                                };

                                result.Add(student);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCityData: {ex.Message}");
                return null;
            }

            return result;
        }
    }
}
