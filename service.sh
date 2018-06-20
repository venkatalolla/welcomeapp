#!/bin/sh

while :
do
    rm index.html
    dotnet dotnetapp/out/dotnetapp.dll > /usr/share/nginx/html/index.html
    sleep 1
done

