#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace InnovamatTechnicalChallenge.ConfigurationObjects
{
    [CustomEditor(typeof(NumberToTextSpanish))]
    public class NumberToTextSpanishEditor : Editor
    {
        [Min(0)]
        private int numberToTest = 0;
        private string result = "sasa";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Test a number");

            numberToTest = EditorGUILayout.IntField(numberToTest);
            GUILayout.EndHorizontal();
            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Test"))
            {
                NumberToTextSpanish numberToText = (target as NumberToTextSpanish);

                result = numberToText.GetTextFromNumber(numberToTest);
            }
            if (GUILayout.Button("Test Random"))
            {
                NumberToTextSpanish numberToText = (target as NumberToTextSpanish);

                numberToTest = Random.Range(0, 999999);
                result = numberToText.GetTextFromNumber(numberToTest);
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Result : " + result);
            GUILayout.EndHorizontal();
        }
    }
}
#endif
