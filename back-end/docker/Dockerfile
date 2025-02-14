# Usando a imagem oficial do .NET 8 SDK para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir diretório de trabalho
WORKDIR /app

# Copiar arquivos da solução
COPY TicketManager.sln ./
COPY TicketManager.API/TicketManager.API.csproj TicketManager.API/
COPY TicketManager.Application/TicketManager.Application.csproj TicketManager.Application/
COPY TicketManager.CrossCutting/TicketManager.CrossCutting.csproj TicketManager.CrossCutting/
COPY TicketManager.Domain/TicketManager.Domain.csproj TicketManager.Domain/
COPY TicketManager.Infrastructure/TicketManager.Infrastructure.csproj TicketManager.Infrastructure/
COPY TicketManager.Tests/TicketManager.Tests.csproj TicketManager.Tests/

# Restaurar dependências
RUN dotnet restore

# Copiar restante dos arquivos
COPY . .

# Publicar a aplicação
RUN dotnet publish TicketManager.API/TicketManager.API.csproj -c Release -o /publish

# Nova imagem baseada na ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Definir diretório de trabalho no container
WORKDIR /app

# Copiar arquivos publicados
COPY --from=build /publish .

# Expor a porta 5000
EXPOSE 5000

# Configurar variáveis de ambiente para rodar na porta correta
ENV ASPNETCORE_URLS=http://+:5000

# Configurar ponto de entrada
ENTRYPOINT ["dotnet", "TicketManager.API.dll"]