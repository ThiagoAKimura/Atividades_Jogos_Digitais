using UnityEngine;
using TMPro;

public class BrainCounterUI : MonoBehaviour
{
    public TextMeshProUGUI brainText; 

    void Update()
    {
        brainText.text = "Cérebros: " + BrainCounter.instance.brainCount;
    }
}
