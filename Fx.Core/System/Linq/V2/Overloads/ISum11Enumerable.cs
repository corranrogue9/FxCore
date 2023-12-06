namespace System.Linq.V2
{
    public interface ISum11Enumerable : IV2Enumerable<long?>
    {
        public long? Sum()
        {
            return this.SumDefault();
        }
    }
}