using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DemosnapManager.Models.Snapshot
{
    public class DemoSnapshotRepository : IDemoSnapshotRepository
    {
        string connectionString = null;
        public DemoSnapshotRepository(string connStr)
        {
            connectionString = connStr;
        }
        public List<DemoSnapshotModel> GetDemoSnapshotModels()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<DemoSnapshotModel>("SELECT * FROM DemoSnapshots").ToList();
            }
        }

        public DemoSnapshotModel Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<DemoSnapshotModel>("SELECT * FROM DemoSnapshots WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(DemoSnapshotModel model)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO DemoSnapshots (Satellite, ShootingDate, Cloudiness, Coil, Coordinates) VALUES(@Satellite," +
                    " @ShootingDate, @Cloudiness, @Coil, @Coordinates)";
                db.Execute(sqlQuery, model);
            }
        }

        public void Update(DemoSnapshotModel model)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE DemoSnapshots SET Satellite = @Satellite, ShootingDate = @ShootingDate, Cloudiness = @Cloudiness, " +
                    "Coil = @Coil,  Coordinates = @Coordinates WHERE Id = @Id";
                db.Execute(sqlQuery, model);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM DemoSnapshots WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}

