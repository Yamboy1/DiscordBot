# DiscordBot

A practice discord bot written with Discord.Net and Docker.

## Prerequisites

- [Docker](https://docs.docker.com/get-docker/)
- [A Discord Bot Token](https://github.com/reactiflux/discord-irc/wiki/Creating-a-discord-bot-&-getting-a-token)

## Setup

- Initialise the docker swarm if you haven't already: 
  ```bash
  docker swarm init
  ```
  
- Initialize docker secrets:
  ```bash
  echo "YOUR_TOKEN" | docker secret create Token
  echo "YOUR_PREFIX" | docker secret create Prefix
  ```
  
- Create the docker service:
  ```bash
  docker service create --name discordbot --secret Token --secret Prefix ghcr.io/yamboy1/discordbot:v1.0.0
  ```
  
Your bot should be up! You can check the bot logs by running `docker ps`, finding the container id, and then running `dockers logs <CONTAINER_ID>`

## Development

You can run the docker-compose.dev.yml file during development, which reads secrets from a .env file and reload the code when there are changes.
```bash
docker-compose -f docker-compose.dev.yml
```

## License

This bot is licensed under the MIT License.