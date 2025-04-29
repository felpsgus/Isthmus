# Isthmus Api

## Estrutura do projeto

A estrutura do projeto é organizada em camadas, seguindo o padrão clean architecture. Limitei o acesso a dados através
do padrão repository contribuindo para o desacoplamento em relação ao banco de dados. Implementei o padrão DDD (Domain
Driven Design) para enriquecer minhas classes de domínio e garantir que a lógica de negócio esteja separada da
infraestrutura. Além disso, decidi usar uma classe de serviço para encapsular os casos de uso, levando em consideração o tamanho da aplicação e a complexidade do domínio. A estrutura do projeto é a seguinte:

- **[`Isthmus.Api`](Isthmus.Api)**: Contém a API da aplicação, incluindo controladores e configuração do Swagger.
- **[`Isthmus.Application`](Isthmus.Application)**: Contém a lógica de negócios da aplicação, incluindo serviços e
  interfaces.
- **[`Isthmus.Domain`](Isthmus.Domain)**: Contém as entidades de domínio e regras de negócio.
- **[`Isthmus.Infrastructure`](Isthmus.Infrastructure)**: Contém a implementação de acesso a dados, incluindo o contexto
  do banco de dados e repositórios.

## Entidade e regras de negócio

A entidade `Produto` possui os campos: `Id`, `Codigo`, `Nome`, `Descricao`, `Preco`, `Ativo`. As regras implementadas
incluem:

- Exclusão lógica (`Ativo = false`)
- Validação de duplicidade pelo campo `Codigo` (atualiza se já existir)
- Pesquisa por `Codigo` ou `Nome` com `contains`

## Tecnologias utilizadas

- **.NET 8**: A plataforma de desenvolvimento utilizada para construir a API.
- **Entity Framework Core**: A biblioteca de acesso a dados utilizada para interagir com o banco de dados.
- **Docker**: Utilizado para containerizar a aplicação e o banco de dados.
- **Swagger**: Utilizado para documentar e testar a API.
- **FluentValidation**: Utilizado para validação de dados.

## Docker

A aplicação está containerizada e pode ser executada em um ambiente Docker. O `compose.yml` inclui os serviços:

- **SqlServer**: O banco de dados utilizado pela aplicação, que expõe a porta 1433.
- **Isthmus.Api**: O serviço da API, que expõe a porta 8080.

### Docker Hub

A imagem da aplicação está disponível em:  
[https://hub.docker.com/repository/docker/felpsgus/isthmus.api](https://hub.docker.com/repository/docker/felpsgus/isthmus.api)

## Instruções para rodar o projeto

### Pré-requisitos

- [Docker Desktop](https://www.docker.com/get-started) instalado e em execução
- [Git](https://git-scm.com/downloads) instalado
- [Sdk .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0) instalado (opcional, para desenvolvimento)

```bash
# Clonar o repositório
git clone https://github.com/felpsgus/Isthmus.git
cd Isthmus

# Subir os containers
docker compose up -d

# Aplicar as migrations
docker compose exec isthmus.api dotnet ef database update --project /src/Isthmus.Infrastructure/Isthmus.Infrastructure.csproj --startup-project /src/Isthmus.Api/Isthmus.Api.csproj --context Isthmus.Infrastructure.Persistence.IsthmusDbContext
```

**Acesse a API**: Você pode acessar a API em
`http://localhost:8080/api/swagger/index.html`.

## Possíveis melhorias
- Implementar testes unitários e de integração
- Dependendo da necessidade do negócio, considerar a implementação do padrão Mediator para reduzir as dependências entre os serviços e melhorar a organização do código.
- Abstrair algumas propriedades comuns entre os domínios em uma classe base, como `Ativo`, para evitar duplicação de código.
- Implementar o padrão UnitOfWork para gerenciar transações de forma mais eficiente.