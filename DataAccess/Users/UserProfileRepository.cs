using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TestApp.Common;
using Newtonsoft.Json;
using System.IO;
using TestApp.DataSource;

namespace TestApp.Data
{
    public class UserProfileRepository : IUserProfileRepository
    {
        IFileStore _fileStore;
        public UserProfileRepository(IFileStore fileStore)
        {
            _fileStore = fileStore;
        }

        public async Task<string> GetRawUsers()
        {
            var content = await _fileStore.Read();
            return string.IsNullOrEmpty(content) ? string.Empty : content;
        }

        public async Task<IEnumerable<UserProfile>> GetUsers()
        {
            var content = await _fileStore.Read();
            if (content == null) return null;
            return JsonConvert.DeserializeObject<IEnumerable<UserProfile>>(content);
        }

        public async Task SaveUser(UserProfile user)
        {
            var existingUsers = await GetUsers();
            IList<UserProfile> users = (IList<UserProfile>) existingUsers ?? new List<UserProfile>();
            users.Add(user);
            await _fileStore.Write(JsonConvert.SerializeObject(users));
        }
    }
}