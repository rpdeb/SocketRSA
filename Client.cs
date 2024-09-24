using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

class Client
{
    public static void Start()
    {
        // Conectar ao servidor
        TcpClient client = new TcpClient("127.0.0.1", 5000);
        NetworkStream stream = client.GetStream();

        // Receber chave pública do servidor
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string publicKey = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Chave pública recebida do servidor.");

        // Criar instância RSA e importar a chave pública
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(publicKey);

        Console.Write("Digite a mensagem para Alice: ");
        string message = Console.ReadLine(); 

        // Criptografar 
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        byte[] encryptedMessage = rsa.Encrypt(messageBytes, false);

        stream.Write(encryptedMessage, 0, encryptedMessage.Length);
        Console.WriteLine("Mensagem criptografada enviada para o servidor.");

        client.Close();
    }
}
