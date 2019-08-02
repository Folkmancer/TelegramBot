#!/bin/sh
#wget -qO- https://toolbelt.heroku.com/install-ubuntu.sh | sh
#heroku plugins:install heroku-container-registry
echo "$HEROKU_API_KEY" | docker login -u _ --password-stdin registry.heroku.com
#docker login -u _ --password=$HEROKU_API_KEY registry.heroku.com
#heroku container:push web --app $HEROKU_APP_NAME
docker tag $DOCKER_IMAGE_NAME registry.heroku.com/$HEROKU_APP_NAME/web
docker push registry.heroku.com/$HEROKU_APP_NAME/web                
curl https://cli-assets.heroku.com/install.sh | sh
heroku container:release web -a $HEROKU_APP_NAME