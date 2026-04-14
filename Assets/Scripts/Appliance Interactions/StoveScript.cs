using System.Collections;
using TMPro;
using UnityEngine;

public class StoveScript : MonoBehaviour
{

    //public GameObject Stove;

    private Interaction interactTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    private IEnumerator StoveColor()
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        yield return null;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Interacted with stove");
            StartCoroutine(StoveColor());
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("Player is hovering over the Stove");
    }
}
