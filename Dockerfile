# Use a imagem base do .NET SDK para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copie os arquivos de projeto e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie o restante dos arquivos e faça o build
COPY . ./
RUN dotnet publish -c Release -o out

# Use a imagem base do .NET Runtime para o runtime da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponha a porta usada pela aplicação
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "TaskManager.dll"]