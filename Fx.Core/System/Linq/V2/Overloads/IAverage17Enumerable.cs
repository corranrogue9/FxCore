namespace System.Linq.V2
{
    public interface IAverage17Enumerable : IV2Enumerable<int>
    {
        public double Average()
        {
            return this.AverageDefault();
        }
    }
}