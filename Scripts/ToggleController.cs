using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ToggleController : MonoBehaviour
{
    ToggleOption[] options => GetComponentsInChildren<ToggleOption>();

    [SerializeField] Color selectedColor;
    [SerializeField] Color deselectedColor;

    public UnityEvent<string> onParameterSet;

    private void OnEnable()
    {
        foreach (ToggleOption option in options)
            option.onCustomPoke.AddListener(HandlePoke);
    }

    private void HandlePoke(string name)
    {
        foreach (ToggleOption option in options)
            Deselect(option);

        ToggleOption selected_option = options.FirstOrDefault(o => o.name == name);
        Select(selected_option);

        onParameterSet.Invoke(name);
    }

    private void Deselect(ToggleOption option)
    {
        option.image.color = deselectedColor;
        option.selectedImage.enabled = false;
    }

    private void Select(ToggleOption option)
    {
        option.image.color = selectedColor;
        option.selectedImage.enabled = true;
    }
}
