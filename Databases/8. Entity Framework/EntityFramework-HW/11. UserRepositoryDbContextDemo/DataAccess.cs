using System.Linq;
using System.Transactions;

using NorthwindModels;

internal static class DataAccess
{
    private static UserRepositoryEntities userRepository;

    public static void Initialize(UserRepositoryEntities userRepositoryContext)
    {
        userRepository = userRepositoryContext;
    }

    public static void InsertNewUser(
        string groupName,
        string username,
        string password,
        string userFirstName,
        string userLastName)
    {
        using (var scope = new TransactionScope())
        {
            var group = userRepository.Groups
                .FirstOrDefault(g => g.GroupName == groupName);

            if (group == null)
            {
                // the group doesn't exist, create it
                group = new Group()
                {
                    GroupName = groupName
                };

                userRepository.Groups.Add(group);
                userRepository.SaveChanges();
            }

            var newUser = new User()
            {
                GroupId = group.GroupId,
                Username = username,
                Password = password,
                UserFirstName = userFirstName,
                UserLastName = userLastName
            };

            userRepository.Users.Add(newUser);

            userRepository.SaveChanges();

            scope.Complete();
        }
    }
}
