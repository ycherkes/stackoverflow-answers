namespace HotelApp
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameter, string connectionStringName, bool isStoredProcedure = false);
    }
}