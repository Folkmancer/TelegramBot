#!/bin/sh
docker login -u $DOCKER_USER -p $DOCKER_PASS
if [ "$TRAVIS_BRANCH" = "master" ]; then
    TAG="latest"
else
    TAG="$TRAVIS_BRANCH"
fi
#docker build -f TinyTinaBot/Dockerfile -t folkmancer-telegrambot:$TAG .
#docker push folkmancer-telegrambot

docker build -f TinyTinaBot/Dockerfile .
docker push tinytinabot