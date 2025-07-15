# GestaoFreela

Sistema de gestão de freelancers e serviços, desenvolvido em ASP.NET Core 8.0 (Blazor Server) com Entity Framework Core e MySQL.

## Funcionalidades
- Cadastro e login de usuários com três perfis: admin, cliente e freelancer
- Cadastro e gerenciamento de serviços por clientes
- Candidatura e participação de freelancers em serviços
- Aprovação/reprovação de freelancers pelo cliente
- Controle de status dos serviços (aguardando, ativo, em andamento, finalizado, cancelado)
- Relatórios administrativos: serviços finalizados por período e ranking de freelancers
- Interface em português, responsiva e com Bootstrap

## Requisitos
- .NET 8.0 SDK
- MySQL Server
- Ferramenta Entity Framework Core CLI (`dotnet-ef`)

## Configuração do ambiente

1. **Clone o repositório**
   ```bash
   git clone <url-do-repositorio>
   cd GestaoFreela

2. **Configure o banco de dados**
    - Você pode criar o banco de dados manualmente no MySQL (ex: `db_freelancers`) **ou** utilizar Docker:
      ```bash
      docker-compose up -d
      ```
    - Atualize a string de conexão em `appsettings.json`:
      ```json
      "ConnectionStrings": {
         "DefaultConnection": "server=localhost;database=db_freelancers;user=root;password=SUASENHA;"
      }
      ```


3. **Restaure os pacotes e aplique as migrations**
   ```bash
   dotnet restore
   dotnet ef database update
   ```

4. **Execute o projeto**
   ```bash
   dotnet run
   ```
   O sistema estará disponível em `http://localhost:5000` (ou porta configurada).

## Usuários iniciais
- O sistema pode criar um usuário admin padrão na primeira execução, ou utilize o registro manual e promova o usuário para admin via banco de dados.

## Principais Telas
- **Admin**: Gerencia categorias e acessa relatórios
- **Cliente**: Gerencia seus serviços, aprova freelancers, finaliza/cancela serviços
- **Freelancer**: Busca serviços, se candidata, acompanha serviços aceitos

## Comandos úteis
- Criar nova migration:
  ```bash
  dotnet ef migrations add NomeDaMigration
  ```
- Atualizar banco de dados:
  ```bash
  dotnet ef database update
  ```

## Observações
- Certifique-se de que o MySQL está rodando e acessível.
- O projeto utiliza Bootstrap e FontAwesome para o layout.
- Para dúvidas ou problemas, consulte o código-fonte ou abra uma issue.

---

**Desenvolvido por [Seu Nome/Equipe]**
