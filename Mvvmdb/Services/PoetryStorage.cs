using Mvvmdb.Helpers;
using Mvvmdb.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mvvmdb.Services
{
    public class PoetryStorage : IPoetryStorage
    {


        public const int NumberPoetry = 30;

        public const string DbName = "poetrydb.sqlite3";

        public static readonly string PoetryDbPath = PathHelper.GetLocalFilePath(DbName);

        private SQLiteAsyncConnection _connection;
        private SQLiteAsyncConnection Connection => _connection ??= new SQLiteAsyncConnection(PoetryDbPath);

        private readonly IPreferenceStorage _preferenceStorage;

        public PoetryStorage(IPreferenceStorage preferenceStorage)
        {
            _preferenceStorage = preferenceStorage;
        }

        public bool IsInitialized => _preferenceStorage.Get(PoetryStorageConstant.VersionKey,
            default(int)) == PoetryStorageConstant.Version;

        public async Task InitializeAsync()
        {
            //await using var dbFileStream =
            //new FileStream(PoetryDbPath, FileMode.OpenOrCreate);
            ////await using var dbAssetStream =
            ////    typeof(PoetryStorage).Assembly.GetManifestResourceStream(DbName) ??
            ////    throw new Exception($"Manifest not found: {DbName}");
            //await using var dbAssetStream =
            //    typeof(PoetryStorage).Assembly.GetManifestResourceStream(DbName);
            //await dbAssetStream.CopyToAsync(dbFileStream);
            // 先检查目标文件是否已经存在，避免重复复制
            if (!File.Exists(PoetryDbPath))
            {
                // 获取嵌入资源流
                await using var dbAssetStream =
                    typeof(PoetryStorage).Assembly.GetManifestResourceStream(DbName);

                if (dbAssetStream == null)
                {
                    throw new FileNotFoundException($"嵌入资源 '{DbName}' 未找到。可用的资源: {string.Join(", ", typeof(PoetryStorage).Assembly.GetManifestResourceNames())}");
                }

                // 创建目标文件
                await using var dbFileStream = new FileStream(PoetryDbPath, FileMode.Create);
                await dbAssetStream.CopyToAsync(dbFileStream);
                Console.WriteLine("数据库文件复制完成");
            }
            else
            {
                Console.WriteLine("数据库文件已存在，跳过复制");
            }

            _preferenceStorage.Set(PoetryStorageConstant.VersionKey,
                PoetryStorageConstant.Version);

            await Connection.CloseAsync();
        }

        public async Task<Poetry> GetPoetryAsync(int id) => await Connection.Table<Poetry>().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IList<Poetry>> GetPoetriesAsync(
            Expression<Func<Poetry, bool>> where, int skip, int take)
            {
                var table = Connection.Table<Poetry>();
                return await Connection.Table<Poetry>().Where(where).Skip(skip).Take(take)
                .ToListAsync();
            }
        

        public async Task CloseAsync() => await Connection.CloseAsync();


    }

    public static class PoetryStorageConstant
    {
        public const string VersionKey =
            nameof(PoetryStorageConstant) + "." + nameof(Version);

        public const int Version = 1;
    }
}
