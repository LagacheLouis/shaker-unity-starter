using NaughtyAttributes;
using Shaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public AudioEvent audioevent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    [Button]
    public void Clear()
    {
        transform.DestroyChildrenImmediate();
    }

    [Button]
    public void PlayAudio()
    {
        audioevent?.Play3D(Camera.main.transform.position + Camera.main.transform.right * 50);
    }

}
