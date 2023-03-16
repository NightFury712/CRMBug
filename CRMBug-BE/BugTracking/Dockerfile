#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM base AS runtime
ENV TZ="Asia/Ho_Chi_Minh"
RUN date
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "MISA.BugTracking.dll"]