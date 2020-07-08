using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text counttext;
    public Text wintext;
    string rev;
 
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        wintext.text = "";
       
    }

     void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
           
            string cubestring = other.GetComponent<Checker>().nameLable.text.ToString();

            if(palindromecheck(cubestring))
            {
                gameObject.GetComponent<AudioSource>().Play();
                other.gameObject.SetActive(false);
                count++;
                setCountText();
                
            }else
            {
                Debug.Log(palindromecheck(cubestring));
            }

          
        }else if(other.gameObject.CompareTag("secret"))
                    {

                     other.gameObject.SetActive(false);

            GameObject[] allcubes=GameObject.FindGameObjectsWithTag("Pick Up");
            for(int i=0;i<=allcubes.Length-1;i++)
            {
                if (palindromecheck(allcubes[i].GetComponent<Checker>().nameLable.text.ToString()))
                    {
                    var cubeRenderer = allcubes[i].GetComponent<Renderer>();

                    cubeRenderer.material.SetColor("_Color", Color.red);
                }
            }
        }
    }

    void setCountText()
    {
        counttext.text = "Count: " + count.ToString();
        if(count==Spawner.noofpalindrome)
        {
            wintext.text =  Spawner.noofpalindrome+" palindromes captured";
        }
    }


    bool palindromecheck(string s)
    {
        char[] ch = s.ToCharArray();
        Array.Reverse(ch);
        rev = new string(ch);
        bool b = s.Equals(rev, StringComparison.OrdinalIgnoreCase);
        return b;

    }
}

