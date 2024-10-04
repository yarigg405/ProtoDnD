using Game.DnD;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


namespace Game
{
    internal sealed class CharacterRandomizator : MonoBehaviour
    {
        [SerializeField] private Character[] characters;
        [Space]
        [Space]
        [Space]
        [SerializeField] private CharactersGenerationStorage storage;


        private int GenerateIcon(bool isFemale)
        {
            var number = isFemale ?
                storage.FemaleFaces.GetRandomIndex() :
                storage.MaleFaces.GetRandomIndex();

            return number;
        }

        private int[] GenerateStats()
        {
            int[] stats = new int[6];

            for (int i = 0; i < stats.Length; i++)
            {
                stats[i] = 6;
            }

            int statsPoint = 30;
            while (statsPoint > 0)
            {
                int index = Random.Range(0, stats.Length);
                if (stats[index] < 20)
                {
                    stats[index]++;
                    statsPoint--;
                }
            }

            return stats;
        }

        private int GenerateName(bool isFemale)
        {
            var number = isFemale ?
                storage.FemaleNames.GetRandomIndex() :
                storage.MaleNames.GetRandomIndex();

            return number;
        }

        private int GenerateSurname()
        {
            return
                storage.Surnames.GetRandomIndex();
        }




        [ContextMenu("RegenerateCharacters")]
        public void RegenerateCharacters()
        {
            foreach (var ch in characters)
            {
                RegenerateCharacter(ch);
            }
        }



        private void RegenerateCharacter(Character character)
        {
            if (!character) return;
            if (character.NameIndex < 0)
            {
                var stats = GenerateStats();

                character.Stats = stats;
                character.CurrentHealth = stats[2];

                var isFemale = Random.Range(0f, 1f) < 0.45f;
                var name = GenerateName(isFemale);
                var surname = GenerateSurname();
                var icon = GenerateIcon(isFemale);

                character.IsFemale = isFemale;
                character.NameIndex = name;
                character.SurnameIndex = surname;
                character.IconIndex = icon;
            }


            var visualName =
                    character.IsFemale ?
                    $"{storage.FemaleNames[character.NameIndex]} {storage.Surnames[character.SurnameIndex]}" :
                    $"{storage.MaleNames[character.NameIndex]} {storage.Surnames[character.SurnameIndex]}";

            character.VisualName = visualName;
            character.name = visualName;


            var visualIcon =
                character.IsFemale ?
                storage.FemaleFaces[character.IconIndex] :
                storage.MaleFaces[character.IconIndex];

            character.VisualIcon = visualIcon;

            EditorUtility.SetDirty(character);
        }
    }
}
