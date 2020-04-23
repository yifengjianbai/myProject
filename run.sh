#!/bin/bash
echo "start run shell"
dotnet build
dotnet publish -o /var/lib/jenkins/workspace/publish
cd /etc/supervisor
echo "开始重启守护进程"
supervisorctl restart MyProject
echo "success finish shell"
