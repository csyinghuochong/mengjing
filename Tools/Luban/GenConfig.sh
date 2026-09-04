#!/usr/bin/env bash
set -euo pipefail

WORKSPACE="../.."
LUBAN_DLL="$WORKSPACE/Tools/Luban/LubanRelease/Luban.dll"
CONF_ROOT="$WORKSPACE/Unity/Assets/Config/Excel"

generate_main() {
  local target="$1" code_dir="$2" data_group="$3"
  dotnet "$LUBAN_DLL" --customTemplateDir CustomTemplate -t "$target" -c cs-bin -d bin -d json \
    --conf "$CONF_ROOT/__luban__.conf" \
    -x outputCodeDir="$WORKSPACE/Unity/Assets/Scripts/Model/Generate/$code_dir/Config" \
    -x bin.outputDataDir="$WORKSPACE/Config/Excel/$data_group" \
    -x json.outputDataDir="$WORKSPACE/Config/Json/$data_group" \
    -x lineEnding=LF
}

generate_start_code() {
  local environment="$1" data_group="$2" code_dir="$3"
  dotnet "$LUBAN_DLL" --customTemplateDir CustomTemplate -t all -c cs-bin -d bin -d json \
    --conf "$CONF_ROOT/StartConfig/$environment/__luban__.conf" \
    -x outputCodeDir="$WORKSPACE/Unity/Assets/Scripts/Model/Generate/$code_dir/Config/StartConfig" \
    -x bin.outputDataDir="$WORKSPACE/Config/Excel/$data_group/$environment" \
    -x json.outputDataDir="$WORKSPACE/Config/Json/$data_group/$environment" \
    -x lineEnding=LF
}

generate_start_data() {
  local environment="$1" data_group="$2"
  dotnet "$LUBAN_DLL" --customTemplateDir CustomTemplate -t all -d bin -d json \
    --conf "$CONF_ROOT/StartConfig/$environment/__luban__.conf" \
    -x bin.outputDataDir="$WORKSPACE/Config/Excel/$data_group/$environment" \
    -x json.outputDataDir="$WORKSPACE/Config/Json/$data_group/$environment"
}

generate_main all Client c
generate_main all Server s
generate_main all ClientServer cs
generate_start_code Release s Server
generate_start_code Release cs ClientServer

for environment in Benchmark Beta Localhost RouterTest; do
  generate_start_data "$environment" s
  generate_start_data "$environment" cs
done

echo "Luban export finished"
