# Gerenciador de Usu�rios API
API do gerenciador de usu�rios feita em .NET 6 e banco de dados MySQL.
� poss�vel cadastrar, editar, excluir e listar usu�rios.

## Como rodar o projeto
Clone o reposit�rio
```bash
git clone https://
```

Entre na pasta do projeto
```bash
cd users-manager/users-manager-api
```

Rode o docker-compose para subir o banco de dados MySQL
```bash
docker-compose up -d
```

Atualize o banco de dados com o Entity Framework
```bash
dotnet ef database update
```

Rode o projeto
```bash
dotnet run
```
