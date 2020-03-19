﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    private Animator transitionAnim;

    private void Start()
    {
        transitionAnim = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName) {
        transitionAnim.SetTrigger("tran2");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

}

    

