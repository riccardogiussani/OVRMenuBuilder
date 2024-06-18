using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;
using System;

public class ToggleOption : MonoBehaviour
{
    public PokeInteractionManager button => GetComponentInChildren<PokeInteractionManager>();
    public Image selectedImage => GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Selected").GetComponent<Image>();
    public Image image => GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Image").GetComponent<Image>();


    [HideInInspector] public UnityEvent<string> onCustomPoke;


    private void OnEnable()
    {
        button.onPoke.AddListener(OnOptionPoked);
    }
    private void OnDisable()
    {
        button.onPoke.RemoveListener(OnOptionPoked);
    }

    private void OnOptionPoked()
    {
        onCustomPoke.Invoke(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
