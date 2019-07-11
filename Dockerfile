FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base

COPY node_modules/wait_for_it.sh/bin/wait-for-it app/wait_for_it.sh
RUN chmod +x /app/wait_for_it.sh

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["NTytL.csproj", "./"]
RUN dotnet restore "NTytL.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "NTytL.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NTytL.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENV WAITHOST=mysql WAITPORT=3306
ENTRYPOINT ./wait_for_it.sh $WAITHOST:$WAITPORT --timeout=0 && exec dotnet NtytL.dll
#ENTRYPOINT ["dotnet", "NTytL.dll"]