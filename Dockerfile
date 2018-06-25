FROM microsoft/aspnetcore-build as build

WORKDIR /source/app

COPY app/*.csproj .
COPY utils/*.csproj /source/utils/
COPY tests/*.csproj /source/tests/
RUN dotnet restore 

# copy and build everything else
COPY app/. .
COPY utils/. /source/utils/
COPY tests/. /source/tests/

RUN dotnet build

# do tests
FROM build AS testrunner
WORKDIR /source/tests
ENTRYPOINT ["dotnet", "test","--logger:trx"]

FROM build AS test
WORKDIR /source/tests
RUN dotnet test

FROM test AS publish
WORKDIR /source/app
RUN dotnet publish -o out

FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=publish /source/app/out .
ENTRYPOINT ["dotnet", "aspnet-react.dll"]


