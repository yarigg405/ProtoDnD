using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yrr.UI;
using Game.DnD;
using System;


namespace Game
{
    internal sealed class CharactersScreen : UIScreen
    {
        [SerializeField] private Character character;

        [Space]
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI nameTmp;
        [SerializeField] private TextMeshProUGUI descriptionTmp;

        [Header("Stats")]
        [SerializeField] private TextMeshProUGUI StrTmp;
        [SerializeField] private TextMeshProUGUI AgiTmp;
        [SerializeField] private TextMeshProUGUI HpTmp;

        [SerializeField] private TextMeshProUGUI IntTmp;
        [SerializeField] private TextMeshProUGUI WisTmp;
        [SerializeField] private TextMeshProUGUI ChaTmp;




        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (!character) return;

            icon.sprite = character.VisualIcon;
            nameTmp.text = character.VisualName;
            descriptionTmp.text = character.Description;

            StrTmp.text = $"Сила \t{GetStatBonusText(character.Stats[0])}";
            AgiTmp.text = $"Ловк \t{GetStatBonusText(character.Stats[1])}";
            HpTmp.text = $"{character.CurrentHealth}/{character.Stats[2]}";
            IntTmp.text = $"Инт \t{GetStatBonusText(character.Stats[3])}";
            WisTmp.text = $"Мдр \t{GetStatBonusText(character.Stats[4])}";
            ChaTmp.text = $"Хар \t{GetStatBonusText(character.Stats[5])}";
        }

        private string GetStatBonusText(int stat)
        {
            var modificator = GetStatBonus(stat);
            return " (" + (modificator < 0 ? modificator + ")" : ("+" + modificator) + ")");
        }

        private int GetStatBonus(int statValue)
        {
            var modificator = (int)Math.Floor((statValue - 10) / 2d);
            return modificator;
        }


        private void OnValidate()
        {
            Refresh();
        }
    }
}
