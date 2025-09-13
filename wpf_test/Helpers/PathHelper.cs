using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_test.Helpers
{
    public class PathHelper
    {
        private static string _localFolder = string.Empty;
        private static string LocalFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(_localFolder))
                {
                    return _localFolder;
                }
                _localFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nameof(wpf_test));
                if (!System.IO.Directory.Exists(_localFolder))
                {
                    System.IO.Directory.CreateDirectory(_localFolder);
                }                
                return _localFolder;
            }
        }
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(LocalFolder, filename);
        }
    }
}
