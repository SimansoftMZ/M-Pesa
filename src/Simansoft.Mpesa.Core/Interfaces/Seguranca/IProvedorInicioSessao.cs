namespace Simansoft.Mpesa.Core.Interfaces.Seguranca
{
    public interface IProvedorInicioSessao
    {
        public string ChaveAPI { get; set; }
        public string ChavePublica { get; set; }

        public void GerarApiKey(int length);
        public void GerarPublicKey(out string privateKey);
        public string IniciarSessao();
    }
}
