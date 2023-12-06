namespace System.Linq.V2
{
    public interface IMax18Enumerable : IV2Enumerable<double?>
    {
        public double? Max()
        {
            return this.MaxDefault();
        }
    }
}