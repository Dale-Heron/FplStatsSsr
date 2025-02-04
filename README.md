# FplStatsSsr

FplStatsSsr is a C# Blazor [Server-Side Render](https://blazor-university.com/overview/blazor-hosting-models/) web application that allows the latest Fantasy Premier League player data to be sorted and filtered.

This webapp grabs the latest player data from [here]("https://fantasy.premierleague.com/api/bootstrap-static/")
and makes it easy to search and filter.

## Build and run web app

To build and run use VS code or 'dotnet run'

## Publish Docker image

There is a github workflow that on a git commit to `main` publishes the docker image to DockerHub `dheron/fplstatssr:latest`

## Azure

The code is then deployed via [Azure Container Apps](https://portal.azure.com/#browse/Microsoft.App%2FcontainerApps)
