#!/bin/sh
wget -qO- https://toolbelt.heroku.com/install-ubuntu.sh | sh
#heroku plugins:install heroku-container-registry
docker login -u _ --password=$HEROKU_API_KEY registry.heroku.com
#heroku container:push web --app $HEROKU_APP_NAME
docker tag folkmancer/tinytinabot registry.heroku.com/$HEROKU_APP_NAME/web
docker push registry.heroku.com/$HEROKU_APP_NAME/web                
#curl https://cli-assets.heroku.com/install.sh | sh
heroku container:release web -a $HEROKU_APP_NAME