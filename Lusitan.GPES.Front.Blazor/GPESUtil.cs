namespace Lusitan.GPES.Front.Blazor
{
    public static class GPESUtil
    {
        public static string RemovePrimeiroEUltimo(string txt)
            => txt.Substring(1, txt.Length - 2);
    }
}
