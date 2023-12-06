namespace System.Linq.V2
{
    public interface IMin22Enumerable : IV2Enumerable<long>
    {
        public long Min()
        {
            return this.MinDefault();
        }
    }
}