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

            gameObject.name = character.name;

            icon.sprite = character.VisualIcon;
            nameTmp.text = character.VisualName;
            descriptionTmp.text = character.Description;

            StrTmp.text = $"Сила \t{GetStatBonusText(CharacterStats.Strength)}";
            AgiTmp.text = $"Ловк \t{GetStatBonusText(CharacterStats.Agility)}";
            HpTmp.text = $"{character.CurrentHealth}/{character.Stats[2]}";
            IntTmp.text = $"Инт \t{GetStatBonusText(CharacterStats.Intelligence)}";
            WisTmp.text = $"Мдр \t{GetStatBonusText(CharacterStats.Wisdom)}";
            ChaTmp.text = $"Хар \t{GetStatBonusText(CharacterStats.Charisma)}";
        }

        private string GetStatBonusText(CharacterStats stat)
        {
            var modificator = character.GetStatBonus(stat);
            return " (" + (modificator < 0 ? modificator + ")" : ("+" + modificator) + ")");
        }

        private void OnValidate()
        {
            Refresh();
        }
    }
}
