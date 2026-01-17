FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY published/. ./
ENTRYPOINT ["dotnet", "AlgorithmService.dll"]