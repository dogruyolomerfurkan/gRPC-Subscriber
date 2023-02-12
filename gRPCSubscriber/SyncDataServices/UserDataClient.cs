using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Mapster;
using System.Collections.Generic;

namespace gRPCSubscriber.SyncDataServices
{
    public class UserDataClient
    {
        public List<GetUserListModel> GetUserList()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:7500");
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
