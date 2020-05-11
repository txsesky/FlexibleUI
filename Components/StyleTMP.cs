using TMPro;
using UnityEngine;

namespace FlexibleUI.Components
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class StyleTMP : FlexibleUIBase
    {
        private TextMeshProUGUI _textMeshPro;
        [HideInInspector] public int tmpStyleId;
        
        public override void OnSkinUI()
        {
            base.OnSkinUI();

            if (_textMeshPro == null)
                _textMeshPro = GetComponent<TextMeshProUGUI>();

            if (_textMeshPro == null)
                return;

            if (uiTheme == null || uiTheme != GetTheme(ThemeName))
                uiTheme = GetTheme(ThemeName);

            if (uiTheme == null)
                return;

            if (tmpStyleId > uiTheme.TMPStyles.Length - 1)
                return;

            if (tmpStyleId < 0)
                return;

            _textMeshPro.font = uiTheme.TMPStyles[tmpStyleId].font;
            _textMeshPro.fontSize = uiTheme.TMPStyles[tmpStyleId].size;
            _textMeshPro.color = uiTheme.TMPStyles[tmpStyleId].color;
        }
    }
}