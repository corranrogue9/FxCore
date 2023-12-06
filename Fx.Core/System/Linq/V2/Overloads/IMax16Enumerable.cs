namespace System.Linq.V2
{
    public interface IMax16Enumerable : IV2Enumerable<long?>
    {
        public long? Max()
        {
            return this.MaxDefault();
        }
    }
}