namespace System.Linq.V2
{
    public interface ISum12Enumerable : IV2Enumerable<float?>
    {
        public float? Sum()
        {
            return this.SumDefault();
        }
    }
}