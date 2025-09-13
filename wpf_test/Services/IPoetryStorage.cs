using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_test.Models;

namespace wpf_test.Services
{
    public interface IPoetryStorage
    {
        Task InitializeAsync();
        Task InserAsync(Poetry poetry);
        Task<List<Poetry>> ListAsync();

        Task<List<Poetry>> QueryAsync(string keyword);
    }
}
