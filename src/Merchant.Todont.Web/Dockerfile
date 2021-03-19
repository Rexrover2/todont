FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS publish
WORKDIR /src
COPY src/Merchant.Todont.Api/*.csproj ./Merchant.Todont.Api/
COPY src/Merchant.Todont.Domain/*.csproj ./Merchant.Todont.Domain/
COPY src/Merchant.Todont.Enums/*.csproj ./Merchant.Todont.Enums/
COPY src/Merchant.Todont.Infrastructure/*.csproj ./Merchant.Todont.Infrastructure/
COPY src/Merchant.Todont.Tests/*.csproj ./Merchant.Todont.Tests/
COPY src/Merchant.Todont.Web/*.csproj ./Merchant.Todont.Web/
COPY src/Merchant.Todont.sln ./
RUN dotnet restore Merchant.Todont.sln --runtime alpine-x64
COPY src/* ./
RUN dotnet publish Merchant.Todont.Web/Merchant.Todont.Web.csproj \
  -c Release \
  -o /app/publish \
  --no-restore \
  --runtime alpine-x64 \
  --self-contained true \
  /p:PublishTrimmed=true \
  /p:PublishSingleFile=true
FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish 
ENV Jwt__Key=/var/run/secrets/jwt_key.txt
ENV ConnectionStrings__TodontContext=ConnectionStrings__TodontContext=Host=postgres;Port=5432;Database=todont;User=todont;Password=todont;
ENTRYPOINT ["./Merchant.Todont.Web"]