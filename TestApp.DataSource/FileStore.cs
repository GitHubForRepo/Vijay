using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TestApp.DataSource
{
    public class FileStore : IFileStore
    {

        private string _path = string.Empty;
        public FileStore()
        {
            _path = Path.Combine(Directory.GetCurrentDirectory(), DataSourceRegistry._filePath);
        }

        public async Task<string> Read()
        {
            
            if (!IsFileExist(_path)) return null;
            return await File.ReadAllTextAsync(_path);
        }

        public async Task Write(string data)
        {
            await File.WriteAllTextAsync(_path, data);
        }

        public bool IsFileExist(string _path)
        {
            if (File.Exists(_path))
                return true;
            return false;
        }

        public void CreateFile()
        {
            using (File.Create(_path)) ;
        }
    }
}
