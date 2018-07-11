#!/bin/bash

eval `aws ecr get-login --no-include-email --region us-east-1`
echo `aws ecr get-login --no-include-email --region us-east-1` > /data/jenkins/ecr-login.sh
