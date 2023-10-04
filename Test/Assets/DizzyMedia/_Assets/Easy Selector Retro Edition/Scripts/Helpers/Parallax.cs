using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[AddComponentMenu("Dizzy Media/Easy Selector/Retro Edition/Helpers/Parallax")]
public class Parallax : MonoBehaviour {
    
    public float speed = 0.5f;
    public float start = 0;
        
    public Material mat;
 
    Vector2 offset = new Vector2 (0, 0);
        
    void Start(){
        
        mat = GetComponent<MeshRenderer>().material;
    
    }//Start
   
    void Update () {
        
        offset.x = start + Time.time * speed;
       
        mat.mainTextureOffset = offset;
    
    }//Update
    
}