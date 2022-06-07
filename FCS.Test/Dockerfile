FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FCS.Test/FCS.Test.csproj", "FCS.Test/"]
RUN dotnet restore "FCS.Test/FCS.Test.csproj"
COPY . .
WORKDIR "/src/FCS.Test"
RUN dotnet build "FCS.Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FCS.Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FCS.Test.dll"]
