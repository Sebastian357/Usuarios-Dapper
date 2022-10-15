namespace Usuarios_Dapper
{
    public class ConexionDB
    {
        private string stringConnectionSql;
        public string stringConnectionDB { get => stringConnectionSql; }
        public ConexionDB(string stringConnection)
        {
           stringConnectionSql = stringConnection;
        }
    }
}
