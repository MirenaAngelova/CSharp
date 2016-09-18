using System.IO;
using Air_Conditioner_Testing_System.Interfaces;

namespace Air_Conditioner_Testing_System.UI
{
    public class FileUserInterface : IUserInterface
    {
        public FileUserInterface(string input, string output)
        {
            this.Reader = new StreamReader(File.Open(input, FileMode.Open));
            this.Writer = new StreamWriter(File.Create(output));
        }

        public StreamWriter Writer { get; }

        public StreamReader Reader { get; }

        public string ReadLine()
        {
            return this.Reader.ReadLine();
        }

        public void WriteLine(string message)
        {
            this.Writer.WriteLine(message);
        }
    }
}