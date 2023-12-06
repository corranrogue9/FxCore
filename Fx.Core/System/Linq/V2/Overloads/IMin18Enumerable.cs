namespace System.Linq.V2
{
    public interface IMin18Enumerable : IV2Enumerable<int?>
    {
        public int? Min()
        {
            return this.MinDefault();
        }
    }
}