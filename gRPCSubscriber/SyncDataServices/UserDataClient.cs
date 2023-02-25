using Grpc.Net.Client;

namespace gRPCSubscriber.SyncDataServices
{
    public class UserDataClient
    {
        private readonly IConfiguration _configuration;

        public UserDataClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<GetUserListModel> GetUserList()
        {
            Console.WriteLine($"--> Calling GRPC Service {_configuration["GrpcPlatform"]}");
            var channel = GrpcChannel.ForAddress(_configuration["GrpcPlatform"]!);
            var client = new UserService.UserServiceClient(channel);
            var request = new GetUserListRequest();

            try
            {
                var response = client.GetUserList(request);

                var userList = new List<GetUserListModel>();
                foreach (var item in response.UserList)
                {
                    userList.Add(new()
                    {
                        BirthDate = item.BirthDate,
                        UserId = item.UserId,
                        Name = item.Name,
                        Surname = item.Surname
                    });
                }
                return userList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
