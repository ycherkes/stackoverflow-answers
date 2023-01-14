using Autofac.Extras.Moq;
using HotelApp;
using Moq;

namespace HotelAppTests
{
    public class SqlDataTests : MockData
    {
        private static DateTime pStartDate = DateTime.Now;
        private DateTime pEndDate = pStartDate.AddDays(1);

        private const string connectionStringName = "SqlDb";

        [Fact]
        public void GetRoomTypesDetailById_ShouldReturnRoomDetails()
        {
            var roomTypeId = 2;
            var returnedRoom = GetRoomTypesDetailById(1).First();
            var sqlStatment = "[dbo].[spRoomTypeDetails_GetById]";
            List<RoomTypesModel> roomList = new List<RoomTypesModel>
            {
                returnedRoom
            };

            using (var mock = AutoMock.GetLoose())
            {
                object parameter = null;

                mock.Mock<ISqlDataAccess>()
                    .Setup(x => x.LoadData<RoomTypesModel>(sqlStatment, It.IsAny<object>(), connectionStringName, true))
                    .Callback<string, object, string, bool>((_, param1, _, _) => parameter = param1)
                    .Returns(roomList);

                var _dbMock = mock.Create<SqlData>();

                // Arrange 
                var expected = returnedRoom;

                //Act 
                var actual = _dbMock.GetRoomTypesDetailById(roomTypeId);

                // Assert
                Assert.Equivalent(new { RoomTypeId = roomTypeId }, parameter);
                Assert.NotNull(actual);
                Assert.Equal(actual, expected);
            }
        }
    }
}