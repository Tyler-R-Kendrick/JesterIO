# Use the dotnet 9 image as the base image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base

# Install any necessary dependencies for the project
RUN apt-get update && apt-get install -y \
    curl \
    git \
    && rm -rf /var/lib/apt/lists/*

# Set up the environment for the dev container
WORKDIR /workspace
