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

    private IEnumerator coroutine;

    Dictionary<int, match> mapdict = new Dictionary<int, match>();

    List<match> GameRound= new List<match>();

    public bool turned = false;

    // Start is called before the first frame update
    void Start()
    {
      
        mapdict.Add(0, new match(green, greenlight));
        mapdict.Add(1, new match(red, redlight));
        mapdict.Add(2, new match(blue, bluelight));
        mapdict.Add(3, new match(yellow, yellowlight));
        GameRound.Add(mapdict[Random.Range(0, 4)]);

    }
    private IEnumerator gaming(AudioSource sound, Light lightcolor)
    {
        lightcolor.enabled = true;
        sound.Play();
        yield return new WaitForSeconds(1);  
        lightcolor.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (turned)
        {
           for(int i=0;i<GameRound.Count;i++)
            {
                match temp = GameRound[i];
                coroutine = gaming(temp.sound, temp.lightcolor);
                StartCoroutine(coroutine);
            }
            turned = false;
            GameRound.Add(mapdict[Random.Range(0, 4)]);
        }
    }

   
}


public class match : MonoBehaviour
{
    public AudioSource sound;
    public Light lightcolor;
   
    public match(AudioSource sound, Light lightcolor)
    {
        this.sound = sound;
        this.lightcolor = lightcolor;

    }
   


}