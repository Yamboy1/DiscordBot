# DiscordBot

A practice discord bot written with Discord.Net and Docker.

## Installation 

### Prerequisites

- [Docker](https://docs.docker.com/get-docker/)
- [A Discord Bot Token](https://github.com/reactiflux/discord-irc/wiki/Creating-a-discord-bot-&-getting-a-token)

### Setup

- Initialise the docker swarm if you haven't already: 
  ```bash
  docker swarm init
  ```
  
- Initialize docker secrets:
  ```bash
  echo "YOUR_TOKEN" | docker secret create DiscordBot_Token
  echo "YOUR_PREFIX" | docker secret create DiscordBot_Prefix
  ```
  
- Clone this repo and start the service
  ```bash
  git clone https://github.com/Yamboy1/DiscordBot
  cd DiscordBot
  docker stack deploy --compose-file docker-compose.yml discordbot
  ```
  
Your bot should be up! You can check the bot logs by running `docker ps`, finding the container id for `discordbot_bot`, and then running `docker logs <CONTAINER_ID>`

### Development

You can run the docker-compose.dev.yml file during development, which reads secrets from a .env file and reload the code when there are changes.
```bash
docker-compose -f docker-compose.dev.yml
```

## Commands

- `ping` - A simple ping command.

## License

This bot is licensed under the MIT License.