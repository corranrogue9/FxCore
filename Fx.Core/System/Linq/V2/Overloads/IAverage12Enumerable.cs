namespace System.Linq.V2
{
    public interface IAverage12Enumerable : IV2Enumerable<long?>
    {
        public double? Average()
        {
            return this.AverageDefault();
        }
    }
}