local localVariableFromAnotherFile = require("AnotherFile")

Main = {}

local buttonPath = "/Canvas/StartButton"

function Main.Start()
    local btnGO = CS.UnityEngine.GameObject.Find(buttonPath)
    local btnComp = btnGO:GetComponent(typeof(CS.UnityEngine.UI.Button))
    btnComp.onClick:AddListener(Main.StartClick)
    CS.UnityEngine.Debug.Log("Main.Start")
end

function Main.StartClick()
    CS.UnityEngine.Debug.Log("全局变量a:" .. GlobalVariable.a)
    CS.UnityEngine.Debug.Log("另外一个文件的本地变量a:" .. localVariableFromAnotherFile.a)
end