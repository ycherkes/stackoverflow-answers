namespace HotelApp
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T>(string sqlStatement, object parameter, string connectionStringName, bool isStoredProcedure = false);
    }
}