FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IMS/IMS.csproj", "IMS/"]
RUN dotnet restore "IMS/IMS.csproj"
COPY . .
WORKDIR "/src/IMS"
RUN dotnet build "IMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMS.dll"]
