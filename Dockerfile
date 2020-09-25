FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Prs/Prs.csproj", "Prs/"]
COPY ["WorkerService/WorkerService.csproj", "WorkerService/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Email/Email.csproj", "Email/"]
RUN dotnet restore "Prs/Prs.csproj"
COPY . .
WORKDIR "/src/Prs"
RUN dotnet build "Prs.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Prs.csproj" -c Release -o /app

#Angular build
FROM node as nodebuilder

# set working directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH

# install and cache app dependencies
COPY Prs/ClientApp/package.json /usr/src/app/package.json
RUN npm install
RUN npm install -g @angular/cli --unsafe

# add app

COPY Prs/ClientApp/. /usr/src/app

RUN npm run build

#End Angular build

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN mkdir -p /app/ClientApp/dist
COPY --from=nodebuilder /usr/src/app/dist/. /app/ClientApp/dist/
ENTRYPOINT ["dotnet", "Prs.dll"]