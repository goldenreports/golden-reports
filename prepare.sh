#!/bin/bash

dotnet tool restore
dotnet husky install

chmod +x .husky/commit-msg
chmod +x .husky/pre-commit
chmod +x .husky/pre-push