using FlexibleUI.Components;
using UnityEditor;
using UnityEngine;

namespace FlexibleUI.Editor
{
    [CustomEditor(typeof(StyleTMP))]
    public class StyleTMPEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var targetObj = (StyleTMP) target;
            
            if(targetObj.uiTheme == null)
                return;

            var contents = new GUIContent[targetObj.uiTheme.TMPStyles.Length];

            for (int i = 0; i < targetObj.uiTheme.TMPStyles.Length; i++)
            {
                contents[i] =
                    new GUIContent(
                        $"{(targetObj.uiTheme.TMPStyles[i].name != "" ? targetObj.uiTheme.TMPStyles[i].name : "No name")}");
            }

            EditorGUILayout.BeginHorizontal();
            targetObj.tmpStyleId = Helper.ToggleList(targetObj.tmpStyleId, contents);
            EditorGUILayout.EndHorizontal();
            targetObj.OnSkinUI();
        }
    }
}