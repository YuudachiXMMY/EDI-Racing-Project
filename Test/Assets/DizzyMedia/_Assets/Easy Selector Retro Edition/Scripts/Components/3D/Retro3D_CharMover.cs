using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

[AddComponentMenu("Dizzy Media/Easy Selector/Retro Edition/3D/Character Mover")]
public class Retro3D_CharMover : MonoBehaviour {
    
    [Space]
    
    [Header("References")]
    
    public EasySelector_Retro3D easySel_Retro3D;
    
    public Transform moveTrans;
    
    [Space]
    
    [Header("User Options")]
    
    [Space]
    
    public bool useDebug;
    public bool useMoveRot;
    
    public int slotPos;
    
    [Space]
    
    [Header("Auto")]
    
    [Space]
    
    public int curPos;
    
    public float distance;
    
    public Vector3 charPosition;
    public Vector3 charRotation;
    
    public bool faceForward;
    public bool faceBackward;
    
    public bool updateMove;
    

//////////////////////////////////////
///
///     START ACTIONS
///
///////////////////////////////////////
    

	void Start () {
        
        StartInit();
		
	}//Start
    
    public void StartInit(){
        
        curPos = slotPos;
        distance = 0;
        
        charPosition = new Vector3(0, 0, 0);
        charRotation = new Vector3(0, 0, 0);
        
        faceForward = false;
        faceBackward = false;
        updateMove = false;
            
        if(easySel_Retro3D == null){
            
            easySel_Retro3D = GameObject.Find("EasySelector_Retro3D").GetComponent<EasySelector_Retro3D>();
        
        }//easySel_Retro3D == null
        
        if(moveTrans == null){
            
            moveTrans = this.transform;
            
        }//moveTrans == null
        
        StartCoroutine("GrabDistance_Buff");
        
    }//StartInit
	

//////////////////////////////////////
///
///     UPDATE ACTIONS
///
///////////////////////////////////////
    
    
	void Update() {
        
        if(updateMove){
                
            if(easySel_Retro3D.moveLeft){
                
                if(curPos == 1 && distance >= easySel_Retro3D.charMoveCurvePercent[curPos - 1]){ 
                        
                    updateMove = false;
                    faceForward = false;
                    faceBackward = false;
                    curPos = easySel_Retro3D.character.Length - 1;
                    
                    if(useDebug){
                        
                        Debug.Log("Move1 Finished");
                        
                    }//useDebug
                    
                }//curPos = 1 & distance >= curvePercent
                    
                if(curPos == easySel_Retro3D.character.Length - 1 && distance >= easySel_Retro3D.charMoveCurvePercent[curPos - 1]){ 
                     
                    updateMove = false;
                    easySel_Retro3D.moveLeft = false;
                    easySel_Retro3D.moveRight = false;
                    faceForward = false;
                    faceBackward = false;
                    curPos = easySel_Retro3D.character.Length;
                        
                    easySel_Retro3D.detInput = true;

                    if(useDebug){
                        
                        Debug.Log("Move2 Finished");
                        
                    }//useDebug
                    
                }//curPos = character.Length - 1 & distance >= curvePercent
                     
                if(curPos == easySel_Retro3D.character.Length && distance >= easySel_Retro3D.charMoveCurvePercent[curPos - 1]){ 
                     
                    updateMove = false;
                    faceForward = false;
                    faceBackward = false;
                    curPos = 1;
                    distance = 0;
                    
                    if(useDebug){
                        
                        Debug.Log("Move3 Finished");
                        
                    }//useDebug
                    
                }//curPos = character.Length & distance >= curvePercent
                        
                if(faceForward){
                
                    if(curPos == easySel_Retro3D.character.Length - 1){
                                
                        distance += easySel_Retro3D.distMulti * easySel_Retro3D.distMulti2 * Time.deltaTime;
                            
                    //curPos == character.Length - 1
                    } else {
                                
                        distance += easySel_Retro3D.distMulti * Time.deltaTime;
                            
                    }//curPos == character.Length - 1
                        
                }//faceForward
        
                if(faceBackward){
                            
                    if(curPos == easySel_Retro3D.character.Length - 1){
                
                        distance -= easySel_Retro3D.distMulti * easySel_Retro3D.distMulti2 * Time.deltaTime;
                            
                    //curPos == character.Length - 1
                    } else {
                                
                        distance -= easySel_Retro3D.distMulti * Time.deltaTime;
                                
                    }//curPos == character.Length - 1
            
                }//faceBackward
        
                GrabVect();
        
                moveTrans.position = easySel_Retro3D.bgMath.CalcPositionAndTangentByDistance(distance, out charPosition);
        
                if(useMoveRot){
                        
                    if(faceForward){
            
                        moveTrans.rotation = Quaternion.LookRotation(charPosition) * Quaternion.AngleAxis(0, Vector3.up);
                        
                    }//faceForward
        
                    if(faceBackward){
            
                        moveTrans.rotation = Quaternion.LookRotation(charPosition) * Quaternion.AngleAxis(180, Vector3.up);
            
                    }//faceBackward
                    
                }//useMoveRot
                    
            }//moveLeft
                
            if(easySel_Retro3D.moveRight){
                
                if(curPos == 1 && distance <= easySel_Retro3D.charMoveCurvePercent[curPos]){ 
                        
                    updateMove = false;
                    faceForward = false;
                    faceBackward = false;
                    curPos = 3;
                    
                    if(useDebug){
                        
                        Debug.Log("Move1 Finished");
                     
                    }//useDebug
                    
                }//curPos = 1 & distance <= curvePercent
                    
                if(curPos == easySel_Retro3D.character.Length - 1 && distance <= -0.1f){ 
                     
                    updateMove = false;
                    faceForward = false;
                    faceBackward = false;
                    
                    distance = easySel_Retro3D.charMoveCurvePercent[curPos];
                    
                    curPos = 1;
                    
                    if(useDebug){
                        
                        Debug.Log("Move2 Finished");
                        
                    }//useDebug
                    
                }//curPos = character.Length - 1 & distance <= -0.1f
                    
                if(curPos == easySel_Retro3D.character.Length && distance <= easySel_Retro3D.charMoveCurvePercent[0]){ 
                     
                    updateMove = false;
                    easySel_Retro3D.moveLeft = false;
                    easySel_Retro3D.moveRight = false;
                    faceForward = false;
                    faceBackward = false;
                    curPos = 2;
                        
                    easySel_Retro3D.detInput = true;
                    
                    if(useDebug){
                        
                        Debug.Log("Move3 Finished");
                   
                    }//useDebug
                    
                }//curPos = character.Length & distance <= curvePercent
                        
                if(faceForward){
                
                    if(curPos == easySel_Retro3D.character.Length){
                                
                        distance += easySel_Retro3D.distMulti * easySel_Retro3D.distMulti2 * Time.deltaTime;
                            
                    //curPos == character.Length
                    } else {
                                
                        distance += easySel_Retro3D.distMulti * Time.deltaTime;
                                
                    }//curPos == character.Length
                            
                }//faceForward
        
                if(faceBackward){
                            
                    if(curPos == easySel_Retro3D.character.Length){
                
                        distance -= easySel_Retro3D.distMulti * easySel_Retro3D.distMulti2 * Time.deltaTime;
                            
                    //curPos == character.Length
                    } else {
                                
                        distance -= easySel_Retro3D.distMulti * Time.deltaTime;
                                
                    }//curPos == character.Length
                            
                }//faceBackward
        
                GrabVect();
        
                moveTrans.position = easySel_Retro3D.bgMath.CalcPositionAndTangentByDistance(distance, out charPosition);
        
                if(useMoveRot){
                        
                    if(faceForward){
            
                        moveTrans.rotation = Quaternion.LookRotation(charPosition) * Quaternion.AngleAxis(0, Vector3.up);
                        
                    }//faceForward
        
                    if(faceBackward){
            
                        moveTrans.rotation = Quaternion.LookRotation(charPosition) * Quaternion.AngleAxis(180, Vector3.up);
            
                    }//faceBackward
                        
                }//useMoveRot
                    
            }//moveRight
                
        }//updateMove
		
	}//Update
    
    
//////////////////////////////////////
///
///     POSITION ACTIONS
///
///////////////////////////////////////
    
    
    public void SetPosLeft(){
        
        if(curPos == 1){
            
            distance = 0;
            
        }//curPos == 1
        
    }//SetPosLeft
    
    public void SetPosRight(){
        
        if(curPos == 1){
            
            distance = easySel_Retro3D.charMoveCurvePercent[easySel_Retro3D.character.Length - 1];
            
        }//SetPosRight
        
    }//SetPosRight
    
    
//////////////////////////////////////
///
///     GRAB ACTIONS
///
///////////////////////////////////////
    
    
    public void GrabDistance(){
        
        if(easySel_Retro3D != null){
            
            easySel_Retro3D.bgMath.CalcPositionByClosestPoint(moveTrans.position, out distance);
        
        }//easySel_Retro3D != null
        
    }//GrabDistance
    
    public IEnumerator GrabDistance_Buff(){
        
        yield return new WaitForSeconds(0.2f);
        
        if(easySel_Retro3D != null){
            
            easySel_Retro3D.bgMath.CalcPositionByClosestPoint(moveTrans.position, out distance);
        
        }//easySel_Retro3D != null
        
    }//GrabDistance_Buff
    
    public void GrabVect(){
        
        charPosition = new Vector3(moveTrans.position.x, moveTrans.position.y, moveTrans.position.z);
        charRotation = new Vector3(moveTrans.rotation.x, moveTrans.rotation.y, moveTrans.rotation.z);
        
    }//GrabVect
    
}
