#!/usr/bin/env bash

for file in *; do
  folder=$(pwd)
  cd ${file}; git status
  cd ${folder}
done


exit
