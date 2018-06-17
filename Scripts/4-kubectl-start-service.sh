#!/bin/bash

if [ "$#" -eq 1 ]; then
 kubectl expose deploy $1 --port 8080 --name=$1
else
 echo Creating NodePort -=-=-=-=-=-=-=
 kubectl expose deploy $1 --port 8080 --name=$1 --type=NodePort
fi
