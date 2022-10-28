FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IMS.WebApp/IMS.WebApp.csproj", "IMS.WebApp/"]
RUN dotnet restore "IMS.WebApp/IMS.WebApp.csproj"
COPY . .
WORKDIR "/src/IMS.WebApp"
RUN dotnet build "IMS.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IMS.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMS.WebApp.dll"]
