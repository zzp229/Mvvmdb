using Mvvmdb.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvmdb.Services
{
    public class PoetryStorage : IPoetryStorage
    {
        public const string DbName = "poetrydb.sqlite3";

        public static readonly string PoetryDbPath = Helpers.PathHelper.GetLocalFilePath(DbName);

        private SQLiteAsyncConnection _connection;
        private SQLiteAsyncConnection  Connection => _connection ??= new SQLiteAsyncConnection(PoetryDbPath);

        /// <summary>
        /// 数据库建表
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            await Connection.CreateTableAsync<Poetry>();
        }

        public async Task InserAsync(Poetry poetry)
        {
            
        }
    }
}
