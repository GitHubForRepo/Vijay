using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DataSource
{
    public interface IFileStore
    {
        Task<string> Read();

        Task Write(string data);

    }
}
