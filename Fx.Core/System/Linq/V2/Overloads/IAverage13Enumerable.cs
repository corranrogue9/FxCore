namespace System.Linq.V2
{
    public interface IAverage13Enumerable : IV2Enumerable<int?>
    {
        public double? Average()
        {
            return this.AverageDefault();
        }
    }
}