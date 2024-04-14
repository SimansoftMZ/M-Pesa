using CommunityToolkit.Mvvm.ComponentModel;
using Simansoft.Mpesa.Core.Interfaces.Seguranca;
using Simansoft.Mpesa.Core.Models.Bases;
using System.Security.Cryptography;
using System.Text;

namespace Simansoft.Mpesa.Core.Models.Seguranca
{
    public partial class ProvedorInicioSessaoModel(string apiKey, string publicKey) : BaseSimplesModel, IProvedorInicioSessao
    {
        [ObservableProperty] private string _apiKey = apiKey;
        [ObservableProperty] private string _publicKey = publicKey;

        public string IniciarSessao()
        {
            byte[] publicKeyBytes = Convert.FromBase64String(PublicKey);
            RSACryptoServiceProvider rsa = new();
            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);

            byte[] encryptedApiKey = rsa.Encrypt(Encoding.UTF8.GetBytes(ApiKey), false);
            string token = Convert.ToBase64String(encryptedApiKey);

            return token;
        }
    }
}