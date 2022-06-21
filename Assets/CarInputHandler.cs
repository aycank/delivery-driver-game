using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    // Components
    Driver driver;

    void Awake()
    {
        driver = GetComponent<Driver>();
    }

    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        driver.SetInputVector(inputVector);
    }
}
