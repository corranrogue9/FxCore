namespace System.Linq.V2
{
    public interface ISum19Enumerable : IV2Enumerable<decimal>
    {
        public decimal Sum()
        {
            return this.SumDefault();
        }
    }
}