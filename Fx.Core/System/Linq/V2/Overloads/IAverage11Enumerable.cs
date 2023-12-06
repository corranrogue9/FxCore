namespace System.Linq.V2
{
    public interface IAverage11Enumerable : IV2Enumerable<float?>
    {
        public float? Average(IV2Enumerable<float?> self)
        {
            return this.AverageDefault();
        }
    }
}