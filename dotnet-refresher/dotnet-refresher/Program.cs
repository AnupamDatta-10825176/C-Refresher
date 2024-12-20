using dotnet_refresher.Utilities;
using dotnet_refresher.Utilities.Interfaces;


namespace dotnet_refresher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUtilities utilitiy = new Utilitiy();

            // Get all data from the table
            //utilitiy.WorkWithTblData();

            // Get person by id
            utilitiy.WorkWithStoredProcs();
        }
    }
}
