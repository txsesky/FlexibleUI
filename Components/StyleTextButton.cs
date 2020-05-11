using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FlexibleUI.Components
{
    public class StyleTextButton : FlexibleUIBase, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public Image[] images;
        public TextMeshProUGUI[] texts;

        [SerializeField] private int _styleId = 0;

        private Color _backgroundColor;
        private Color _color;
        
        private Color _hoverBackgroundColor;
        private Color _hoverColor;
        
        private Color _activeBackgroundColor;
        private Color _activeColor;

        public override void OnSkinUI()
        {
            base.OnSkinUI();
            
            if(texts == null || images == null)
                return;
            
            if(texts.Length == 0 || images.Length == 0)
                return;

            if (uiTheme == null || uiTheme != GetTheme(ThemeName))
                uiTheme = GetTheme(ThemeName);

            if (uiTheme == null)
                return;

            if (_styleId > uiTheme.TMPStyles.Length - 1)
                return;

            if (_styleId < 0)
                return;

            _backgroundColor = uiTheme.TextButtonStyles[_styleId].backgroundColor;
            _color = uiTheme.TextButtonStyles[_styleId].color;
            
            _hoverBackgroundColor = uiTheme.TextButtonStyles[_styleId].hoverBackgroundColor;
            _hoverColor = uiTheme.TextButtonStyles[_styleId].hoverColor;
            
            _activeBackgroundColor = uiTheme.TextButtonStyles[_styleId].activeBackgroundColor;
            _activeColor = uiTheme.TextButtonStyles[_styleId].activeColor;
            
            var textsCount = texts.Length;
            for (var i = 0; i < textsCount; i++)
            {
                if(texts[i] == null)
                    continue;
                texts[i].font = uiTheme.TextButtonStyles[_styleId].font;
                texts[i].fontSize = uiTheme.TextButtonStyles[_styleId].size;
                texts[i].color = uiTheme.TextButtonStyles[_styleId].color;
            }

            var imagesCount = images.Length;
            for (var i = 0; i < imagesCount; i++)
            {
                if(images[i] == null)
                    continue;
                images[i].color = uiTheme.TextButtonStyles[_styleId].backgroundColor;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            SetColors(in _hoverBackgroundColor, in _hoverColor);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            SetColors(in _backgroundColor, in _color);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SetColors(in _activeBackgroundColor, in _activeColor);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            SetColors(in _backgroundColor, in _color);
        }
    
        private void SetColors(in Color imagesColor, in Color textsColor)
        {
            var imagesCount = images.Length;
            for (var i = 0; i < imagesCount; i++)
            {
                images[i].color = imagesColor;
            }

            var textsCount = texts.Length;
            for (var i = 0; i < textsCount; i++)
            {
                texts[i].color = textsColor;
            }
        }
    }
}