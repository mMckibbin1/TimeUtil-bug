using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace TimeUtil.Components.Shared
{
    internal static class ThrowHelpers
    {
        public static void ThrowIfRequiredPrameterNull<T>([NotNull]T? pramerter, [CallerArgumentExpression("pramerter")] string? nameofPrameter = null)
        {
            if(pramerter is null)
            {
                throw new InvalidOperationException($"{nameofPrameter} of type {typeof(T).Name} can not be null");
            }
        }

        public static void ThrowIfRequiredCascadingPrameterNull<T>([NotNull] T? pramerter)
        {
            if (pramerter is null)
            {
                throw new InvalidOperationException($"Required Cascading prameter of type {typeof(T).Name} must be provided");
            }
        }

    }
}
