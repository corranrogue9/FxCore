namespace System.Linq.V2
{
    public interface IMax14Enumerable : IV2Enumerable<float>
    {
        public float Max()
        {
            return this.MaxDefault();
        }
    }
}