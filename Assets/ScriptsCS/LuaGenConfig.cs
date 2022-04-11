using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XLua;

public static class GameGenConfig
{
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>() {
        typeof(Debug),
        // unity
        typeof(Application),
        typeof(System.Object),
        typeof(UnityEngine.Object),
        typeof(Ray2D),
        typeof(GameObject),
        typeof(Component),
        typeof(Behaviour),
        typeof(Transform),
        typeof(Resources),
        typeof(TextAsset),
        typeof(Keyframe),
        typeof(AnimationCurve),
        typeof(AnimationClip),
        typeof(MonoBehaviour),
        typeof(ParticleSystem),
        typeof(SkinnedMeshRenderer),
        typeof(Renderer),
        typeof(WWW),
        typeof(List<int>),
        typeof(Action<string>),
        typeof(Action<LuaTable>),
        typeof(UnityEngine.Debug),
        typeof(Delegate),
        // typeof(Dictionary<string, GameObject>),
        typeof(UnityEngine.Events.UnityEvent),
        typeof(Camera),
        typeof(Animator),
        typeof(Animation),
        typeof(Screen),

        // unity结合lua，这部分导出很多功能在lua侧重新实现，没有实现的功能才会跑到cs侧
        typeof(Bounds),
        typeof(Color),
        typeof(LayerMask),
        typeof(Mathf),
        typeof(Plane),
        typeof(Quaternion),
        typeof(Ray),
        typeof(RaycastHit),
        typeof(Time),
        typeof(Touch),
        typeof(TouchPhase),
        typeof(Vector2),
        typeof(Vector3),
        typeof(Vector4),

        // 渲染
        typeof(RenderMode),
        typeof(Material),

        // UGUI  
        typeof(UnityEngine.Canvas),
        typeof(UnityEngine.Rect),
        typeof(UnityEngine.RectTransform),
        typeof(UnityEngine.RectTransformUtility),
        typeof(UnityEngine.RectOffset),
        typeof(UnityEngine.Sprite),
        typeof(UnityEngine.SpriteRenderer),
        typeof(UnityEngine.UI.CanvasScaler),
        typeof(UnityEngine.UI.CanvasScaler.ScaleMode),
        typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode),
        typeof(UnityEngine.UI.GraphicRaycaster),
        typeof(UnityEngine.UI.Text),
        typeof(UnityEngine.UI.InputField),
        typeof(UnityEngine.UI.Button),
        typeof(UnityEngine.UI.Image),
        typeof(UnityEngine.UI.ScrollRect),
        typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent),

        typeof(UnityEngine.UI.Scrollbar),
        typeof(UnityEngine.UI.Toggle),
        typeof(UnityEngine.UI.Toggle.ToggleEvent),
        typeof(UnityEngine.UI.ToggleGroup),
        typeof(UnityEngine.UI.Button.ButtonClickedEvent),
        typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent),
        typeof(UnityEngine.UI.GridLayoutGroup),
        typeof(UnityEngine.UI.LayoutGroup),
        typeof(UnityEngine.UI.ContentSizeFitter),
        typeof(UnityEngine.UI.Slider),

        // 场景、资源加载
        typeof(UnityEngine.Resources),
        typeof(UnityEngine.ResourceRequest),
        typeof(UnityEngine.SceneManagement.SceneManager),

        // 其它
        typeof(PlayerPrefs),
        typeof(System.GC),
        typeof(UnityEngine.EventSystems.EventSystem),
        typeof(UnityEngine.GridLayout),
        //Physics
        typeof(UnityEngine.Physics),
        typeof(UnityEngine.Rigidbody),
        typeof(UnityEngine.Collider),
        typeof(UnityEngine.CapsuleCollider),
        typeof(UnityEngine.BoxCollider),
        typeof(UnityEngine.SphereCollider),
        typeof(UnityEngine.Physics2D),
        typeof(UnityEngine.Rigidbody2D),
        typeof(UnityEngine.RigidbodyConstraints),
        // 动画
        typeof(UnityEngine.Animator),
        typeof(UnityEngine.Animation),
        typeof(UnityEngine.AnimatorStateInfo),
        // 
        //ScriptBehaviour
        typeof(Collision2D),
        typeof(Collider2D),
        // Logger
        typeof(Logger),
        // TextMesh
        typeof(TextMesh),
        // dropdown
        typeof(UnityEngine.UI.Dropdown),
        typeof(UnityEngine.UI.Dropdown.OptionData),
        typeof(List<UnityEngine.UI.Dropdown.OptionData>),
    };
  //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>() {
        // unity
        typeof(Action),
        typeof(Action<float, float>),
        typeof(Action<String>),
        typeof(Action<int>),
        typeof(Action<bool>),
        typeof(Action<WWW>),
        typeof(UnityEngine.Event),
        typeof(UnityEngine.Events.UnityAction),
        typeof(System.Collections.IEnumerator),
        typeof(UnityEngine.Events.UnityAction<Vector2>),
        typeof(Action<Transform, int>),
        typeof(Action<string, float>),
    };
    // 避免在IL2CPP下被裁剪
    [ReflectionUse]
    public static List<Type> ReflectionUse = new List<Type>(){
        typeof(AsyncOperation),
    };
    	//黑名单
	[BlackList]
	public static List<List<string>> BlackList = new List<List<string>>()  {
		// unity
		new List<string>(){"UnityEngine.WWW", "movie"},
		new List<string>(){"UnityEngine.Texture2D", "alphaIsTransparency"},
        new List<string>(){"UnityEngine.WWW", "GetMovieTexture"},
        new List<string>(){"UnityEngine.Texture2D", "alphaIsTransparency"},
		new List<string>(){"UnityEngine.Security", "GetChainOfTrustValue"},
		new List<string>(){"UnityEngine.CanvasRenderer", "onRequestRebuild"},
		new List<string>(){"UnityEngine.Light", "areaSize"},
		new List<string>(){"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
#if !UNITY_WEBPLAYER
		new List<string>(){"UnityEngine.Application", "ExternalEval"},
#endif
// Unity2019已经去掉了这几个接口
#if UNITY_2019_1_OR_NEWER
        new List<string>(){"UnityEngine.Camera", "FocalLengthToFOV"},
        new List<string>(){"UnityEngine.Camera", "FOVToFocalLength"},

#endif
		new List<string>(){"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
		new List<string>(){"UnityEngine.Component", "networkView"},  //4.6.2 not support
		new List<string>(){"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
		new List<string>(){"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
		new List<string>(){"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
		new List<string>(){"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
		new List<string>(){"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
		new List<string>(){"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
		new List<string>(){"UnityEngine.MonoBehaviour", "runInEditMode"},
		new List<string>(){"UnityEngine.UI.Text", "OnRebuildRequested"},
        new List<string>(){"System.Type", "IsSZArray"},
        new List<string>(){"UnityEngine.Tilemaps.Tilemap", "GetEditorPreviewTile",
                                                           "SetEditorPreviewTile",
                                                           "HasEditorPreviewTile",
                                                           "GetEditorPreviewSprite",
                                                           "GetEditorPreviewTransformMatrix",
                                                           "SetEditorPreviewTransformMatrix",
                                                           "GetEditorPreviewColor",
                                                           "SetEditorPreviewColor",
                                                           "GetEditorPreviewTileFlags",
                                                           "EditorPreviewFloodFill",
                                                           "EditorPreviewBoxFill",
                                                           "ClearAllEditorPreviewTiles",
                                                           "editorPreviewOrigin",
                                                           "editorPreviewSize"},
        new List<string>() {"UnityEngine.Camera",   "FocalLengthToFOV",
                                                    "FOVToFocalLength"}
	};
#if UNITY_2018_1_OR_NEWER
    [BlackList]
    public static Func<MemberInfo, bool> MethodFilter = (memberInfo) =>
    {
        if (memberInfo.ReflectedType == typeof(UnityEngine.Tilemaps.Tilemap))
        {
            if (memberInfo.MemberType == MemberTypes.Constructor)
            {
                ConstructorInfo constructorInfo = memberInfo as ConstructorInfo;
                var parameterInfos = constructorInfo.GetParameters();
                if (parameterInfos.Length > 0)
                {
                    if (typeof(System.Collections.IEnumerable).IsAssignableFrom(parameterInfos[0].ParameterType))
                    {
                        return true;
                    }
                }
            }
            else if (memberInfo.MemberType == MemberTypes.Method)
            {
                //
                var methodInfo = memberInfo as MethodInfo;
                foreach (List<string> black in BlackList)
                {
                    if (black[0] == "UnityEngine.Tilemaps.Tilemap")
                    {
                        foreach (string methodName in black)
                        {
                            if (methodInfo.Name == methodName)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            else if (memberInfo.MemberType == MemberTypes.Property)
            {
                var propertyInfo = memberInfo as PropertyInfo;
                foreach (List<string> black in BlackList)
                {
                    if (black[0] == "UnityEngine.Tilemaps.Tilemap")
                    {
                        foreach (string methodName in black)
                        {
                            if (propertyInfo.Name == methodName)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    };
#endif
}