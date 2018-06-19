#!/bin/bash

RED='\033[0;31m'
NC='\033[0m' # No Color
GREEN='\033[00;32m'

printf "${RED} -----===================------\n
Building all project \n"

printf "${GREEN} --Building GATEWAY ${NC}\n"

source ./cleanScript.sh gateway
source ./buildScript.sh gateway ../GateWay

printf "${GREEN} --Building STORAGE SERVICE ${NC}\n"

source ./cleanScript.sh storage-service
source ./buildScript.sh storage-service ../StorageService

printf "${GREEN} --Building ORDER SERVICE ${NC}\n"

source ./cleanScript.sh order-service
source ./buildScript.sh order-service ../OrderService

printf "${GREEN} --Building PAYMENT SERVICE ${NC}\n"

source ./cleanScript.sh payment-service
source ./buildScript.sh payment-service ../PaymentService

printf "${GREEN} --Building DRON SERVICE ${NC}\n"

source ./cleanScript.sh drone-service
source ./buildScript.sh drone-service ../DronService

printf "${GREEN} --Building user SERVICE ${NC}\n"

source ./cleanScript.sh user-service
source ./buildScript.sh user-service ../UserService
