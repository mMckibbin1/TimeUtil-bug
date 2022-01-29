using System.Diagnostics.CodeAnalysis;

namespace TimeUtil.Components.Shared
{
    internal static class ThrowHelpers
    {
        public static void ThrowIfRequiredPrameterNull<T>([NotNull]T? pramerter, string nameofPrameter)
        {
            if(pramerter is null)
            {
                throw new InvalidOperationException($"{nameofPrameter} of type {typeof(T).Name} can not be null");
            }
        }
    }
}
