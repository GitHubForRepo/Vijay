using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Data
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetUsers();
        Task SaveUser(UserProfile user);

        Task<string> GetRawUsers();
    }
}
