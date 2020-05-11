using System;
using FlexibleUI.Components;
using UnityEditor;
using UnityEngine;

namespace FlexibleUI.Editor
{
    [CustomEditor(typeof(ColorTargetImage))]
    public class ColorTargetImageEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var targetObj = (ColorTargetImage) target;

            Helper.Colors(targetObj);
        }
    }
}