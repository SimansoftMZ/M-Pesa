﻿using CommunityToolkit.Mvvm.ComponentModel;
using Simansoft.Mpesa.Core.Interfaces.Seguranca;
using Simansoft.Mpesa.Core.Models.Locais.Bases;
using System.Security.Cryptography;
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
            if (string.IsNullOrWhiteSpace(ChaveAPI) || string.IsNullOrWhiteSpace(ChavePublica)
                || !EStringBase64(ChaveAPI) || !EStringBase64(ChavePublica))
            {
                return string.Empty;
            }

            byte[] publicKeyBytes = Convert.FromBase64String(ChavePublica);

            using RSACryptoServiceProvider rsa = new();
            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
            byte[] encryptedApiKey = rsa.Encrypt(Encoding.UTF8.GetBytes(ChaveAPI), false);
            string token = Convert.ToBase64String(encryptedApiKey);

            return token;
        }

        public bool EStringBase64(string base64String)
        {
            Span<byte> buffer = new(new byte[base64String.Length]);
            return Convert.TryFromBase64String(base64String, buffer, out int _);
        }

        public void GerarApiKey(int tamanho = 32)
        {
            byte[] apiKeyBytes = new byte[tamanho];
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

        public void GerarStringAleatoria(int tamanho = 16)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:',.<>?";
            var random = new Random();
            var result = new StringBuilder(tamanho);

            for (int i = 0; i < tamanho; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            ChaveAPI = result.ToString();
        }
    }
}