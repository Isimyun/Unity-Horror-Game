using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZJumpTrigger : MonoBehaviour
{
    public AudioSource DoorBang;
    public AudioSource JumpscareSound;
    public AudioSource AmbMusic;
    public GameObject Zombie;
    public GameObject Door;
    public GameObject DoorMesh;

    private void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        Door.GetComponent<Animation>().Play("JumpDoorAnim");
        DoorBang.Play();
        Zombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());
        DoorMesh.SetActive(false);
    }

    IEnumerator PlayJumpMusic()
    {
        JumpscareSound.Play();
        yield return new WaitForSeconds(0.5f);
        AmbMusic.Stop();
        
    }
}
