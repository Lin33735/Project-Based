using System.Collections;
using TMPro;
using UnityEngine;

public class StoveScript : MonoBehaviour
{

    public GameObject Stove;

    public GameObject Player;

    //public GameObject InteractionText;

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

    public void OnMouseOver()
    {
        float dist = Vector3.Distance(Player.transform.position, Stove.transform.position);
        
        if(dist <= 1.8)
        {
            Debug.Log("Player is hovering over the Stove");
            Debug.Log("Distance to Stove: " + dist);
            //InteractionText.SetActive(true);
        }
        
    }
}
