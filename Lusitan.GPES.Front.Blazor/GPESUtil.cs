using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Front.Blazor
{
    [ExcludeFromCodeCoverage]
    public static class GPESUtil
    {
        public static string RemovePrimeiroEUltimo(string txt)
            => txt.Substring(1, txt.Length - 2);
    }
}
