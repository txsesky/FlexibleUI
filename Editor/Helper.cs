using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FlexibleUI.Components;
using FlexibleUI.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace FlexibleUI.Editor
{
    public static class Helper
    {
        public static int textureSize = 20;
        public static Texture2D MakeTexture(int width, int height, Color col)
        {
            var alpha = Mathf.RoundToInt(col.a * width);

            col.a = 1;

            var alphaWidth = width / 5;

            var pix = new List<Color>();
            
            for (int i = 0; i < width * (height - alphaWidth); ++i)
            {
                pix.Add(col);
            }

            Color[][] pixA = new Color[alphaWidth][];

            for (int i = 0; i < pixA.Length; i++)
            {
                pixA[i] = new Color[width];

                for (int j = 0; j < pixA[i].Length - alpha; j++)
                {
                    pixA[i][j] = Color.black;
                }

                for (int j = pixA[i].Length - alpha; j < pixA[i].Length; j++)
                {
                    pixA[i][j] = Color.white;
                }
            }

            for (int i = 0; i < pixA.Length; i++)
            {
                for (int j = 0; j < pixA[i].Length; j++)
                {
                    pix.Add(pixA[i][j]);
                }
            }

            pix.Reverse();
            
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix.ToArray());
            result.Apply();
            return result;
        }
        
        public static int ToggleList(int selected, GUIContent[] items)
        {
            // Keep the selected index within the bounds of the items array
            selected = selected < 0 ? 0 : selected >= items.Length ? items.Length - 1 : selected;
 
            GUILayout.BeginVertical();
            for (int i = 0; i < items.Length; i++)
            {
                // Display toggle. Get if toggle changed.
                bool change = GUILayout.Toggle(selected == i, items[i]);
                // If changed, set selected to current index.
                if (change)
                    selected = i;
            }
            GUILayout.EndVertical();
 
            // Return the currently selected item's index
            return selected;
        }

        public static GUIStyle GetStyle()
        {
            var style = new GUIStyle();
            style.fixedHeight = textureSize + 4;
            style.fixedWidth = style.fixedHeight;
            style.alignment = TextAnchor.MiddleLeft;
            return style;
        }
        
        public static void Colors(FlexibleUIBase targetObj)
        {
            if(targetObj.uiTheme == null)
                return;
            Texture[] colors = new Texture[targetObj.uiTheme.Colors.Length];
            string[] colorNames = new String[targetObj.uiTheme.Colors.Length];

            var listId = targetObj.uiTheme.SortDictionary();
            
            for (int i = 0; i < targetObj.uiTheme.Colors.Length; i++)
            {
                colors[i] = MakeTexture(Helper.textureSize, Helper.textureSize,
                    targetObj.uiTheme.Colors[(int)listId[i]].color);
                colorNames[i] = targetObj.uiTheme.Colors[(int)listId[i]].name != ""
                    ? targetObj.uiTheme.Colors[(int)listId[i]].name
                    : "No name";
            }
            
            EditorGUILayout.BeginHorizontal();
            targetObj.sortedElementId = GUILayout.SelectionGrid(targetObj.sortedElementId, colors, 1, GetStyle());
            targetObj.sortedElementId = GUILayout.SelectionGrid(targetObj.sortedElementId, colorNames, 1, GetStyle());
            EditorGUILayout.EndHorizontal();
            targetObj.OnSkinUI();
        }
    }
}