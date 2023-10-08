namespace System.Linq.V2
{
    public interface IAverage11Enumerable : IV2Enumerable<float?>
    {
        float? Average(IV2Enumerable<float?> self);
    }
}