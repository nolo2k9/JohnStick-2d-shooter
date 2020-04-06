using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    //Reference to Animator
    private Animator transitionAnim;

    private void Start()
    {   //get the Animator compoent
        transitionAnim = GetComponent<Animator>();

    }//Start

    public void LoadScene(string sceneName) {
        //Load the scene with the SceneName
        StartCoroutine(Transition(sceneName));

    }//LoadScene

    IEnumerator Transition(string sceneName) {
        //Call tran2 animation
        transitionAnim.SetTrigger("tran2");
        //Wait for 1 second
        yield return new WaitForSeconds(1);
        //Load scene
        SceneManager.LoadScene(sceneName);

    }//Transition

}//SceneChange

    

