#!/bin/bash

kubectl run $1 --image=localhost:5000/$1
kubectl get pods
