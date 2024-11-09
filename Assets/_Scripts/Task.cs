using Game.DnD;
using UnityEngine;
using UnityEngine.Events;


namespace Game
{
    internal sealed class Task : MonoBehaviour
    {
        [TextArea(5, 7)]
        [SerializeField] private string description;


        [Space]
        [SerializeField] private Character character;
        [SerializeField] private CharacterStats checkStat;
        [SerializeField] private int difficult = 10;
        [SerializeField] private TaskCheckMode checkMode;

        [SerializeField] private MultiTaskGenerator generator;


        [ContextMenu("Check")]
        public void CheckTask()
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





            var resultString = $"Dice result is: {value}. Result is: {result}. ";

            if (value == 20)
            {
                resultString += "<color=#39A439>CRITICAL SUCCESS!!</color>";
                Success();
            }

            else if (value == 1)
            {
                resultString += "<color=red>CRITICAL FAILIRE!!</color>";
            }

            else if (result >= difficult)
            {
                resultString += "<color=#39A439>Success!!</color>";
                Success();
            }

            else
            {
                resultString += "<color=red>Failure!!</color>";
            }

            Debug.Log(resultString);
        }

        private void Success()
        {
            if (generator)
                generator.GenerateMultitask();
        }
    }

    [System.Serializable]
    internal struct TaskEvents
    {
        public UnityEvent OnSuccess;
        public UnityEvent OnCriticalSuccess;
        public UnityEvent OnFail;
        public UnityEvent OnCriticalFail;
    }

    [System.Serializable]
    internal enum TaskCheckMode
    {
        Normal,
        Buff,
        Debuff,
    }
}
