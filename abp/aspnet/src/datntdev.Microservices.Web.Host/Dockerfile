FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/datntdev.Microservices.Web.Host/datntdev.Microservices.Web.Host.csproj", "src/datntdev.Microservices.Web.Host/"]
COPY ["src/datntdev.Microservices.Web.Core/datntdev.Microservices.Web.Core.csproj", "src/datntdev.Microservices.Web.Core/"]
COPY ["src/datntdev.Microservices.Application/datntdev.Microservices.Application.csproj", "src/datntdev.Microservices.Application/"]
COPY ["src/datntdev.Microservices.Core/datntdev.Microservices.Core.csproj", "src/datntdev.Microservices.Core/"]
COPY ["src/datntdev.Microservices.EntityFrameworkCore/datntdev.Microservices.EntityFrameworkCore.csproj", "src/datntdev.Microservices.EntityFrameworkCore/"]
WORKDIR "/src/src/datntdev.Microservices.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/datntdev.Microservices.Web.Host", "src/datntdev.Microservices.Web.Host"]
COPY ["src/datntdev.Microservices.Web.Core", "src/datntdev.Microservices.Web.Core"]
COPY ["src/datntdev.Microservices.Application", "src/datntdev.Microservices.Application"]
COPY ["src/datntdev.Microservices.Core", "src/datntdev.Microservices.Core"]
COPY ["src/datntdev.Microservices.EntityFrameworkCore", "src/datntdev.Microservices.EntityFrameworkCore"]
WORKDIR "/src/src/datntdev.Microservices.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "datntdev.Microservices.Web.Host.dll"]
