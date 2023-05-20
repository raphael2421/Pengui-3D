using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        canvas2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ControlDisable()
    {
        canvas.SetActive(false);
        canvas2.SetActive(false);
    }
    public void ControlEnable()
    {
        canvas.SetActive(true);
        canvas2.SetActive(false);
    }
    public void CreditDisable()
    {
        canvas2.SetActive(false);
        canvas.SetActive(false);
    }
    public void CreditEnable()
    {
        canvas2.SetActive(true);
        canvas.SetActive(false);
    }
}
