namespace System.Linq.V2
{
    public interface IMax23Enumerable : IV2Enumerable<decimal>
    {
        public decimal Max()
        {
            return this.MaxDefault();
        }
    }
}