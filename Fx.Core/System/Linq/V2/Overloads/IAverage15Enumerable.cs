namespace System.Linq.V2
{
    public interface IAverage15Enumerable : IV2Enumerable<decimal?>
    {
        public decimal? Average()
        {
            return this.AverageDefault();
        }
    }
}