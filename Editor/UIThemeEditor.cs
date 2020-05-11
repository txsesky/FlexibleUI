using FlexibleUI.ScriptableObjects;
using UnityEditor;

namespace FlexibleUI.Editor
{
    [CustomEditor(typeof(UITheme))]
    public class UIThemeEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}