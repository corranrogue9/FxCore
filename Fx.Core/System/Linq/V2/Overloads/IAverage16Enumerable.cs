namespace System.Linq.V2
{
    public interface IAverage16Enumerable : IV2Enumerable<long>
    {
        public double Average()
        {
            return this.AverageDefault();
        }
    }
}