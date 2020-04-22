#!/bin/bash
echo "start run shell"
git pull
dotnet build
dotnet publish -o /root/publish
cd /etc/supervisor
supervisorctl reload
echo "success finish shell"
