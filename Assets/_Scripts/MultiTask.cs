using Game.DnD;
using UnityEngine;


namespace Game
{
    internal sealed class MultiTask : MonoBehaviour
    {
        [TextArea(5, 7)]
        [SerializeField] private string description;


        [Space]
        [SerializeField] private Character[] employees;
        [SerializeField] public CharacterStats checkStat;
        [SerializeField] public int difficult = 10;
        [SerializeField] public int targetCount = 100;
        [SerializeField] private TaskCheckMode checkMode;


        [ContextMenu("Check")]
        public void CheckTask()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Character character = employees[i];
                CheckEmployee(character);
            }
        }

        private void CheckEmployee(Character character)
        {
            var value = Random.Range(1, 21);
            if (checkMode == TaskCheckMode.Buff)
            {
                var secondValue = Random.Range(1, 21);
                Debug.Log($"{value} : {secondValue}");
                value = Mathf.Max(value, secondValue);
            }

            if (checkMode == TaskCheckMode.Debuff)
            {
                var secondValue = Random.Range(1, 21);
                Debug.Log($"{value} : {secondValue}");
                value = Mathf.Min(value, secondValue);
            }



            var modifier = character.GetStatBonus(checkStat);

            var result = value + modifier;
            var changeValue = Random.Range(1, 21) + modifier;


            var resultString = $"Dice result is: {value}. Result is: {result}. ";

            if (value == 20)
            {
                resultString += "<color=#39A439>CRITICAL SUCCESS!!</color>";
                targetCount -= changeValue;
            }

            else if (value == 1)
            {
                resultString += "<color=red>CRITICAL FAILIRE!!</color>";

                targetCount += result;
                targetCount += changeValue;
            }

            else if (result >= difficult)
            {
                resultString += "<color=#39A439>Success!!</color>";
                targetCount -= changeValue;
            }

            else
            {
                resultString += "<color=red>Failure!!</color>";
            }

            Debug.Log(resultString);
        }
    }
}
