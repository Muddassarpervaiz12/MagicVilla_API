namespace MagicVillaAPI.Logging
{
    public class Logging : ILogging
    {
        //implementation of method
        public void Log(string message, string type)
        {
            if(type == "error")
            {
                Console.WriteLine("Error -" + message);
            }
            else if ( type == "info")
            {
                Console.WriteLine("Info -" + message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
