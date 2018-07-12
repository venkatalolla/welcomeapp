#!/bin/bash

# DOCKER_REGISTRY=`docker inspect registry --format='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}'`
# DOCKER_REGISTRY=host.docker.internal
# REPO_PATH="wherever"
# REPO_PATH=host.docker.internal:/Users/benhunter/local-work/dot-net-webinar/repo/dotnetapp

docker run -d --name jenkins \
	-u root \
	-p 8080:8080 \
	-p 50000:50000 \
	-v /data/jenkins:/var/jenkins_home \
	-v $HOME/apps:/apps \
	-v /var/run/docker.sock:/var/run/docker.sock \
    -e REPO_PATH=$REPO_PATH \
    -e DOCKER_REGISTRY=$DOCKER_REGISTRY \
	jenkinsci/blueocean

docker run -d -p 5000:5000 --restart=always --name registry registry:2
