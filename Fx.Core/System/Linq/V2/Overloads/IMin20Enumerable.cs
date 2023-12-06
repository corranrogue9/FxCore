namespace System.Linq.V2
{
    public interface IMin20Enumerable : IV2Enumerable<decimal?>
    {
        public decimal? Min()
        {
            return this.MinDefault();
        }
    }
}