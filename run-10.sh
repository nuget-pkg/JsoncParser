#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`
cd JsoncParser.Demo
dotnet run --project JsoncParser.Demo.csproj --framework net10.0 "$@"
