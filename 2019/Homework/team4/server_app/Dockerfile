FROM mcr.microsoft.com/dotnet/core/sdk AS base
EXPOSE 3000
WORKDIR /app

# восстанавливает зависимости и средства проекта
COPY . .
RUN dotnet restore

# упаковывает приложение и его зависимости в папку для развертывания на размещающей системе
# COPY . .
RUN dotnet publish -c Release -o out

WORKDIR /app/out
CMD dotnet ConsoleApp1.dll
