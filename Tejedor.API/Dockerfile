#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your 
#images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may
#need to be changed.

#For more information, please see https://aka.ms/containercompat

# Usa la imagen del SDK de .NET Core para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019 AS build
WORKDIR /src

# Copia el archivo de proyecto y restaura las dependencias
COPY Tejedor.API/Tejedor.API.csproj Tejedor.API/
RUN dotnet restore Tejedor.API/Tejedor.API.csproj

# Copia el resto de los archivos de la aplicación y construye el proyecto
COPY Tejedor.API/. Tejedor.API/
WORKDIR /src/Tejedor.API
RUN dotnet build Tejedor.API.csproj -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish Tejedor.API.csproj -c Release -o /app/publish /p:UseAppHost=false

# Usa la imagen de ASP.NET Core para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019 AS base
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
EXPOSE 8081
