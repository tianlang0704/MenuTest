-- 开启调试
require("LuaPanda").start("127.0.0.1", 8818)

-- 引用另外一个文件
local localVariableFromAnotherFile = require("AnotherFile")

-- 入口全局变量
Main = {}

-- 按钮路径
local buttonPath = "/Canvas/StartButton"

-- 入口点
function Main.Start()
    -- 找按钮
    local btnGO = CS.UnityEngine.GameObject.Find(buttonPath)
    local btnComp = btnGO:GetComponent(typeof(CS.UnityEngine.UI.Button))
    -- 设置点击回调
    btnComp.onClick:AddListener(Main.StartClick)
    -- 打印一下
    CS.UnityEngine.Debug.Log("Main.Start")
end

function Main.StartClick()
    -- 打印另外一个文件的内容
    CS.UnityEngine.Debug.Log("全局变量a:" .. GlobalVariable.a)
    CS.UnityEngine.Debug.Log("另外一个文件的本地变量a:" .. localVariableFromAnotherFile.a)
end