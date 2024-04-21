using System;
using UnityEngine;
using Yrr.Utils;


namespace Game.DnD
{

    [CreateAssetMenu(fileName = "NewCharacter", menuName = "Characters/Character", order = 51)]
    [System.Serializable]
    internal sealed class Character : ScriptableObject
    {
        public bool IsFemale;
        public int NameIndex = -1;
        public int SurnameIndex;
        public int IconIndex;
        public int[] Stats;

        public int CurrentHealth;


        [Space]
        [Space]

        public string VisualName;

        [ReadOnly]
        public Sprite VisualIcon;
        [Header("Заметки, описание")]
        [TextArea]
        [SerializeField] private string notes;

        internal string Description => notes;


        internal int GetStatBonus(CharacterStats stat)
        {
            var value = Stats[(int)stat];

            return GetStatBonus(value);
        }

        private int GetStatBonus(int statValue)
        {
            var modificator = (int)Math.Floor((statValue - 10) / 2d);
            return modificator;
        }

    }
}
