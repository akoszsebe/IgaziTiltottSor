#!/bin/bash

if [ "$#" -ne 2 ]; then
    echo "Illegal number of parameters"
    exit 0
fi

RED='\033[0;31m'
NC='\033[0m' # No Color

minikube docker-env
eval $(minikube docker-env)

printf "${RED}Building Docker container for $1 from folder $2 \n ${NC}\n"

docker build -t $1 $2


printf "${RED}Pushing Docker container to local repo${NC} \n"

source ./1-docker-create-local-repo.sh

source ./2-docker-local-push.sh $1

printf "${RED}Creating Kubect POD ${NC} \n"

source ./3-kubectl-create.sh $1

printf "${RED}Creating service for POD $1 ${NC} \n"

if [ "$1" = "gateway" ]; then

 source ./4-kubectl-start-service.sh $1 1

else

 source ./4-kubectl-start-service.sh $1 

fi

minikube service list
