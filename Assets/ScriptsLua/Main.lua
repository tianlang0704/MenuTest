Main = {}

local buttonPath = "/Canvas/StartButton"

function Main.Start()
    local btnGO = CS.UnityEngine.GameObject.Find(buttonPath)
    local btnComp = btnGO:GetComponent(typeof(CS.UnityEngine.UI.Button))
    btnComp.onClick:AddListener(Main.StartClick)
    CS.UnityEngine.Debug.Log("Main.Start")
end

function Main.StartClick()
    CS.UnityEngine.Debug.Log("开始点击")
end