using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  
    public float moveSpeed=5f;
    public float rotationSpeed=360f;

    private int score = 0;
    private int Level = 1;
    public string nextSceneName;

    public Text scoreOutput;
    CharacterController charCtrl;
    Animator anim;
    public Image stage;
    public Image gameOver;
    public Image gamewin;

    void Awake()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }


    void Start()
    {
        StartCoroutine("Stage");
            
    }

    IEnumerator Stage()
    {
        stage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        stage.gameObject.SetActive(false);
    }

   
    void Update()
    {
        Vector3 dir=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        if(dir.sqrMagnitude>0.01f)
        {
            Vector3 forward=Vector3.Slerp(transform.forward,dir,rotationSpeed*Time.deltaTime/Vector3.Angle(transform.forward,dir));
            transform.LookAt(transform.position+forward);
        }
        charCtrl.Move(dir*moveSpeed*Time.deltaTime);

        anim.SetFloat("Speed", charCtrl.velocity.magnitude);

        if (GameObject.FindGameObjectsWithTag("Dot").Length < 1)
        {
            StartCoroutine("YouWin");
            
        }

        scoreOutput.text = "SCORE : " + score;
    }

    IEnumerator YouWin()
    {
        gamewin.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gamewin.gameObject.SetActive(true);
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Dot":
                Destroy(other.gameObject);
                score += 5;
                break;
            case "Enemy":
                StartCoroutine("GameOver");
                break;
        }
    }

    IEnumerator GameOver()
    {
        gameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gameOver.gameObject.SetActive(false);
        SceneManager.LoadScene("scLose");
    }

   

}
