FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/Timecop.Extensions.DependencyInjection/Timecop.Extensions.DependencyInjection.csproj ./src/Timecop.Extensions.DependencyInjection/Timecop.Extensions.DependencyInjection.csproj
COPY test/Timecop.Extensions.DependencyInjection.Tests/Timecop.Extensions.DependencyInjection.Tests.csproj ./test/Timecop.Extensions.DependencyInjection.Tests/Timecop.Extensions.DependencyInjection.Tests.csproj
RUN dotnet restore

# copy everything else and build app
COPY ./ ./
WORKDIR /source
RUN dotnet build -c release -f net7.0 -o /out/package --no-restore

FROM build as test

RUN dotnet test

FROM build as pack-and-push
WORKDIR /source

ARG PackageVersion
ARG NuGetApiKey

RUN dotnet pack ./src/Timecop.Extensions.DependencyInjection/Timecop.Extensions.DependencyInjection.csproj -o /out/package -c Release
RUN dotnet nuget push /out/package/Timecop.Extensions.DependencyInjection.$PackageVersion.nupkg -k $NuGetApiKey -s https://api.nuget.org/v3/index.json