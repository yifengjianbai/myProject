#!/bin/bash
echo "start run shell"
dotnet build
dotnet publish -o /var/lib/jenkins/workspace/publish
cd /etc/supervisor
echo "change to etc/supervisor"
pwd
supervisorctl reload
echo "success finish shell"
