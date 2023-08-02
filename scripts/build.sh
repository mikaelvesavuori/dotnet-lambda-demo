#!/bin/bash

architecture="arm64"
configuration="Release"
framework="net6.0"

if [ -f /etc/debian_version ]; then
  apt -qq update
  apt -qq -y install zip
fi

dotnet restore
dotnet tool install -g Amazon.Lambda.Tools --framework ${framework}

dotnet lambda package --function-architecture ${architecture} --configuration ${configuration} \
  --framework ${framework} \
  --msbuild-parameters "/p:PublishReadyToRun=true --self-contained false" \
  --output-package bin/${configuration}/${framework}/deployment.zip

#declare -a functions=("add" "get")
#for function in ${functions[@]}; do
#  dotnet lambda package -farch arm64 --configuration ${configuration} --framework ${framework} --output-package bin/${configuration}/${framework}/${function}.zip --msbuild-parameters "/p:PublishReadyToRun=true --self-contained true"
#done
