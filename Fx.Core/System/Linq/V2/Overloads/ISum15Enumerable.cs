namespace System.Linq.V2
{
    public interface ISum15Enumerable : IV2Enumerable<decimal?>
    {
        public decimal? Sum()
        {
            return this.SumDefault();
        }
    }
}