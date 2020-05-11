using System;
using TMPro;
using UnityEngine;

namespace FlexibleUI.Data
{
    [Serializable]
    public struct TMPStyle
    {
        public string name;
        public TMP_FontAsset font;
        public float size;
        public Color color;
    }
}