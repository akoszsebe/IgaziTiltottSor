#!/bin/bash

if [ "$#" -ne 1 ]; then
    echo "Illegal number of parameters"
    exit 0
fi

minikube docker-env
eval $(minikube docker-env)

#Create a tag for the image
docker tag $1 localhost:5000/$1

#Push image to local fake repo
docker push localhost:5000/$1

