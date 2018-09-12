using Core_Gestao_Frotas.Persistence.Models;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence
{
    public class BaseRepository
    {
        public static SQLiteAsyncConnection DBConnection;

        private Type[] _tables = new Type[] {
                typeof(ConfigurationPersistence),
                typeof(PermissionPersistence),
                typeof(ProfilePersistence),
                typeof(ProfilePermissionPersistence),
                typeof(UserPersistence),
                typeof(VehiclePersistence),
                typeof(BrandPersistence),
                typeof(ModelPersistence),
                typeof(TypologyPersistence),
                typeof(FuelPersistence),
                typeof(DamageVehiclePersistence),
                typeof(DamageVehicleDocumentPersistence),
                typeof(RequestHistoryPersistence),
                typeof(RequestJustificationPersistence),
                typeof(RequestJustificationTypePersistence),
                typeof(RequestPersistence),
                typeof(RequestStatePersistence),
                typeof(VehicleDeliveryPersistence),};

        public BaseRepository()
        {
            
        }

        public async Task<bool> Create(string dbPath, ISQLitePlatform platform)
        {
            DBConnection = SQLiteDatabase.GetConnection(dbPath, platform);

            var result = await DBConnection.CreateTablesAsync(_tables);

            return result != null;
        }

        public async Task<bool> Reset(string dbPath, ISQLitePlatform platform)
        {
            DBConnection = SQLiteDatabase.GetConnection(dbPath, platform);

            foreach (var table in _tables)
                await DBConnection.DropTableAsync(table);

            var result = await DBConnection.CreateTablesAsync(_tables);

            return result != null;
        }
    }

    public class SQLiteDatabase
    {
        public static SQLiteAsyncConnection GetConnection(string path, ISQLitePlatform sqlitePlatform)
        {
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(sqlitePlatform, new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));
            return new SQLiteAsyncConnection(connectionFactory);
        }
    }
}
