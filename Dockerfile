# Use a imagem base do .NET SDK para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copie o arquivo de solução e arquivos de projeto
COPY *.sln ./
COPY Application/Application.csproj Application/
COPY Domain/Domain.csproj Domain/
COPY Infra.Data/Infra.Data.csproj Infra.Data/
COPY Infra.IoC/Infra.IoC.csproj/ Infra.IoC/

# Restaure as dependências
RUN dotnet restore

# Copie o restante dos arquivos
COPY . ./

# Faça o build do projeto
RUN dotnet publish Application/Application.csproj -c Release -o out

# Use a imagem base do .NET Runtime para o runtime da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponha a porta usada pela aplicação
EXPOSE 5005
EXPOSE 7027
EXPOSE 8080

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "Application.dll"]