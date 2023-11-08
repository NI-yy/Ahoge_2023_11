using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    public InputField inputField;
    // Update is called once per frame
    void Update()
    {
        EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
        inputField.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    public string getText()
    {
        return inputField.text;
    }
}
