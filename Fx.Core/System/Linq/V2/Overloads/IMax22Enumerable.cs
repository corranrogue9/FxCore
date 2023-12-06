namespace System.Linq.V2
{
    public interface IMax22Enumerable : IV2Enumerable<double>
    {
        public double Max()
        {
            return this.MaxDefault();
        }
    }
}