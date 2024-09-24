# Socket RSA - Sistema de Socket com Criptografia RSA em C#

# 1. Introdução
Este projeto implementa um sistema de comunicação entre um servidor (Alice) e um cliente (Bob), utilizando sockets em C# para troca de mensagens. A segurança é garantida através da criptografia RSA, onde o servidor gera um par de chaves pública e privada. O cliente usa a chave pública para criptografar as mensagens enviadas ao servidor, que então as descriptografa utilizando sua chave privada.

# 2. Componentes Principais
O projeto é composto por três arquivos:

Program.cs: Controla o fluxo de execução do sistema, permitindo ao usuário escolher entre iniciar o servidor ou o cliente.
Server.cs: Implementa o servidor (Alice), que gera as chaves RSA, envia a chave pública ao cliente e recebe mensagens criptografadas.
Client.cs: Implementa o cliente (Bob), que se conecta ao servidor, recebe a chave pública, criptografa a mensagem e a envia.

# 3. Fluxo de Funcionamento
Servidor (Alice):
Gera um par de chaves RSA (pública e privada).
Escuta conexões de clientes.
Envia a chave pública para o cliente.
Recebe uma mensagem criptografada do cliente e a descriptografa usando a chave privada.
Cliente (Bob):
Conecta-se ao servidor.
Recebe a chave pública do servidor.
Solicita ao usuário que insira uma mensagem.
Criptografa a mensagem com a chave pública do servidor.
Envia a mensagem criptografada ao servidor.

# 4. Criptografia RSA
RSA (Rivest-Shamir-Adleman) é um algoritmo de criptografia assimétrica, o que significa que ele utiliza dois tipos de chave:
Chave pública: Usada para criptografar as mensagens.
Chave privada: Usada para descriptografar as mensagens.
No contexto deste projeto, o servidor (Alice) gera as chaves RSA. O cliente (Bob) usa a chave pública do servidor para criptografar a mensagem que deseja enviar. O servidor utiliza sua chave privada para descriptografar a mensagem recebida.

# 5. Estrutura de Arquivos
Program.cs
Este arquivo controla a execução do programa. Ele permite que o usuário escolha se quer iniciar o servidor ou o cliente.
