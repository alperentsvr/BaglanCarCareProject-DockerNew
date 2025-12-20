# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyalarını kopyala
COPY . .

# Bağımlılıkları yükle ve projeyi derle
RUN dotnet restore "BaglanCarCare.WebApi/BaglanCarCare.WebApi.csproj"
RUN dotnet publish "BaglanCarCare.WebApi/BaglanCarCare.WebApi.csproj" -c Release -o /app/publish

# Run aşaması (Final image)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "BaglanCarCare.WebApi.dll"]