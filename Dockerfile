
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019 AS base

# Install chocolatey package manager
RUN powershell -Command \
    Set-ExecutionPolicy Bypass -Scope Process -Force; \
    [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; \
    iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

# Install Xming using chocolatey
RUN powershell -Command choco install -y xming

WORKDIR /app
COPY ./PersonalProj7/incercarea1/bin/Debug/*.exe ./
EXPOSE 80

ENTRYPOINT ["incercarea1.exe"]
