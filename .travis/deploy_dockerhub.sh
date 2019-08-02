#!/bin/sh
echo "$DOCKER_PASS" | docker login -u "$DOCKER_USER" --password-stdin
#docker login -u $DOCKER_USER -p $DOCKER_PASS
if [ "$TRAVIS_BRANCH" = "master" ]; then
    TAG="latest"
else
    TAG="$TRAVIS_BRANCH"
fi
docker build -f TinyTinaBot/Dockerfile -t $DOCKER_IMAGE_NAME:$TAG .
docker push $DOCKER_IMAGE_NAME:$TAG