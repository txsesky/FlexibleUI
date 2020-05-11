using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace FlexibleUI.Data
{
    [Serializable]
    public struct NamedSprite
    {
        public string name;
        [FormerlySerializedAs("image")] public Texture2D sprite;
    }
}