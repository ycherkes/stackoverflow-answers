namespace HotelApp
{
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }
        public RoomTypesModel GetRoomTypesDetailById(int roomTypeId)
        {
            RoomTypesModel model = new RoomTypesModel();

            model = _db.LoadData<RoomTypesModel>("[dbo].[spRoomTypeDetails_GetById]",
                                                         new { RoomTypeId = roomTypeId },
                                                         connectionStringName,
                                                         true).First();
            return model;
        }
    }

    public interface IDatabaseData
    {
        RoomTypesModel GetRoomTypesDetailById(int roomTypeId);
    }
}
