
# CRUD de Produtos em .Net 8

Esse projeto é um CRUD de produtos com integração ao SQL Server rodando em Docker e Azure Data Studio.
Ele já possui um banco de dados (conta fictícia) integrado, mas você pode conectar seu próprio banco através do arquivo ```appsettings.Development.json```


## Instalação

Clone o projeto

`git clone git@github.com:jskadomoto/crud-products-dotnet.git`

ou
    
`git clone https://github.com/jskadomoto/crud-products-dotnet.git`
## Rodando localmente

**Rode o build**
```bash
   dotnet build
```

**Inicie o servidor**
```bash
   dotnet watch run
```



## Conexão com o Banco de Dados

Para conectar seu próprio banco, altere: 

`appsettings.Development.json`

```
{
  "Database": {
    "SqlServer": "Server={server};Database={database};User Id={userId};Password=${password};MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES"
  },
}
```


#### Retorna uma lista de produtos
```http
  GET /products?page=${page}&limit={limit}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `page`      | `int` | Página a ser retornada //padrão = 1 |
| `limit`      | `int` | Quantidade de produtos por página // padrão = 10 |

#### Retorna produto por id
```http
  GET /products?id=${id}
  GET /products/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | Id do produto |


#### Cria um produto
```http
  POST /products
  {
    "Code": "1",
    "Name": "Nome do produto",
    "Description": "Descrição do produto",
    "CategoryId": 1,
    "tags": ["Celular", "Tecnologia"]
}

```
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Code`      | `int` | Código do produto |
| `Name`      | `string` | Nome do produto |
| `Description`      | `string` | Descrição do produto |
| `CategoryId`      | `int` | Código da categoria do produto //**Criar categoria** |
| `tags`      | `string[]` | Tágs do produto |

#### Atualiza um produto por id
```http
  PUT /products?id=${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | Id do produto |


#### Deleta um produto por id
```http
  DELETE /products?id=${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | Id do produto |


## Atualizando o Banco de Dados

Nesse exemplo utilizei o Azure Data Studio para conectar o meu Banco de Dados SQL Server.
Esses são os comandos para criar uma nova migration e atualizar o banco de dados:

- Migration
```bash
  dotnet ef migrations NomeDaMigration
```

- Atualização do Banco de Dados

```
dotnet ef database update
```


## Stack utilizada
 - .NET 8
 - Azure Data Studio
 - Docker
 - SQL Server


## Referência

 - [.NET 6 WEB API - Do zero ao avançado](https://www.udemy.com/course/net-6-web-api-do-zero-ao-avancado/)

## Autor

[Jones Kadomoto](https://www.linkedin.com/in/jones-seiji-kadomoto-bezerra-165864180/)

