namespace Fx.Linq.V2
{
    using System.Linq.V2;

    public static class EnumerableExtension
    {
        public static GarrettEnumerable<T> AddGarrett<T>(this IV2Enumerable<T> self)
        {
            return new GarrettEnumerable<T>(self);
        }
    }
}
