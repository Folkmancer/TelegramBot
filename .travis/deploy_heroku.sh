#!/bin/sh
echo "$HEROKU_API_KEY" | docker login -u _ --password-stdin registry.heroku.com
if [ "$TRAVIS_BRANCH" = "master" ]; then
    TAG="latest"
else
    TAG="$TRAVIS_BRANCH"
fi
docker tag $DOCKER_IMAGE_NAME:$TAG registry.heroku.com/$HEROKU_APP_NAME/web
docker push registry.heroku.com/$HEROKU_APP_NAME/web                
curl https://cli-assets.heroku.com/install.sh | sh
heroku container:release web -a $HEROKU_APP_NAME