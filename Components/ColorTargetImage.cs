using UnityEngine;
using UnityEngine.UI;

namespace FlexibleUI.Components
{
    [RequireComponent(typeof(Image))]
    public class ColorTargetImage : FlexibleUIBase
    {
        [SerializeField] private Image m_Image;
        
        public override void OnSkinUI()
        {
            base.OnSkinUI();
            if (m_Image == null)
                m_Image = GetComponent<Image>();
            
            if(m_Image == null)
                return;

            if (uiTheme == null || uiTheme != GetTheme(ThemeName))
                uiTheme = GetTheme(ThemeName);

            if(uiTheme == null)
                return;
            
            uiTheme = GetTheme(ThemeName);

            if (elementId > uiTheme.Colors.Length - 1)
                return; 

            m_Image.color = uiTheme.Colors[elementId].color;
        }
    }
}