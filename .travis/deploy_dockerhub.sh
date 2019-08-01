#!/bin/sh
docker login -u $DOCKER_USER -p $DOCKER_PASS
if [ "$TRAVIS_BRANCH" = "master" ]; then
    TAG="latest"
else
    TAG="$TRAVIS_BRANCH"
fi
docker build -f TinyTinaBot/Dockerfile -t folkmancer/tinytinabot:latest .
docker push folkmancer/tinytinabot:latest