using Npgsql;

public class Program
{
    public static void Main(string[] args)
    {
        // Crear una cadena de conexión
        string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345678";

        // Conectarse a la base de datos
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            // Crear un comando SQL
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM users", connection);

            // Ejecutar el comando y obtener un lector de datos
            NpgsqlDataReader reader = command.ExecuteReader();

            // Leer los datos del lector
            while (reader.Read())
            {
                Console.WriteLine("{0} {1}", reader["id"], reader["name"]);
                Console.ReadLine();
            }

            // Cerrar el lector
            reader.Close();
        }
    }
}
