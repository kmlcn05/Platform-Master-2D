using TMPro;
using UnityEngine;

public class TimeUIHandler : MonoBehaviour
{

    public Timer timer;
    public TextMeshProUGUI textfield;

    void Start()
    {

        timer.OnTimeUpdate += UpdateTextField;

    }

    public void UpdateTextField()
    {

        string text = System.Math.Round(timer.RemainingTime, 0).ToString() + " second";

        textfield.text = text;

    }
}
