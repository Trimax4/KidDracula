using UnityEngine;
using System.Collections;

public class sound_script : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if((col.gameObject.tag =="man"))
        {
            Debug.Log("audio play");
            source.Play();
        }
    }
}
