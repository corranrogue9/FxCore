namespace System.Linq.V2
{
    public interface IAverage20Enumerable : IV2Enumerable<float>
    {
        public float Average()
        {
            return this.AverageDefault();
        }
    }
}