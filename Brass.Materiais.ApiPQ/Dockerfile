#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["Brass.Materiais.ApiPQ/Brass.Materiais.ApiPQ.csproj", "Brass.Materiais.ApiPQ/"]
COPY ["Brass.Materiais.AppBIMAspNetCore/Brass.Materiais.AppBIMAspNetCore.csproj", "Brass.Materiais.AppBIMAspNetCore/"]
COPY ["Brass.Materiais.DominioPQ/Brass.Materiais.DominioPQ.csproj", "Brass.Materiais.DominioPQ/"]
COPY ["Brass.Materiais.Dominio.Utils/Brass.Materiais.Dominio.Utils.csproj", "Brass.Materiais.Dominio.Utils/"]
COPY ["Brass.Materiais.Nucleo/Brass.Materiais.Nucleo.csproj", "Brass.Materiais.Nucleo/"]
COPY ["Brass.Materiais.RepoMongoDBCatalogo/Brass.Materiais.RepoMongoDBCatalogo.csproj", "Brass.Materiais.RepoMongoDBCatalogo/"]
COPY ["Brass.Materiais.AppPQClean/Brass.Materiais.AppPQClean.csproj", "Brass.Materiais.AppPQClean/"]
RUN dotnet restore "Brass.Materiais.ApiPQ/Brass.Materiais.ApiPQ.csproj"
COPY . .
WORKDIR "/src/Brass.Materiais.ApiPQ"
RUN dotnet build "Brass.Materiais.ApiPQ.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Brass.Materiais.ApiPQ.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brass.Materiais.ApiPQ.dll"]