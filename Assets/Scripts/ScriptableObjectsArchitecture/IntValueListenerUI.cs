using InnovamatTechnicalChallenge.SOArchitecture;
using UnityEngine;
using UnityEngine.UI;

public class IntValueListenerUI : MonoBehaviour
{
    public IntValue value;

    public Text textValue;

    private void OnEnable()
    {
        value.OnValueChange += Updatetext;

        Updatetext();
    }

    private void Updatetext()
    {
        textValue.text = value.RuntimeValue.ToString();
    }

    private void OnDisable()
    {
        value.OnValueChange -= Updatetext;
    }
}
