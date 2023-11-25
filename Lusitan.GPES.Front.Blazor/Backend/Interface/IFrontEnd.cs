namespace Lusitan.GPES.Front.Blazor.Backend.Interface
{
    public interface IFrontEnd
    {
        string Token { get; set; }

        public int NumUsuarioLogado { get; set; }
    }
}
