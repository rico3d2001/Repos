#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["Brass.Materiais.ApiCatalogoPlant/Brass.Materiais.ApiCatalogoPlant.csproj", "Brass.Materiais.ApiCatalogoPlant/"]
COPY ["Brass.Materiais.AppCatalogoP3D/Brass.Materiais.AppCatalogoP3D.csproj", "Brass.Materiais.AppCatalogoP3D/"]
COPY ["Brass.Materiais.RepoCataloESQLServer/Brass.Materiais.RepoCataloESQLServer.csproj", "Brass.Materiais.RepoCataloESQLServer/"]
COPY ["Brass.Materiais.RepoMongoDBCatalogo/Brass.Materiais.RepoMongoDBCatalogo.csproj", "Brass.Materiais.RepoMongoDBCatalogo/"]
COPY ["Brass.Materiais.Dominio.Utils/Brass.Materiais.Dominio.Utils.csproj", "Brass.Materiais.Dominio.Utils/"]
COPY ["Brass.Materiais.DominioPQ/Brass.Materiais.DominioPQ.csproj", "Brass.Materiais.DominioPQ/"]
COPY ["Brass.Materiais.Nucleo/Brass.Materiais.Nucleo.csproj", "Brass.Materiais.Nucleo/"]
RUN dotnet restore "Brass.Materiais.ApiCatalogoPlant/Brass.Materiais.ApiCatalogoPlant.csproj"
COPY . .
WORKDIR "/src/Brass.Materiais.ApiCatalogoPlant"
RUN dotnet build "Brass.Materiais.ApiCatalogoPlant.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Brass.Materiais.ApiCatalogoPlant.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brass.Materiais.ApiCatalogoPlant.dll"]