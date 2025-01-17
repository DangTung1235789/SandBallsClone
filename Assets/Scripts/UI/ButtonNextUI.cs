using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNextUI : MonoBehaviour
{
    Car car;
    // Start is called before the first frame update
    void Start()
    {
        car = FindObjectOfType<Car>();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            car.IsStartRun = true;
        });
        this.gameObject.SetActive(false);
    }
}
