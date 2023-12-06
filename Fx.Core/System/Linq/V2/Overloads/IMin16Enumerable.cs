namespace System.Linq.V2
{
    public interface IMin16Enumerable : IV2Enumerable<float?>
    {
        public float? Min()
        {
            return this.MinDefault();
        }
    }
}