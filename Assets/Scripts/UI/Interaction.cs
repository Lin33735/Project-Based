using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public StoveScript stove;

    public TextMeshProUGUI InteractionTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractionTxt = GetComponent<TextMeshProUGUI>();
        InteractionTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
