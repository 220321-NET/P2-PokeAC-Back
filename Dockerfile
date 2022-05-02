FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY . .

RUN dotnet clean ./P2-PokeAC-Back.sln
RUN dotnet publish WebAPI --configuration Release -o ./publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run

WORKDIR /app

COPY --from=build /app/publish .

CMD ["dotnet", "WebAPI.dll"]

#docker build . -t chainofazns/pokeac-back:x.x  x being version num but w/e just take latest

#docker run -p 5000:80 -d chainofazns/pokeac-back  this is for local stuff, try to remember how you tied it to azure and github some other time

#docker push chainofazns/pokeac-back