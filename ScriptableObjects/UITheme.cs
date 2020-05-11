using System;
using System.Collections.Generic;
using FlexibleUI.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace FlexibleUI.ScriptableObjects
{
    [CreateAssetMenu(menuName = "FlexibleUITheme")]
    public class UITheme : ScriptableObject
    {
        [SerializeField] private NamedColor[] colors;
        [SerializeField] private TMPStyle[] tmpStyles;
        [SerializeField] private TextButtonStyle[] textButtonStyles;
        [SerializeField] private NamedSprite[] sprites;

        public NamedColor[] Colors => colors;
        public TMPStyle[] TMPStyles => tmpStyles;
        public TextButtonStyle[] TextButtonStyles => textButtonStyles;
        public NamedSprite[] Sprites => sprites;

        public List<object> SortDictionary()
        {
            //Create the data we want to sort.
            //In the data below, we are saying that "B corresponds to 21", "F corresponds to 43" and so on.
            //Normally, you would probably be feeding this data from somewhere else in your program.
            List<string> Keys = new List<string>();
            List<object> Values = new List<object>();

            for (int i = 0; i < colors.Length; i++)
            {
                Keys.Add(colors[i].name);
                Values.Add(i);
            }

            //Declare new dictionary, where the key is a string and the corresponding data is an object
            var dict = new Dictionary<string, object>();
            //populate dictionary with data created above
            for (int i = 0; i < Keys.Count; i++)
            {
                if (dict.ContainsKey(Keys[i]))
                {
                    colors[i].name += "+";
                    Keys[i] = colors[i].name;
                }

                dict.Add(Keys[i], Values[i]);
            }

            //Separately, sort our keys into alphabetical order
            //You need your keys in their own list. You may need to create this yourself if you don't already have it.
            Keys.Sort();

            //Now look up our dictionary according to our sorted keys
            List<object> sortedVals = new List<object>();
            for (int i = 0; i < Keys.Count; i++)
            {
                sortedVals.Add(dict[Keys[i]]);
            }

            return sortedVals;
        }

        public Color GetColorById(int id)
        {
            return colors[(int) SortDictionary()[id]].color;
        }
    }
}