using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

class Server
{
    public static void Start()
    {
        // Gerar par de chaves RSA
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        string publicKey = rsa.ToXmlString(false); 
        string privateKey = rsa.ToXmlString(true); 

        // Criar socket do servidor
        TcpListener server = new TcpListener(IPAddress.Any, 5000);
        server.Start();
        Console.WriteLine("Servidor iniciado. Aguardando conexões...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();

            // Enviar a chave pública para o cliente
            byte[] publicKeyBytes = Encoding.UTF8.GetBytes(publicKey);
            stream.Write(publicKeyBytes, 0, publicKeyBytes.Length);
            Console.WriteLine("Chave pública enviada para o cliente.");

            // Receber mensagem criptografada do cliente
            byte[] buffer = new byte[256];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            byte[] encryptedMessage = new byte[bytesRead];
            Array.Copy(buffer, encryptedMessage, bytesRead);

            // Descriptografar a mensagem
            byte[] decryptedMessage = rsa.Decrypt(encryptedMessage, false);
            string message = Encoding.UTF8.GetString(decryptedMessage);
            Console.WriteLine("Mensagem recebida e descriptografada: " + message);

            // Fechar conexão
            client.Close();
        }
    }
}
