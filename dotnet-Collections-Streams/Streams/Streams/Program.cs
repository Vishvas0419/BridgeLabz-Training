namespace Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "D:\\BridgeLabz-Training\\dotnet-Collections-Streams\\Streams\\Streams\\source.txt";
            string destinationFile = "D:\\BridgeLabz-Training\\dotnet-Collections-Streams\\Streams\\Streams\\destination.txt";


            //using (FileStream source = new FileStream( sourceFile(path), FileMode.Open(Mode), FileAccess.Read(Access)) ;
            using (FileStream source = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))

            using (FileStream destination = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
            {
                int data;

                //source is Filestream and Readbyte() is a method in Filestream which reads and return the data in the form of int
                //source.ReadByte() reads one byte from the file source.txt and returns data in integer form
                //the value in data is ascii value of char 
                while ((data = source.ReadByte()) != -1)
                {
                    destination.WriteByte((byte)data);
                }
            }

            Console.WriteLine("File Copied Successfully !");
        }
    }
}
