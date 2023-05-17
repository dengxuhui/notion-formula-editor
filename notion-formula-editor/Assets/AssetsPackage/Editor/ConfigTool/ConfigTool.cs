using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace NotionFormulaEditor.Editor.ConfigTool
{
    /// <summary>
    /// 本地存储key
    /// </summary>
    public static class ConfigPrefsKey
    {
        public static readonly string XlsxDir = "xlsxDir";
        public static readonly string Excel2JsonDir = "excel2jsonDir";
    }

    /// <summary>
    /// 配置导出工具
    /// </summary>
    public class ConfigTool : EditorWindow
    {
        //xlsx文件夹
        private static string xlsxDir = string.Empty;

        //工具目录
        private static string excel2jsonDir = string.Empty;

        //json文件存放目录
        private static string jsonSaveDir = string.Empty;

        private static string csharpSaveDir = string.Empty;

        [MenuItem("Window/ConfigTool")]
        static void Init()
        {
            GetWindow(typeof(ConfigTool), false, "ConfigToolExport");
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(excel2jsonDir))
            {
                excel2jsonDir = EditorPrefs.GetString(ConfigPrefsKey.Excel2JsonDir);
            }

            if (string.IsNullOrEmpty(xlsxDir))
            {
                xlsxDir = EditorPrefs.GetString(ConfigPrefsKey.XlsxDir);
            }

            if (string.IsNullOrEmpty(jsonSaveDir))
            {
                jsonSaveDir = Path.Combine(Application.dataPath, "AssetsPackage/Resources/Json");
            }

            if (string.IsNullOrEmpty(csharpSaveDir))
            {
                csharpSaveDir = Path.Combine(Application.dataPath, "AssetsPackage/Scripts/Config/Datas");
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("##############Export xlsx files to json and c###############");
            GUILayout.Space(20);
            GUILayout.BeginHorizontal();
            GUILayout.Label("xlsx dir:", EditorStyles.boldLabel, GUILayout.Width(120));
            xlsxDir = GUILayout.TextField(xlsxDir, GUILayout.MinWidth(120));
            if (GUILayout.Button("Select Folder"))
            {
                SelectXlsxDir();
            }

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("excel2jsonDir:", EditorStyles.boldLabel, GUILayout.Width(120));
            excel2jsonDir = GUILayout.TextField(excel2jsonDir, GUILayout.MinWidth(120));
            if (GUILayout.Button("Select Folder"))
            {
                SelectExcel2JsonDir();
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("---------------------");
            if (GUILayout.Button("Export All", GUILayout.Width(160)))
            {
                HandleExportAll();
            }

            GUILayout.Label("---------------------");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("---------------------");
            if (GUILayout.Button("Export Single File", GUILayout.Width(160)))
            {
                HandleExportOne();
            }

            GUILayout.Label("---------------------");

            GUILayout.EndHorizontal();
        }

        private void SelectXlsxDir()
        {
            xlsxDir = EditorUtility.OpenFolderPanel("Select Xlsx Dir", Application.dataPath, "");
            if (string.IsNullOrEmpty(xlsxDir))
            {
                return;
            }

            EditorPrefs.SetString(ConfigPrefsKey.XlsxDir, xlsxDir);
        }

        private void SelectExcel2JsonDir()
        {
            excel2jsonDir = EditorUtility.OpenFolderPanel("Select Excel2Json Dir", Application.dataPath, "");
            if (string.IsNullOrEmpty(excel2jsonDir))
            {
                return;
            }

            var pingPath = Path.Combine(excel2jsonDir, "excel2json.exe");
            if (!File.Exists(pingPath))
            {
                excel2jsonDir = string.Empty;
                HandleComplete(false, "dir error,excel2json.exe not exist!");
                return;
            }

            EditorPrefs.SetString(ConfigPrefsKey.Excel2JsonDir, excel2jsonDir);
        }

        private void HandleExportAll()
        {
            if (string.IsNullOrEmpty(xlsxDir) || !Directory.Exists(xlsxDir))
            {
                HandleComplete(false, "xlsxDir is not set!");
                return;
            }

            if (string.IsNullOrEmpty(excel2jsonDir) || !Directory.Exists(excel2jsonDir))
            {
                HandleComplete(false, "excel2jsonDir is not set!");
                return;
            }

            var xlsxPaths = Directory.GetFiles(xlsxDir, "*.xlsx", SearchOption.AllDirectories);
            for (var i = 0; i < xlsxPaths.Length; i++)
            {
                ExportOne(xlsxPaths[i]);
            }

            HandleComplete(true, "export success!");
        }

        private void HandleExportOne()
        {
            var filePath = EditorUtility.OpenFilePanelWithFilters("ConfigTool", xlsxDir, new[] { "xlsx", "xlsx" });
            if (!File.Exists(filePath))
            {
                HandleComplete(false, "file not exist!");
                return;
            }

            ExportOne(filePath);
            HandleComplete(true, "export success!");
        }

        private void ExportOne(string xlsxPath)
        {
            Process process = new Process();
// ## 工具路径
//             echo "param1:$1"
// ## 需要导出的excel路径
//             echo "param2:$2"
// ## json文件存放路径
//             echo "param3:$3"
// ## csharp文件存放路径
//             echo "param4:$4"
            var fileName = Path.GetFileNameWithoutExtension(xlsxPath);
            var jsonPath = Path.Combine(jsonSaveDir, fileName + ".json");
            var csharpPath = Path.Combine(csharpSaveDir, fileName + ".cs");
            string shell = "export_xlsx.sh";
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.Arguments = $"{shell} {excel2jsonDir} {xlsxPath} {jsonPath} {csharpPath}";
            process.StartInfo.WorkingDirectory = Path.Combine(Application.dataPath, "AssetsPackage/Editor/ConfigTool");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.OutputDataReceived += new DataReceivedEventHandler((object sender, DataReceivedEventArgs e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Debug.Log(e.Data);
                }
            });
            process.WaitForExit();
            process.Close();

            //修改cs文件
            var lines = File.ReadAllLines(csharpPath);
            var linesList = lines.ToList();
            linesList.Insert(0, "{");
            linesList.Insert(0, "namespace NotionFormulaEditor.Config");
            linesList.Add("}");
            var deleteId = false;
            var modifyClass = false;
            for (var i = 0; i < linesList.Count; i++)
            {
                var line = linesList[i];
                if (!deleteId && line.Contains("public int ID;"))
                {
                    linesList.RemoveAt(i);
                    i--;
                    deleteId = true;
                }

                if (!modifyClass && line.Contains("public class"))
                {
                    line += " : BaseConfig";
                    linesList[i] = line;
                    modifyClass = true;
                }

                if (deleteId && modifyClass)
                {
                    break;
                }
            }

            File.WriteAllLines(csharpPath, linesList.ToArray());
        }

        private void HandleComplete(bool success, string msg)
        {
            EditorUtility.ClearProgressBar();
            EditorUtility.DisplayDialog("ConfigTool", msg, "OK");
        }
    }
}