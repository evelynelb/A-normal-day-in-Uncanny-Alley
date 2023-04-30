using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class porte : MonoBehaviour
{
    [SerializeField] string[] texte;
    public int numPorte;
    public TextMeshProUGUI texteInstance;
    [SerializeField] GameObject bateau;
    [SerializeField] GameObject hobbit;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    public IEnumerator AfficherTexte(){
        
        {texteInstance.text = texte[0];
        while (!Input.GetKeyUp("space")){
                yield return null;
            }
        for(int i = 1; i < texte.Length; i++){
            if (i == 8 && numPorte == 5){
                bateau.SetActive(true);
            };
            while (!Input.GetKeyDown("space")){
                yield return null;
            };
            texteInstance.text = texte[i];
            while (!Input.GetKeyUp("space")){
                yield return null;
            };
        }
        if (numPorte==4){
            hobbit.SetActive(true);
        }
        while (!Input.GetKeyDown("space")){
            yield return null;
        }
        while (!Input.GetKeyUp("space")){
            yield return null;
        }
        FindObjectOfType<Move>().isTalking = false;
        texteInstance.text = "";}

        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
