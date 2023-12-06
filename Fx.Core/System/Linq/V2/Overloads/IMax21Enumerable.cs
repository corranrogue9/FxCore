namespace System.Linq.V2
{
    public interface IMax21Enumerable : IV2Enumerable<int>
    {
        public int Max()
        {
            return this.MaxDefault();
        }
    }
}