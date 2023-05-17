## 工具路径
#echo "param1:$1"
## 需要导出的excel路径
#echo "param2:$2"
## json文件存放路径
#echo "param3:$3"
## csharp文件存放路径
#echo "param4:$4"
cd "$1" || exit
pwd 
echo "mono excel2json.exe --excel $2 --json $3 --csharp $4 --header 3"
mono excel2json.exe --excel "$2" --json "$3" --csharp "$4" --header 3 -a