#!/bin/sh

while :
do
    rm index.html
    docker run --rm 172.30.1.97:5000/dotnet-app-v0.1:latest > /usr/share/nginx/html/index.html
    sleep 1
done

