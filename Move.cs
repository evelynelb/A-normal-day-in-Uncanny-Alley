using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 1;
    bool moveAround = false;
    [HideInInspector] public bool isTalking = false;
    bool[] porteVisite = {false,false,false,false,false};
    private SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = new SceneLoader();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking){
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        Vector2 v = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (v.sqrMagnitude >= 1){
            v.Normalize();
        }
        //transform.Translate(Time.deltaTime * speed * v);
        GetComponent<Rigidbody2D>().velocity = speed*v;
        if (v != Vector2.zero && !moveAround){
                FindObjectOfType<TextMeshProUGUI>().text = "Use the space bar to interact with the citizens.";
                moveAround = true;
            }
        if (TestBoolArray(porteVisite)){
            FindObjectOfType<TextMeshProUGUI>().text = "Well, I'll call it a day. I wonder what I'll be delivering tomorrow! Let's head to the other end of the road.";
        }
    }

    void OnTriggerStay2D(Collider2D porte){
        if (Input.GetKey("space")){
            isTalking = true;
            porte porteScript = porte.GetComponent<porte>();
            int myNumPorte = porteScript.numPorte;
            if (myNumPorte != 0){
                porteVisite[myNumPorte-1] = true;
                StartCoroutine(porteScript.AfficherTexte());
                porte.enabled = false;
            }
            else if (TestBoolArray(porteVisite)){
                StartCoroutine(porteScript.AfficherTexte());
                sceneLoader.LoadNextScene();
                porte.enabled = false;
            }
            
            else if (myNumPorte == 0){
                isTalking = false;
                porte.enabled = true;
            }
            
        }
        
    }

    bool TestBoolArray(bool[] array)
{
    if (array.Length != 5) {
        return false;
    }
    for (int i = 0; i < array.Length; i++) {
        if (!array[i]) {
            // If any element is false, the array is not equal to {true, true, true, true, true}
            return false;
        }
    }
    // If all elements are true and the array is exactly 5 elements long, it is equal to {true, true, true, true, true}
    return true;
}
    
}
