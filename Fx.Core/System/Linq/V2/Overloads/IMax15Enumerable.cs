namespace System.Linq.V2
{
    public interface IMax15Enumerable : IV2Enumerable<float?>
    {
        public float? Max()
        {
            return this.MaxDefault();
        }
    }
}