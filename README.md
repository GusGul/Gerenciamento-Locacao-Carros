# Sistema de Gerenciamento de Locação de Carros
## Passo a passo do dev

2. Criar Solution
3. Criar projeto Web (MVC)
5. Instalar os pacotes
   1. EF MySql
   2. EF Core
   3. EF Tools
6. Criar Modelos/Classes
   1. Modelo
   2. Carro
   3. Marca
   4. Cliente
   5. Pedido
   6. Configuracao
7. Criar o Db Contexto
8. Refatoramos Program.cs
   1. Aqui é criado StartUp
   2. Aqui é referenciada a string de conexao
   3. adiciona configurações `services.AddControllersWithViews();`
9. Instalar `dotnet tool install --global dotnet-ef` 
10. Criar as Migrations
11. Executa as Migration com update database
12.  Instalar o pacote EF Design
13.  Instalar pacote EF SqlServer
14.  Instalar `dotnet tool install -g dotnet-aspnet-codegenerator`
15.  Executar o Scafold para cada modelo
