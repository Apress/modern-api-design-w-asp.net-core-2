namespace AwesomeService
{
    public interface ICalculator
    {
        int Add(int nr1, int nr2, int nr3);
    }
    public class AwesomeCalculator : ICalculator
    {
        public int Add(int nr1, int nr2, int nr3)
        {
            return nr1 + nr2 + nr3;
        }
    }
}