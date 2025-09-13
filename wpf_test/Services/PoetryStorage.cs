using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using wpf_test.Helpers;
using wpf_test.Models;

namespace wpf_test.Services
{
    public class PoetryStorage : IPoetryStorage
    {
        public const int NumberPoetry = 30;

        public const string DbName = "poetrydb.db3";

        public static readonly string PoetryDbPath = PathHelper.GetLocalFilePath(DbName);

        private SQLiteAsyncConnection _connection;
        private SQLiteAsyncConnection Connection => _connection ??= new SQLiteAsyncConnection(PoetryDbPath);

        public bool IsInitialized { get; }

        public async Task InitializeAsync()
        {
            await using var dbFileStream = new FileStream(PoetryDbPath, FileMode.OpenOrCreate);
            await using var dbAssetStream = typeof(PoetryStorage).Assembly.GetManifestResourceStream(DbName);
            await dbAssetStream.CopyToAsync(dbFileStream);

        }

        public Task<IList<Poetry>> GetPoetriesAsync(Expression<Func<Poetry, bool>> where, int skip, int take) => throw new NotImplementedException();
        public Task<Poetry> GetPoetryAsync(int id) => throw new NotImplementedException();

    }
}
