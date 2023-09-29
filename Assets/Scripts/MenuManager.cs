using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.3f);
    }


    public void playGame()
    {

        animator.SetTrigger("Start");
        StartCoroutine(StartGame());
        SceneManager.LoadScene(1);
    }
    
}
