# From official Microsoft repository
FROM mcr.microsoft.com/mssql/server:2019-latest

USER root

RUN export DEBIAN_FRONTEND="noninteractive"
RUN apt-get update
RUN apt-get install -y curl gnupg
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/ubuntu/16.04/mssql-server-2019.list | tee /etc/apt/sources.list.d/mssql-server.list
RUN apt-get update
# Install optional packages. Comment out the ones you don't need
# RUN apt-get install -y mssql-server-agent
# RUN apt-get install -y mssql-server-ha
RUN apt-get install -y mssql-server-fts
# Run SQL Server process
CMD /opt/mssql/bin/sqlservr