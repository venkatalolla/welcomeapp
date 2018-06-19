#!/bin/bash


docker run -d --name jenkins \
	-u root \
	-p 8080:8080 \
	-p 50000:50000 \
	-v /data/jenkins:/var/jenkins_home \
	-v $HOME/apps:/apps \
	-v /var/run/docker.sock:/var/run/docker.sock \
	jenkinsci/blueocean
