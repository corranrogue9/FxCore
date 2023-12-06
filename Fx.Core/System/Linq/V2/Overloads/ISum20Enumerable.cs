namespace System.Linq.V2
{
    public interface ISum20Enumerable : IV2Enumerable<float>
    {
        public float Sum()
        {
            return this.SumDefault();
        }
    }
}