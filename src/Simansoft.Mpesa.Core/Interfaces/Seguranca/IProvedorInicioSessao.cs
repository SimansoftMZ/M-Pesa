namespace Simansoft.Mpesa.Core.Interfaces.Seguranca
{
    public interface IProvedorInicioSessao
    {
        public string ChaveAPI { get; set; }
        public string ChavePublica { get; set; }

        public string IniciarSessao();
        public bool EStringBase64(string base64String);
        public void GerarApiKey(int tamanho);
        public void GerarPublicKey(out string privateKey);
        public void GerarStringAleatoria(int tamanho);
    }
}