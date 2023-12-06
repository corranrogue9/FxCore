namespace System.Linq.V2
{
    public interface IMin23Enumerable : IV2Enumerable<int>
    {
        public int Min()
        {
            return this.MinDefault();
        }
    }
}