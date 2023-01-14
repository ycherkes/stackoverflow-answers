using HotelApp;

namespace HotelAppTests
{
    public class MockData
    {
        public List<RoomTypesModel> GetRoomTypesDetailById(int roomId)
        {
            List<RoomTypesModel> RoomDetails = new()
            {
                new RoomTypesModel { Id = 1, Title = "King Size Bed", Description = "A room with a king size bed and a window view.", Price = 100 },
                new RoomTypesModel { Id = 2, Title = "Two Queen Size Ben", Description = "A room with two queen size bed", Price = 115 },
                new RoomTypesModel { Id = 3, Title = "Execlusive Suite", Description = "Two room, each with one king size bed and a window view", Price = 205 }
            };

            return RoomDetails.Where(room => room.Id == roomId).ToList();
        }
    }
}
