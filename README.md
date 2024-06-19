# Task-Manager

Task-Manager é uma aplicação em C# projetada para gerenciar e organizar tarefas de forma eficiente. Este projeto usa uma abordagem de arquitetura limpa, garantindo a separação de responsabilidades e fácil manutenção.

## Funcionalidades

- Criação, atualização e exclusão de tarefas
- Categorização de tarefas
## Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- Postgresql
- Docker

## Começando

### Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

### Instalação

1. Clone o repositório:
    ```bash
    git clone https://github.com/juliofilizzola/Task-Manager.git
    cd Task-Manager
    ```

2. Construa o projeto:
    ```bash
    dotnet build
    ```

3. Execute a aplicação:
    ```bash
    dotnet run
    ```

4. Alternativamente, execute com Docker:
    ```bash
    docker-compose up
    ```

## Estrutura do Projeto

- **Application**: Contém a lógica de negócios e serviços de aplicação.
- **Domain**: Contém modelos de domínio e repositórios.
- **Infra.Data**: Contém a lógica de acesso a dados e configurações do Entity Framework.
- **Infra.IoC**: Contém as configurações de injeção de dependência.

## Contribuindo

1. Faça um fork do repositório.
2. Crie uma nova branch:
    ```bash
    git checkout -b feature-branch
    ```
3. Faça suas alterações.
4. Commit suas alterações:
    ```bash
    git commit -m "Adicionar nova funcionalidade"
    ```
5. Faça o push para a branch:
    ```bash
    git push origin feature-branch
    ```
6. Abra um pull request.

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Contato

Julio Filizzola - juliofilizzola@example.com

Link do Projeto: [https://github.com/juliofilizzola/Task-Manager](https://github.com/juliofilizzola/Task-Manager)
