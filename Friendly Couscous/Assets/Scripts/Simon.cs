using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Simon : MonoBehaviour
{


    public GameObject button;
    public Light greenlight;
    public Light redlight;
    public Light bluelight;
    public Light yellowlight;
    public AudioSource green;
    public AudioSource red;
    public AudioSource blue;
    public AudioSource yellow;
    public bool reset = false;
    public float dur = 0.75f;

    private IEnumerator coroutine;

    Dictionary<int, match> mapdict = new Dictionary<int, match>();

    List<match> GameRound= new List<match>();

    public bool buttonpressed = false;

    public int playerchoice = 4;

    public bool rounder = true;


    public int j = 0;

    // Start is called before the first frame update
    void Start()
    {
      
        mapdict.Add(0, new match(green, greenlight,0));
        mapdict.Add(1, new match(red, redlight,1));
        mapdict.Add(2, new match(blue, bluelight,2));
        mapdict.Add(3, new match(yellow, yellowlight,3));
        

    }
    private IEnumerator gaming()
    {

        for(int i = 0; i < GameRound.Count; i++)
        {
            match tempo = GameRound[i];
          
            tempo.activate();
            yield return new WaitForSeconds(dur);
            tempo.lightcolor.enabled = false;
            
        }

        


            if(j == GameRound.Count)
            {
                Debug.Log("Gameround is empty");
                
            }
            match temp = GameRound[j];
        Debug.Log(GameRound[j].colorID);
        Debug.Log("temp's colorID is " + temp.colorID);
        match playerchosen = null;



        playerchoice = 4;
                while(playerchoice ==4)
                {
                    
                    if (playerchoice != 4)
                    {
                Debug.Log("Player has chosen a color");
                        playerchosen = mapdict[playerchoice];
                        playerchoice = 7;
                        playerchosen.activate();
                Debug.Log("I REMEMBER Player's colorID is " + playerchosen.colorID);
                yield return new WaitForSeconds(0.5f);
                        playerchosen.lightcolor.enabled = false;
                        Debug.Log("I FORGOT Player's colorID is " + playerchosen.colorID);

            }
                      yield return null;
        }
               
                

               
            

        

        if (temp ==null)
        {
            Debug.Log("Issue has not chosen a color");
        }
        if (playerchosen.colorID != temp.colorID)
            {
                resetthegame();
            Debug.Log("GAME IS RESET");
                rounder = true;
                
            }else if(playerchosen.colorID == temp.colorID)
            {
                j++;
                rounder = true;
                
            }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (buttonpressed)
        {
            
            if (rounder)
            {
               
                GameRound.Add(mapdict[Random.Range(0, 4)]);
               
                
                coroutine = gaming();
                StartCoroutine(coroutine);
                rounder = false;
            }
            
            
            
            
        }
    }

   void resetthegame()
    {
        GameRound.Clear();
    }
}


public class match : MonoBehaviour
{
    public AudioSource sound;
    public Light lightcolor;
    public int colorID;
   
    public match(AudioSource sound, Light lightcolor,int colorID)
    {
        this.sound = sound;
        this.lightcolor = lightcolor;
        switch(colorID)
        {
            case 0:
                this.colorID = 0;
                break;
            case 1:
                this.colorID = 1;
                break;
            case 2:
                this.colorID = 2;
                break;
            case 3:
                this.colorID = 3;
                break;
        }

    }
    public void activate()
    {
        lightcolor.enabled = true;
        sound.Play();
    }




}