using UnityEngine;
using System.Collections;

public class RainScript : MonoBehaviour
{
    private float rainchance;
    private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        StartCoroutine(rainclock());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator rainclock(){
        while(true){
        rainchance = Random.Range(0.0f, 10.0f);
        if (rainchance <= 6.0f){
            if(!particle.isPlaying){
                var main = particle.main;
                main.duration = Random.Range(0.0f, 30.0f);
                particle.Play(true);
            }
        }
            yield return new WaitForSeconds(15.0f);
        }
    }
}
