using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject collectible;
    string[] randomstrings=new string[10];
    string[] allpalindrome = new string[10];
    string[] nonpalindromes = new string[10];
    string rev;
    Vector3 position;
    public static int noofpalindrome;

    private static System.Random random = new System.Random();
  

    // Start is called before the first frame update
    void Start()
    {
        
      
            randomstrings = Randommix();
            // Debug.Log(RandomString());

           

     //     for (int i=0;i<randomstrings.Length;i++)
     //  {
     //       palindromecheck(randomstrings[i]);
     //
     //  }


        int spawned=0;
        int cubestring=0;

        while (spawned < 10)
        {
            position = new Vector3(UnityEngine.Random.Range(-9, 9f), 0.5f, UnityEngine.Random.Range(8.4f, -8.8f));

              GameObject newobject= Instantiate(collectible, position, Quaternion.identity);
            newobject.GetComponent<Checker>().nameLable.text = randomstrings[cubestring];
            cubestring++;

            spawned++;
        }
        collectible.SetActive(false);
        Destroy(collectible);
    
    }


    public string[] Randommix()
    {
       
        string[] mixed = new string[10];
        for (int i=0;i<10;i++)
        {
            allpalindrome[i] = Allpalindromes();
            nonpalindromes[i] = Nonpalindromes();
        }
        // we need minimum three and maximum 10 palindromes
       noofpalindrome = UnityEngine.Random.Range(3, 10);
        for(int i=0; i<10;i++)
        {
            if(i<=noofpalindrome-1)
            {
                mixed[i] = allpalindrome[i];
            }else
            {
                mixed[i] = nonpalindromes[i];
            }
        }

        return mixed;
    }
    public string Nonpalindromes()
    {
       
        const string chars = "xm6";
        return new string(Enumerable.Repeat(chars, random.Next(9, 15))
           .Select(s => s[random.Next(s.Length)]).ToArray());

    }

    public string Allpalindromes()
    {
      //  int Length = 0;
        string reverse = "";


        const string chars = "xm6";
       string randomstring= new string(Enumerable.Repeat(chars, random.Next(5, 7))
          .Select(s => s[random.Next(s.Length)]).ToArray());


        char[] ch = randomstring.ToCharArray();
        Array.Reverse(ch);
        reverse = new string(ch);


        return randomstring + reverse;

    }
    

}
