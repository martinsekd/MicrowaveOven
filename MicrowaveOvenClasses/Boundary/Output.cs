using MicrowaveOvenClasses.Interfaces;

namespace MicrowaveOvenClasses.Boundary
{
    public class Output : IOutput
    {
        public string OutPutText { get; protected set; }
        public void OutputLine(string line)
        {
            System.Console.WriteLine(line);
            OutPutText = line;
        }
        
    }
}