- -e, –excel Required. 输入的Excel文件路径.
- -j, –json 指定输出的json文件路径.
- -h, –header Required. 表格中有几行是表头.
- -c, –encoding (Default: utf8-nobom) 指定编码的名称.
- -l, –lowcase (Default: false) 自动把字段名称转换成小写格式.
- -a 序列化成数组
- -d, --date:指定日期格式化字符串，例如：dd / MM / yyy hh: mm:ss
- -s 序列化时强制带上sheet name，即使只有一个sheet
- -exclude_prefix： 导出时，排除掉包含指定前缀的表单和列，-exclude_prefix #
- -cell_json：自动识别单元格中的Json对象和Json数组，Default：false

  -e, --excel             Required. input excel file path.

  -j, --json              export json file path.

  -p, --csharp            export C# data struct code file path.

  -h, --header            (Default: 1) number lines in sheet as header.

  -c, --encoding          (Default: utf8-nobom) export file encoding.

  -l, --lowcase           (Default: False) convert filed name to lowcase.

  -a, --array             (Default: False) export as array, otherwise as dict
                          object.

  -d, --date              (Default: yyyy/MM/dd) Date Format String, example: dd
                          / MM / yyy hh: mm:ss.

  -s, --sheet             (Default: False) export with sheet name, even there's
                          only one sheet.

  -x, --exclude_prefix    (Default: ) exclude sheet or column start with
                          specified prefix.

  -l, --cell_json         (Default: False) convert json string in cell

  -l, --all_string        (Default: False) all string
```
//mac
mono excel2json.exe --excel ExampleData.xlsx --json test.json --header 3
```