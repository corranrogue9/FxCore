namespace System.Linq.V2
{
    public interface IAverage19Enumerable : IV2Enumerable<decimal>
    {
        public decimal Average()
        {
            return this.AverageDefault();
        }
    }
}