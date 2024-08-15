using CommunityToolkit.Mvvm.ComponentModel;
using Simansoft.Mpesa.Core.Interfaces.Seguranca;
using Simansoft.Mpesa.Core.Models.Bases;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Simansoft.Mpesa.Core.Models.Seguranca
{
    public partial class ProvedorInicioSessaoModel(string chaveAPI, string chavePublica) : BaseSimplesModel, IProvedorInicioSessao
    {
        public ProvedorInicioSessaoModel() : this(string.Empty, string.Empty) { }


        [ObservableProperty] private string _chaveAPI = chaveAPI;
        [ObservableProperty] private string _chavePublica = chavePublica;

        public string IniciarSessao()
        {
            byte[] publicKeyBytes = Convert.FromBase64String(ChavePublica);
            RSACryptoServiceProvider rsa = new();
            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);

            byte[] encryptedApiKey = rsa.Encrypt(Encoding.UTF8.GetBytes(ChaveAPI), false);
            string token = Convert.ToBase64String(encryptedApiKey);


            //Sugestão a ser testada

            //using (RSACryptoServiceProvider rsa = new())
            //{
            //    rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
            //    byte[] encryptedApiKey = rsa.Encrypt(Encoding.UTF8.GetBytes(ApiKey), false);
            //    string token = Convert.ToBase64String(encryptedApiKey);
            //    return token;
            //}


            return token;
        }

        public void GerarApiKey(int length = 32)
        {
            byte[] apiKeyBytes = new byte[length];
            RandomNumberGenerator.Fill(apiKeyBytes);
            ChaveAPI = Convert.ToBase64String(apiKeyBytes);
        }

        public void GerarPublicKey(out string privateKey)
        {
            using RSA rsa = RSA.Create();

            var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();
            string chavePublicaTmp = Convert.ToBase64String(publicKeyBytes);

            var privateKeyBytes = rsa.ExportPkcs8PrivateKey();
            privateKey = Convert.ToBase64String(privateKeyBytes);

            ChavePublica = chavePublicaTmp;
        }
    }
}