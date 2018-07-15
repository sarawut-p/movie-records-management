using MovieRecordsManagement.DAL.Domains;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecordsManagement.DAL.Repositories
{
    public class UserInMemoryRepository
    {
        static IRepository<User, Guid> InMemoryUserRepository;

        private UserInMemoryRepository()
        {

        }

        public static IRepository<User, Guid> getInstance()
        {
            if (InMemoryUserRepository == null)
            {
                InMemoryUserRepository = new InMemoryRepository<User, Guid>();
                InMemoryUserRepository.Add(new User() { UserName = "Alice", Role = User.ROLE_CONST.FLOOR_STAFF });
                InMemoryUserRepository.Add(new User() { UserName = "Bob", Role = User.ROLE_CONST.TEAM_LEADER });
                InMemoryUserRepository.Add(new User() { UserName = "Charie", Role = User.ROLE_CONST.MANAGER });
            }

            return InMemoryUserRepository;
        }
    }
}
