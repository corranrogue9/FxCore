namespace System.Linq.V2
{
    public interface ISum17Enumerable : IV2Enumerable<int>
    {
        public int Sum()
        {
            return this.SumDefault();
        }
    }
}