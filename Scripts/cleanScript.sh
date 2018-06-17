#!/bin/bash

if [ "$#" -ne 1 ]; then
    echo "Illegal number of parameters"
    exit 0
fi

kubectl delete service $1

kubectl delete deployment $1

