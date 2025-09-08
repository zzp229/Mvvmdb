using Mvvmdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvmdb.Services
{
    public interface IPoetryStorage
    {
        Task InitializeAsync();
        Task InserAsync(Poetry poetry);
    }
}
