using System;
using System.IO;
using FlexibleUI.ScriptableObjects;
using UnityEngine;

namespace FlexibleUI
{
    [ExecuteInEditMode]
    public class FlexibleUIBase : MonoBehaviour
    {
        public UITheme uiTheme;
        protected string ThemeName;

        private event Action OnSkinUiUpdate;

        private const string DARK_THEME_NAME = "DarkTheme";
        private const string LIGHT_THEME_NAME = "LightTheme";

        [HideInInspector] public int elementId;
        [HideInInspector] public int sortedElementId = -1;

        private int _oldElementId;
        private int _oldColorsLength = -1;
        private int _oldSortedElementId = -1;
        
#if UNITY_EDITOR
        private void OnEnable()
        {
            if (!Application.isPlaying)
            {
                OnSkinUiUpdate += OnSkinUI;
                if (OnSkinUiUpdate != null) UnityEditor.EditorApplication.update += OnSkinUiUpdate.Invoke;
            }
        }
        
        private void OnDisable()
        {
            OnSkinUiUpdate -= OnSkinUI;
        }
        
        public void Save()
        {
            var prefabStage = UnityEditor.Experimental.SceneManagement.PrefabStageUtility.GetPrefabStage(gameObject);
            if (prefabStage != null)
            {
                UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(prefabStage.scene);
            }
        }
#endif

        private void OnValidate()
        {
            OnSkinUI();
        }
        
        private void Awake()
        {
            OnSkinUI();
        }

        public virtual void OnSkinUI()
        {
            ThemeName = DARK_THEME_NAME;
            
            if(uiTheme == null)
                return;
            
            if (_oldColorsLength != uiTheme.Colors.Length || sortedElementId == -1)
            {
                _oldColorsLength = uiTheme.Colors.Length;
                sortedElementId = GetSortedId();
                _oldSortedElementId = sortedElementId;
            }
            else
            {
                if (_oldSortedElementId != sortedElementId)
                {
                    elementId = GetSourceId();
                    _oldSortedElementId = sortedElementId;
                }
            }
            
            sortedElementId = GetSortedId();

            if (_oldElementId == elementId) return;
            _oldElementId = elementId;
#if UNITY_EDITOR
            Save();
#endif
        }

        private int GetSortedId()
        {
            if (uiTheme == null)
                return -1;

            return uiTheme.SortDictionary().IndexOf(elementId);
        }

        private int GetSourceId()
        {
            if (uiTheme == null)
                return elementId;

            return (int)uiTheme.SortDictionary()[sortedElementId];
        }

        protected UITheme GetTheme(string name)
        {
            return Resources.Load<UITheme>(Path.Combine("Styles", name)) != null ? Resources.Load<UITheme>(Path.Combine("Styles", name)) : null;
        }

    }
}
