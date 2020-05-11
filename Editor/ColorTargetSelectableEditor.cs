using FlexibleUI.Components;
using UnityEditor;
using UnityEngine;

namespace FlexibleUI.Editor
{
    [CustomEditor(typeof(ColorTargetSelectable))]
    public class ColorTargetSelectableEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var targetObj = (ColorTargetSelectable) target;

            var labelN = new GUIContent("NormalColor");
            var labelH = new GUIContent("HighlightedColor");
            var labelP = new GUIContent("PressedColor");
            var labelS = new GUIContent("SelectedColor");
            var labelD = new GUIContent("DisabledColor");
            
            if(targetObj.uiTheme == null)
                return;

            var content = new GUIContent[targetObj.uiTheme.Colors.Length];

            for (int i = 0; i < targetObj.uiTheme.Colors.Length; i++)
            {
                content[i] = new GUIContent(targetObj.uiTheme.Colors[i].name != ""? targetObj.uiTheme.Colors[i].name : "No Name", 
                    Helper.MakeTexture(Helper.textureSize, Helper.textureSize, targetObj.uiTheme.Colors[i].color));
            }

            targetObj.normalColorId = EditorGUILayout.Popup(labelN, targetObj.normalColorId, content);
            targetObj.highlightedColorId = EditorGUILayout.Popup(labelH, targetObj.highlightedColorId, content);
            targetObj.pressedColorId = EditorGUILayout.Popup(labelP, targetObj.pressedColorId, content);
            targetObj.selectedColorId = EditorGUILayout.Popup(labelS, targetObj.selectedColorId, content);
            targetObj.disabledColorId = EditorGUILayout.Popup(labelD, targetObj.disabledColorId, content);
            
            Helper.Colors(targetObj);
            
            if (GUILayout.Button("Save"))
            {
                targetObj.Save();
            }
        }
    }
}