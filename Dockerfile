# Utilizar la imagen oficial de .NET 8 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY Backend.sln ./
COPY Backend.API/Backend.API.csproj ./Backend.API/
COPY Backend.Business/Backend.Business.csproj ./Backend.Business/
COPY Backend.Business.Interface/Backend.Business.Interface.csproj ./Backend.Business.Interface/
COPY Backend.Entities/Backend.Entities.csproj ./Backend.Entities/
COPY Backend.Repository/Backend.Repository.csproj ./Backend.Repository/
COPY Backend.Repository.Interface/Backend.Repository.Interface.csproj ./Backend.Repository.Interface/
COPY Backend.Utilities/Backend.Utilities.csproj ./Backend.Utilities/

# Copiar todos los archivos de la solución
COPY . ./

# Restaurar dependencias y compilar la solución
RUN dotnet restore
RUN dotnet publish Backend.API/Backend.API.csproj -c Release -o out

# Utilizar la imagen de .NET para tiempo de ejecución como base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Exponer el puerto en el que la aplicación va a escuchar
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "Backend.API.dll"]