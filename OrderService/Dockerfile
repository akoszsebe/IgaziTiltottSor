FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 8080

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY DotNetCore.csproj ./
RUN dotnet restore ./DotNetCore.csproj
COPY . .
WORKDIR /src/
RUN dotnet build DotNetCore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DotNetCore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DotNetCore.dll"]
