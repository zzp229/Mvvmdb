using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using wpf_test.Models;

namespace wpf_test.Services
{
    public interface IPoetryStorage
    {
        bool IsInitialized { get; }

        Task InitializeAsync();

        Task<Poetry> GetPoetryAsync(int id);

        // 待深入
        Task<IList<Poetry>> GetPoetriesAsync(
            Expression<Func<Poetry, bool>> where, int skip, int take);
    }
}
