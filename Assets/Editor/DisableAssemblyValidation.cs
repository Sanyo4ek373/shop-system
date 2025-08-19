#if UNITY_EDITOR
using UnityEditor;

[InitializeOnLoad]
public static class DisableAssemblyVersionValidation
{
    [System.Obsolete]
    static DisableAssemblyVersionValidation()
    {
        PlayerSettings.assemblyVersionValidation = false;
    }
}
#endif