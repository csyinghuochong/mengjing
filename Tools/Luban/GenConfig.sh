#!/usr/bin/env bash
set -euo pipefail

# 固定工作目录到脚本所在目录，保证 CustomTemplate 等相对路径与从哪个目录调用无关
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"
WORKSPACE="$(cd "$SCRIPT_DIR/../.." && pwd)"

LUBAN_DLL="$WORKSPACE/Tools/Luban/LubanRelease/Luban.dll"
CONF_ROOT="$WORKSPACE/Unity/Assets/Config/Excel"

# 客户端配置产物，以及 Unity 工程里实际读取的拷贝
CLIENT_BYTES_DIR="$WORKSPACE/Config/Excel/c"
UNITY_CLIENT_BYTES_DIR="$WORKSPACE/Unity/Assets/Bundles/Config"
CLIENT_CODE_DIR="$WORKSPACE/Unity/Assets/Scripts/Model/Generate/Client/Config"
SERVER_CODE_DIR="$WORKSPACE/Unity/Assets/Scripts/Model/Generate/Server/Config"
CLIENT_SERVER_CODE_DIR="$WORKSPACE/Unity/Assets/Scripts/Model/Generate/ClientServer/Config"

# 导表会删除/重建生成的 .cs，Unity 同时开着时 .meta 必须在导表前备份、导表后还原，GUID 才不会变
META_BACKUP_DIR="$(mktemp -d "${TMPDIR:-/tmp}/luban-meta-backup.XXXXXX")"
METAS_RESTORED=0

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
    -x bin.outputDataDir="$WORKSPACE/Config/Excel/$data_group/StartConfig/$environment" \
    -x json.outputDataDir="$WORKSPACE/Config/Json/$data_group/StartConfig/$environment" \
    -x lineEnding=LF
}

generate_start_data() {
  local environment="$1" data_group="$2"
  dotnet "$LUBAN_DLL" --customTemplateDir CustomTemplate -t all -d bin -d json \
    --conf "$CONF_ROOT/StartConfig/$environment/__luban__.conf" \
    -x bin.outputDataDir="$WORKSPACE/Config/Excel/$data_group/StartConfig/$environment" \
    -x json.outputDataDir="$WORKSPACE/Config/Json/$data_group/StartConfig/$environment"
}

backup_metas() {
  local dir="$1" name="$2"
  [ -d "$dir" ] || return 0
  local backup="$META_BACKUP_DIR/$name" file relative
  mkdir -p "$backup"
  while IFS= read -r -d '' file; do
    relative="${file#"$dir"/}"
    mkdir -p "$backup/$(dirname "$relative")"
    cp -p "$file" "$backup/$relative"
  done < <(find "$dir" -name '*.meta' -print0)
}

restore_metas() {
  local dir="$1" name="$2"
  [ -d "$dir" ] || return 0
  local backup="$META_BACKUP_DIR/$name" file relative
  [ -d "$backup" ] || return 0
  while IFS= read -r -d '' file; do
    relative="${file#"$backup"/}"
    mkdir -p "$dir/$(dirname "$relative")"
    cp -p "$file" "$dir/$relative"
  done < <(find "$backup" -name '*.meta' -print0)
}

backup_all_metas() {
  backup_metas "$CLIENT_CODE_DIR" ClientConfig
  backup_metas "$SERVER_CODE_DIR" ServerConfig
  backup_metas "$CLIENT_SERVER_CODE_DIR" ClientServerConfig
}

restore_all_metas() {
  restore_metas "$CLIENT_CODE_DIR" ClientConfig
  restore_metas "$SERVER_CODE_DIR" ServerConfig
  restore_metas "$CLIENT_SERVER_CODE_DIR" ClientServerConfig
}

sync_client_bytes() {
  if [ ! -d "$CLIENT_BYTES_DIR" ]; then
    echo "[ERROR] Client config bytes not found: $CLIENT_BYTES_DIR" >&2
    return 1
  fi
  mkdir -p "$UNITY_CLIENT_BYTES_DIR"

  # 保留 Unity 侧的 .meta（GUID 不能变），只清掉旧的配置内容
  find "$UNITY_CLIENT_BYTES_DIR" -type f ! -name '*.meta' -delete
  cp -a "$CLIENT_BYTES_DIR/." "$UNITY_CLIENT_BYTES_DIR/"

  local file relative
  while IFS= read -r -d '' file; do
    relative="${file#"$CLIENT_BYTES_DIR"/}"
    if ! cmp -s "$file" "$UNITY_CLIENT_BYTES_DIR/$relative"; then
      echo "[ERROR] Unity client config differs after copy: $relative" >&2
      return 1
    fi
  done < <(find "$CLIENT_BYTES_DIR" -name '*.bytes' -type f -print0)
}

remove_unused_metas() {
  local dir="$1" file
  [ -d "$dir" ] || return 0
  while IFS= read -r -d '' file; do
    [ -e "${file%.meta}" ] || rm -f "$file"
  done < <(find "$dir" -name '*.meta' -print0)
}

cleanup() {
  local status=$?
  if [ "$METAS_RESTORED" -eq 0 ]; then
    restore_all_metas || true
  fi
  rm -rf "$META_BACKUP_DIR"
  exit "$status"
}
trap cleanup EXIT

backup_all_metas

generate_main client Client c
generate_main server Server s
generate_main all ClientServer cs

generate_start_code Release s Server
generate_start_code Release cs ClientServer

for environment in Benchmark Beta Localhost RouterTest; do
  generate_start_data "$environment" s
  generate_start_data "$environment" cs
done

restore_all_metas
METAS_RESTORED=1

sync_client_bytes

remove_unused_metas "$UNITY_CLIENT_BYTES_DIR"
remove_unused_metas "$CLIENT_CODE_DIR"
remove_unused_metas "$SERVER_CODE_DIR"
remove_unused_metas "$CLIENT_SERVER_CODE_DIR"

echo "Luban export finished"
