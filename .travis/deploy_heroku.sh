#!/bin/sh
#wget -qO- https://toolbelt.heroku.com/install-ubuntu.sh | sh
echo "$HEROKU_API_KEY" | docker login -u _ --password-stdin registry.heroku.com
docker tag $DOCKER_IMAGE_NAME registry.heroku.com/$HEROKU_APP_NAME/web
docker push registry.heroku.com/$HEROKU_APP_NAME/web                
curl https://cli-assets.heroku.com/install.sh | sh
heroku container:release web -a $HEROKU_APP_NAME