namespace System.Linq.V2
{
    public interface ISum18Enumerable : IV2Enumerable<double>
    {
        public double Sum()
        {
            return this.SumDefault();
        }
    }
}