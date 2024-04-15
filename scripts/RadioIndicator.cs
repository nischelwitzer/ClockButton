using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;


// YouTube: https://www.youtube.com/watch?v=5xWDKJj1UGY

public class RadioIndicator : MonoBehaviour
{
    [Header("Radial Timer")]
    [SerializeField] private float indicatorTimer = 1.0f;
    [SerializeField] private float maxIndictorTimer = 1.0f;

    [Header("UI Indicator")]
    [SerializeField] private Image radialIndicatorUI = null;

    [Header("Key Codes")]
    [SerializeField] private KeyCode selectKey = KeyCode.Mouse0;

    [Header("Unity Event")]

    [SerializeField] private UnityEvent myEvent = null;

    private bool shouldUpdate = false;

    private void Update()
    {
        if (Input.GetKey(selectKey))
        {
            shouldUpdate = false;
            indicatorTimer -= Time.deltaTime;
            radialIndicatorUI.enabled = true;
            radialIndicatorUI.fillAmount = indicatorTimer;

            if (indicatorTimer <= 0)
            {
                indicatorTimer = maxIndictorTimer;
                radialIndicatorUI.fillAmount = maxIndictorTimer;
                radialIndicatorUI.enabled = false;
                myEvent.Invoke();
            }
        }
        else
        {
            if (shouldUpdate)
            {
                indicatorTimer += Time.deltaTime;
                radialIndicatorUI.fillAmount = indicatorTimer;

                if (indicatorTimer >= maxIndictorTimer)
                {
                    indicatorTimer = maxIndictorTimer;
                    radialIndicatorUI.fillAmount = maxIndictorTimer;
                    radialIndicatorUI.enabled = false;
                    shouldUpdate = false;
                }
            }
        }

        if (Input.GetKeyUp(selectKey))
        {
            shouldUpdate = true;
        }
    }
}
