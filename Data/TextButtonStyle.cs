using System;
using TMPro;
using UnityEngine;

namespace FlexibleUI.Data
{
    [Serializable]
    public struct TextButtonStyle
    {
        public string name;
        [Header("Normal")]
        public Color backgroundColor;
        public Color color;
        [Header("Hover")]
        public Color hoverBackgroundColor;
        public Color hoverColor;
        [Header("Active")]
        public Color activeBackgroundColor;
        public Color activeColor;
        [Header("Font")]
        public TMP_FontAsset font;
        public float size;
    }
}