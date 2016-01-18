using UnityEngine;
using System.Collections;

public class sound_script : MonoBehaviour {
    public AudioClip bite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if((col.gameObject.name=="Male")||(col.gameObject.name=="Female")||(col.gameObject.name=="Child"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);
        }
    }
}
