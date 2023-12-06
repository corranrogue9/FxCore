namespace System.Linq.V2
{
    public interface IAverage18Enumerable : IV2Enumerable<double>
    {
        public double Average()
        {
            return this.AverageDefault();
        }
    }
}