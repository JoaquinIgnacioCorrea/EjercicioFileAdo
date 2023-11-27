using Clase6.Domain;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace Clase6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string path = @"C:\Users\aleja\Desktop\Curso NET CDA\prueba.txt";
            //string message = "\n segunda linea";
            //File.AppendAllText(path, message);
            //string path = @"C:\Users\aleja\Desktop\Curso NET CDA\prueba.txt";


            //string path = @"C:\Users\aleja\Desktop\Curso NET CDA\data.txt";

            //string[] data = File.ReadAllLines(path);

            //var lstUsuarios = new List<UsuariosDTO>();

            //foreach (string line in data) 
            //{
            //    var newData = line.Split(";");

            //    var newUsuario = new UsuariosDTO() 
            //    {
            //       Codigo = newData[0].ToUpper().Trim(),
            //       Nombre = newData[1].ToLower().Trim(),
            //       Apellido = newData[2].ToLower().Trim(),
            //    };
            //    lstUsuarios.Add(newUsuario);
            //}

            string connectionString = @"Data Source=localhost\SQL2022;Initial Catalog=Pruebas;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);

            //...
            #region Consulta de datos
            //connection.Open();
            //SqlCommand command = connection.CreateCommand();

            //command.CommandType = System.Data.CommandType.Text;
            //command.CommandText = @"select *  from Usuario";


            //SqlDataReader reader = command.ExecuteReader();
            //var lstUsuarios = new List<UsuariosDTO>();
            //while (reader.Read()) 
            //{
            //    var id = int.Parse( reader["id"].ToString()!  ); 
            //    var nombre = reader["nombre"].ToString()!;
            //    var apellido = reader["apellido"].ToString()!;

            //    var newUsuario = new UsuariosDTO()
            //    {
            //        Codigo = id,
            //        Nombre = nombre,
            //        Apellido = apellido
            //    };
            //    lstUsuarios.Add(newUsuario);
            //}

            //connection.Close();


            //foreach ( var user in lstUsuarios ) 
            //{
            //    Console.WriteLine(JsonSerializer.Serialize(user));
            //}
            #endregion

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();

            string nombre = "Joaquin";
            string apellido = "Correa') truncate table usuario --";
            //cmd.CommandText = $"insert into Usuario(nombre,apellido) values('{nombre}','{apellido}')";

            
            SqlParameter parametroNombre = new SqlParameter() 
            {
                ParameterName = "nombre",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = nombre

            };
            SqlParameter parametroApellido = new SqlParameter()
            {
                ParameterName = "apellido",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = apellido

            };

            cmd.CommandText = $"insert into Usuario(nombre,apellido) values(@nombre,@apellido)";
            cmd.Parameters.Add(parametroNombre);
            cmd.Parameters.Add(parametroApellido);
          
            int rows =  cmd.ExecuteNonQuery();
            if(rows > 0) Console.WriteLine("Se agrego correctamente...");

            connection.Close();

        }
    }
}