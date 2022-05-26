using UnityEngine;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{

    public Text text;

    void Start()
    {
        text.text = "Thank you for playing!\nYour Point: " + Point.point;
    }
}
