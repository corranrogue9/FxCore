namespace System.Linq.V2
{
    public interface ISum13Enumerable : IV2Enumerable<int?>
    {
        public int? Sum()
        {
            return this.SumDefault();
        }
    }
}