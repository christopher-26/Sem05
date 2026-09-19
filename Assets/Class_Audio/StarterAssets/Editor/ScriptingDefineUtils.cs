using UnityEditor;
using UnityEditor.Build;

namespace StarterAssets
{
    public static class ScriptingDefineUtils
    {
        public static bool CheckScriptingDefine(string scriptingDefine)
        {
            NamedBuildTarget namedBuildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var defines = PlayerSettings.GetScriptingDefineSymbols(namedBuildTarget);

            return defines.Contains(scriptingDefine);
        }

        public static void SetScriptingDefine(string scriptingDefine)
        {
            NamedBuildTarget namedBuildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var defines = PlayerSettings.GetScriptingDefineSymbols(namedBuildTarget);
            if (!defines.Contains(scriptingDefine))
            {
                defines += $";{scriptingDefine}";
                PlayerSettings.SetScriptingDefineSymbols(namedBuildTarget, defines);
            }
        }

        public static void RemoveScriptingDefine(string scriptingDefine)
        {
            NamedBuildTarget namedBuildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var defines = PlayerSettings.GetScriptingDefineSymbols(namedBuildTarget);
            if (defines.Contains(scriptingDefine))
            {
                string newDefines = defines.Replace(scriptingDefine, "");
                PlayerSettings.SetScriptingDefineSymbols(namedBuildTarget, newDefines);
            }
        }
    }
}