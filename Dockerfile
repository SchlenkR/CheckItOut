# Use the official .NET SDK image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:5.0

# Set the working directory in the container
WORKDIR /workspace

# Copy the current directory contents into the container at /workspace
COPY . /workspace

# Install Ionide (F#) extension for VS Code
RUN apt-get update && \
    apt-get install -y wget && \
    wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg && \
    mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/ && \
    wget -q https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y code

# Install Ionide extension
RUN code --install-extension Ionide.ionide-fsharp

# Expose port 5000 for the application
EXPOSE 5000

# Run the application
CMD ["dotnet", "run"]
