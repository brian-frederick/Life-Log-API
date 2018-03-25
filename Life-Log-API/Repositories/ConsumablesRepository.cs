using Life_Log_API.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Life_Log_API.Repositories
{
    public class ConsumablesRepository : IConsumablesRepository
    {
        private readonly List<Consumable> _consumables;
        public static IConfiguration Configuration { get; set; }


        public ConsumablesRepository(IEnumerable<Consumable> consumables)
        {
            if (consumables == null)
            {
                throw new ArgumentNullException(nameof(consumables));
            }
            _consumables = new List<Consumable>(consumables);
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

        }

        public IEnumerable<Consumable> Get()
        { 
            return _consumables;
        }

        public Consumable Post(Consumable consumableToAdd)
        {
            SqlConnection myConnection = new SqlConnection();
            SqlDataReader reader = null;
            var addedConsumable = new Consumable();
            myConnection.ConnectionString = Configuration.GetConnectionString("lifeLogDatabase");
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = myConnection;

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO CONSUMABLES (NAME, CREATEDAT, QUANTITY, UNIT, IMMEDIATERATING, POSTRATING) " +
                "Values (@NAME, @CREATEDAT, @QUANTITY, @UNIT, @IMMEDIATERATING, @POSTRATING);" + 
                "SELECT * FROM CONSUMABLES WHERE ID = SCOPE_IDENTITY()";
            
            sqlCmd.Parameters.AddWithValue("@NAME", consumableToAdd.Name);
            sqlCmd.Parameters.AddWithValue("@CREATEDAT", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@QUANTITY", consumableToAdd.Quantity);
            sqlCmd.Parameters.AddWithValue("@UNIT", consumableToAdd.Unit);
            sqlCmd.Parameters.AddWithValue("@IMMEDIATERATING", consumableToAdd.ImmediateRating);
            sqlCmd.Parameters.AddWithValue("@POSTRATING", consumableToAdd.PostRating);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                addedConsumable.Id = Convert.ToInt16(reader["ID"]);
                addedConsumable.Name = Convert.ToString(reader["NAME"]);
                addedConsumable.CreatedAt = Convert.ToDateTime(reader["CREATEDAT"]);
                addedConsumable.Quantity = Convert.ToInt16(reader["QUANTITY"]);
                addedConsumable.Unit = Convert.ToString(reader["UNIT"]);
                addedConsumable.ImmediateRating = Convert.ToInt16(reader["IMMEDIATERATING"]);
                addedConsumable.PostRating = Convert.ToInt16(reader["POSTRATING"]);
            }

            myConnection.Close();

            return addedConsumable;
        }
    }
}
