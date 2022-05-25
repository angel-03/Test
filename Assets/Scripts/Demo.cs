using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    private int heath = 10;
    private int currentHeath;
    [Range (0,100)]  
    public int age;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Game!!!");
        StartCoroutine("CheckAge");
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Key Pressed");
        }
        
    }
    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") == 1 )
        {
            Debug.Log("Right Key Pressed");
        }
        
    }
    public void Vote(int age)
    {
        this.age = age;
        if(age > 18 && age < 70)
        {
            Debug.Log("Can vote");
        }
        else 
        {
            Debug.Log("Cant vote");
        }
    }

    IEnumerator CheckAge()
    {
        Vote(age);
        yield return new WaitForSeconds(2f);
        Vote(age);
        yield return new WaitForSeconds(2f);
        StartCoroutine("CheckAge");
        yield return new WaitForSeconds(4f);

    }
}
