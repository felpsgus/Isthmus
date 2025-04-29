# Isthmus.Api

## Instruções para rodar o projeto

1. **Instalação do Docker**: Certifique-se de que o Docker está instalado e em execução na sua máquina. Você pode baixar
   o Docker [aqui](https://www.docker.com/get-started).
2. **Clone o repositório**: Use o comando `git clone` para clonar o repositório em sua máquina local.
3. **Navegue até o diretório do projeto**: Use o terminal para navegar até o diretório onde você clonou o repositório.
4. **Rode o comando**: Execute o seguinte comando para iniciar o banco de dados, a Api e aplicar as migrations:
   ```bash
   docker compose up -d && 
   docker compose exec isthmus.api dotnet ef database update --project /src/Isthmus.Infrastructure/Isthmus.Infrastructure.csproj --startup-project /src/Isthmus.Api/Isthmus.Api.csproj --context Isthmus.Infrastructure.Persistence.IsthmusDbContext
   ```
5. **Acesse a API**: Após o comando ser executado com sucesso, você pode acessar a API em
   `http://localhost:8080/api/swagger/index.html`.

## Estrutura do projeto

A estrutura do projeto é organizada em camadas, seguindo o padrão clean architecture. Limitei o acesso a dados atravéz
do padrão repository contribuindo para o desacoplamento em relação ao banco de dados. Implementei o padrão DDD (Domain
Driven Design) para enriquecer minhas classes de domínio e garantir que a lógica de negócios esteja separada da
infraestrutura. A estrutura do projeto é a seguinte:

- **Isthmus.Api**: Esta camada contém os controladores da API e a configuração do Swagger.
- **Isthmus.Application**: Esta camada contém a lógica de negócios e os serviços da aplicação.
- **Isthmus.Domain**: Esta camada contém as entidades e os objetos de valor do domínio.
- **Isthmus.Infrastructure**: Esta camada contém a implementação de acesso a dados, incluindo o contexto do Entity
  Framework e as configurações de banco de dados.

## Tecnologias utilizadas

- **.NET 8**: A plataforma de desenvolvimento utilizada para construir a API.
- **Entity Framework Core**: A biblioteca de acesso a dados utilizada para interagir com o banco de dados.
- **Docker**: Utilizado para containerizar a aplicação e o banco de dados.
- **Swagger**: Utilizado para documentar e testar a API.
- **FluentValidation**: Utilizado para validação de dados.