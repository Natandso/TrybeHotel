# Estágio de compilação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copia apenas os arquivos necessários para restauração e compilação
COPY *.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos e realiza a compilação
COPY . ./
RUN dotnet publish -c Release -o out

# Estágio de execução
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copia os arquivos publicados do estágio de compilação
COPY --from=build-env /app/out .

# Define o comando de entrada
CMD ["dotnet", "TrybeHotel.dll"]
