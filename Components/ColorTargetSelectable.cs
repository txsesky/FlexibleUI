using UnityEngine;
using UnityEngine.UI;

namespace FlexibleUI.Components
{
    [RequireComponent(typeof(Selectable))]
    public class ColorTargetSelectable : FlexibleUIBase
    {
        [SerializeField] private Selectable m_Selectable;
        
        [HideInInspector] public int normalColorId;
        [HideInInspector] public int highlightedColorId;
        [HideInInspector] public int pressedColorId;
        [HideInInspector] public int selectedColorId;
        [HideInInspector] public int disabledColorId;

        public override void OnSkinUI()
        {
            base.OnSkinUI();
            if (m_Selectable == null)
                m_Selectable = GetComponent<Selectable>();
            
            if(m_Selectable == null)
                return;

            if (uiTheme == null || uiTheme != GetTheme(ThemeName))
                uiTheme = GetTheme(ThemeName);

            if(uiTheme == null)
                return;

            if (normalColorId > uiTheme.Colors.Length - 1)
                return;
            if (highlightedColorId > uiTheme.Colors.Length - 1)
                return;
            if (pressedColorId > uiTheme.Colors.Length - 1)
                return;
            if (selectedColorId > uiTheme.Colors.Length - 1)
                return;
            if (disabledColorId > uiTheme.Colors.Length - 1)
                return;


            var selectableColors = m_Selectable.colors;
            selectableColors.normalColor = uiTheme.Colors[normalColorId].color;
            selectableColors.highlightedColor = uiTheme.Colors[highlightedColorId].color;
            selectableColors.pressedColor = uiTheme.Colors[pressedColorId].color;
            selectableColors.selectedColor = uiTheme.Colors[selectedColorId].color;
            selectableColors.disabledColor = uiTheme.Colors[disabledColorId].color;
            m_Selectable.colors = selectableColors;

        }
    }
}