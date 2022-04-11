using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class GameLauncher : MonoBehaviour
{
    static string luaScriptsFolder = "ScriptsLua";
    LuaEnv luaEnv;
    // Use this for initialization
    void Start()
    {
        InitLuaEnv();
        LoadScript("Main");
        SafeDoString("Main.Start()");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 加载lua脚本
    void LoadScript(string scriptName)
    {
        SafeDoString(string.Format("require('{0}')", scriptName));
    }

    // 运行一段LUA代码
    public void SafeDoString(string scriptContent)
    {
        if (luaEnv != null) {
            try {
                luaEnv.DoString(scriptContent);
            } catch (System.Exception ex) {
                string msg = string.Format("xLua exception : {0}\n {1}", ex.Message, ex.StackTrace);
                Debug.LogError(msg, null);
            }
        }
    }

    // 初始化Lua环境
    void InitLuaEnv()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(CustomLoader);
    }

    // 自定义加载器
    public static byte[] CustomLoader(ref string filepath)
    {
        string scriptPath = string.Empty;
        // 把reuiqre中点.替换成路径中的/
        filepath = filepath.Replace(".", "/") + ".lua";
        // 组合LUA脚本根目录, 在Lua脚本根目录中找对应的lua文件
        scriptPath = Path.Combine(Application.dataPath, luaScriptsFolder);
        scriptPath = Path.Combine(scriptPath, filepath);
        // 读取文件
        return SafeReadAllBytes(scriptPath);
    }

    // 读取文件
    public static byte[] SafeReadAllBytes(string inFile)
    {
        try {
            if (string.IsNullOrEmpty(inFile)) {
                return null;
            }
            if (!File.Exists(inFile)) {
                return null;
            }
            File.SetAttributes(inFile, FileAttributes.Normal);
            return File.ReadAllBytes(inFile);
        } catch (System.Exception ex) {
            Debug.LogError(string.Format("SafeReadAllBytes failed! path = {0} with err = {1}", inFile, ex.Message));
            return null;
        }
    }
}
