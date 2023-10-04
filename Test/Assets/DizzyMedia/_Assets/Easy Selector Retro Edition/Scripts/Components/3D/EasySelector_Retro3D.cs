using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

[AddComponentMenu("Dizzy Media/Easy Selector/Retro Edition/3D/Retro 3D")]
public class EasySelector_Retro3D : MonoBehaviour {
    
    public static EasySelector_Retro3D instance;
    
    [System.Serializable]
    public class Character {
        
        [Space]
        
        public string name;
        
        [Space]
        
        public GameObject prefab;
        public Transform spawnTrans;
        
        [Space]
        
        public Retro3D_CharMover charMove;
        //public float curvePercent;
        
    }//Character
    
    public bool useDebug;
    
    public bool drawGizmos;
    public float gizmoRadius;
    
    public bool createInstance;
    
    public float startWait;
    
    public bool useActionInput;
    public string actionInput;
    
    public bool useDirInput;
    public string directionInput;
    
    public UnityEvent selectEvent;
    
    public Character[] character;
    
    public bool useNames;
    public Text charNameText;
    
    public bool useSounds;
    public AudioSource audSource;
    
    public bool useMoveClip;
    public bool randomMoveClip;
    public AudioClip moveAudClip;
    public AudioClip[] randMoveClips;
    
    public bool useSelectClip;
    public AudioClip selectClip;
    
    public bool useLateSelect;
    public AudioClip lateSelectClip;
    public float lateSelectWait;
    
    public bool useFlash;
    public Image flashImg;
    public Color[] selFlashCol;
    public float flashMulti;
    public float flashMultiReset;
    public float flashMultiBuff;
    
    public bool useMovement;
    public float[] charMoveCurvePercent;
    
    public BGCurve bgCurve;
    public BGCcMath bgMath;
    
    public float distMulti;
    public float distMulti2;
    
    public int tempInt;
    public int curChar;
    public List<Vector3> charVects;
    public List<Animator> charAnim;
    
    public bool flash;
    public bool flashColorUpdate;
    public bool flashLock;

    public bool moveLeft;
    public bool moveRight;
    
    public bool detInput;
    
    public int tabs;
    public bool startTab;
    public bool flashTab;
    public bool audioTab;
    public bool charTab;
    public bool moveTab;
    public bool inputTab;
    
    public int debugInt;
    public int gizmoInt;
    
    
//////////////////////////////////////
///
///     START ACTIONS
///
///////////////////////////////////////
    
    
	void Start () {
        
        if(createInstance){
            
            instance = this;
        
        }//createInstance
        
        StartInit();
		
	}//Start
    
    public void StartInit(){
        
        detInput = false;
        tempInt = -1;
        curChar = -1;
        charVects = new List<Vector3>();
        charAnim = new List<Animator>();
        
        flash = false;
        flashColorUpdate = false;
        flashLock = false;
        
        moveLeft = false;
        moveRight = false;
        
        StartCoroutine("CharStart");
        
    }//StartInit
    
    
//////////////////////////////////////
///
///     UPDATE ACTIONS
///
///////////////////////////////////////
    

	void Update() {
        
        if(detInput){
        
            if(useActionInput){

                if(Input.GetButtonUp(actionInput)){

                    detInput = false;
                    StartCoroutine("CharSelect");

                }//button action

            }//useActionInput

            if(useDirInput){

                if(Input.GetAxisRaw(directionInput) > 0){

                    detInput = false;
                    StartCoroutine("MoveRight");

                }//axis > 0

                if(Input.GetAxisRaw(directionInput) < 0){ 

                    detInput = false;
                    StartCoroutine("MoveLeft");

                }//axis < 0

            }//useDirInput
            
        }//detInput
        
        if(useFlash){
            
            if(flashColorUpdate){

                if(flash){

                    flashImg.color = Color.Lerp(flashImg.color, selFlashCol[1], flashMulti * Time.deltaTime);

                    if(!flashLock){

                        flashLock = true;
                        StartCoroutine("FlashBuff", false);

                    }//!flashLock

                //flash
                } else {

                    flashImg.color = Color.Lerp(flashImg.color, selFlashCol[0], flashMultiReset * Time.deltaTime);

                    if(!flashLock){

                        flashLock = true;
                        StartCoroutine("FlashBuff", true);

                    }//!flashLock

                }//flash

            }//flashColorUpdate
            
        }//useFlash
		
	}//Update
    
    
//////////////////////////////////////
///
///     FLASH ACTIONS
///
///////////////////////////////////////
    
    
    public void Flash_Start(){
            
        flash = true;
        flashColorUpdate = true;
        
    }//FlashStart
    
    public IEnumerator FlashBuff(bool state){
        
        yield return new WaitForSeconds(flashMultiBuff);

        if(state){
            
            flash = false;
            flashLock = false;
            flashColorUpdate = false;
        
        //state
        } else {
            
            flash = false;
            flashLock = false;
            
        }//state
        
    }//FlashBuff
    
    
//////////////////////////////////////
///
///     CHARACTER ACTIONS
///
///////////////////////////////////////
    
    
    public IEnumerator CharStart(){
        
        yield return new WaitForSeconds(startWait);
        
        curChar = 1;
        
        if(character.Length > 0){
            
            charVects = new List<Vector3>(character.Length);

            for(int c = 0; c < character.Length; c++) {

                Vector3 tempVectPos = character[c].spawnTrans.position;
                charVects.Add(tempVectPos);
                
                CreateCharacter(c);

            }//for c character

            if(charNameText != null){
            
                if(useNames){

                    charNameText.text = character[curChar - 1].name;
                    charNameText.gameObject.SetActive(true);

                //useNames
                } else {

                    charNameText.gameObject.SetActive(false);

                }//useNames
                
            }//charNameText != null
            
        }//character.Length > 0
        
        yield return new WaitForSeconds(0.1f);
        
        if(useActionInput | useDirInput){
            
            detInput = true;
            
        }//useActionInput | useDirInput
        
    }//CharStart
    
    public void CreateCharacter(int slot){

        if(character.Length >= slot){
        
            if(character[slot].spawnTrans != null){

                GameObject newCharacter = Instantiate(character[slot].prefab, character[slot].spawnTrans.position, character[slot].spawnTrans.rotation);

                newCharacter.transform.parent = character[slot].spawnTrans;

                if(newCharacter.GetComponent<Animator>() != null){

                    charAnim.Add(newCharacter.GetComponent<Animator>());

                }//Animator != null

            }//spawnTrans != null
            
        }//character.Length >= slot
        
    }//CreateCharacter
    
    public IEnumerator CharSelect(){
    
        selectEvent.Invoke();
        
        charAnim[curChar - 1].SetBool("Selected", true);
        
        if(useFlash){
            
            Flash_Start();
        
        }//useFlash
        
        if(useSounds && useSelectClip){
            
            audSource.PlayOneShot(selectClip, audSource.volume);
            
        }//useSounds
        
        if(useSounds && useLateSelect){
            
            yield return new WaitForSeconds(lateSelectWait);
        
            audSource.PlayOneShot(lateSelectClip, audSource.volume);
            
        }//useSounds
        
    }//CharSelect
    
    
//////////////////////////////////////
///
///     MOVE ACTIONS
///
///////////////////////////////////////
    
    
    public IEnumerator MoveLeft(){
        
        if(useDebug){
            
            Debug.Log("MoveLeft");
        
        }//useDebug
        
        if(useSounds){
            
            if(useMoveClip){
            
                if(randomMoveClip){

                    audSource.PlayOneShot(randMoveClips[Random.Range(0, randMoveClips.Length)], audSource.volume);

                //randomMoveClip
                } else {

                    audSource.PlayOneShot(moveAudClip, audSource.volume);

                }//randomMoveClip
                
            }//useMoveClip

        }//useSounds
        
        yield return new WaitForSeconds(0.1f);

        if(!useMovement){
            
            if(curChar == character.Length - 1){
                
                for(int c = 0; c < character.Length; c++) {
                 
                    character[c].spawnTrans.position = charVects[c];
                    
                }//for c character
                
            //curChar = character.Length - 1
            } else {
                
                int tempCount = curChar + 1;
                bool slotCheck = false;
                bool adjust = false;
                bool reset = false;

                if(tempCount >= character.Length){

                    tempCount = 1;
                    slotCheck = true;
                    adjust = true;

                }//tempCount >= character.Length

                for(int c = 0; c < character.Length; c++) {

                    tempCount--;

                    if(tempCount == 0){

                        if(!slotCheck){

                            if(!adjust){

                                tempCount = character.Length - 1;
                                slotCheck = true;

                            }//!adjust

                        //!slotCheck
                        } else {

                            if(adjust){

                                tempCount = character.Length - 1;
                                adjust = false;

                            //adjust
                            } else {

                                tempCount = 0;
                                slotCheck = false;
                                reset = true;

                            }//adjust
                            
                        }//!slotCheck 

                    }//tempCount = 0

                    character[c].spawnTrans.position = charVects[tempCount];

                    if(slotCheck){

                        tempCount = 1;

                    }//slotCheck

                    if(reset){

                        tempCount = character.Length - 1;
                        
                    }//reset

                }//for c character
                
            }//curChar = character.Length - 1  

        //!useMovement
        } else {
            
            moveLeft = true;
            
            for(int i = 0; i < character.Length; i++) {
                
                if(character[i].charMove != null){
                    
                    character[i].charMove.SetPosLeft();
                    character[i].charMove.faceBackward = false;
                    character[i].charMove.faceForward = true;
                    character[i].charMove.updateMove = true;
                
                }//charMove != null
                
            }//for i character
            
        }//!useMovement
        
        curChar--;
        
        if(curChar <= 0){
            
            curChar = character.Length;
                
        }//curChar <= 0
        
        if(useNames){
        
            if(curChar > 0){
            
                charNameText.text = character[curChar - 1].name;
        
            //curChar > 0
            } else {
            
                charNameText.text = character[curChar].name;
                
            }//curChar > 0
            
        }//useNames
        
        yield return new WaitForSeconds(0.1f);
        
        if(!useMovement){
            
            detInput = true;
            
        }//useMovement
        
    }//MoveLeft
    
    public IEnumerator MoveRight(){
        
        if(useDebug){
            
            Debug.Log("MoveRight");
        
        }//useDebug
        
        if(useSounds){
            
            if(useMoveClip){
            
                if(randomMoveClip){

                    audSource.PlayOneShot(randMoveClips[Random.Range(0, randMoveClips.Length)], audSource.volume);

                //randomMoveClip
                } else {

                    audSource.PlayOneShot(moveAudClip, audSource.volume);

                }//randomMoveClip
                
            }//useMoveClip
                
        }//useSounds
        
        yield return new WaitForSeconds(0.1f);
        
        if(!useMovement){
            
            if(curChar == character.Length){
                
                for(int c = 0; c < character.Length; c++) {
                 
                    character[c].spawnTrans.position = charVects[c];
                    
                }//for c character
                
            //curChar = character.Length - 1
            } else {
                
                int tempCount = curChar;
                bool slotCheck = false;
                bool adjust = false;
                bool reset = false;

                if(tempCount >= character.Length){

                    tempCount = 1;
                    slotCheck = true;
                    adjust = true;

                }//tempCount >= character.Length

                for(int c = 0; c < character.Length; c++) {

                    tempCount--;

                    if(tempCount == 0){

                        if(!slotCheck){

                            if(!adjust){

                                tempCount = character.Length - 1;
                                slotCheck = true;

                            }//!adjust

                        //!slotCheck
                        } else {

                            if(adjust){

                                tempCount = character.Length - 1;
                                adjust = false;

                            //adjust
                            } else {

                                tempCount = 0;
                                slotCheck = false;
                                reset = true;

                            }//adjust
                            
                        }//!slotCheck 

                    }//tempCount = 0

                    character[c].spawnTrans.position = charVects[tempCount];

                    if(slotCheck){

                        tempCount = 1;

                    }//slotCheck

                    if(reset){

                        tempCount = character.Length - 1;
                        
                    }//reset

                }//for c character
                
            }//curChar = character.Length - 1 
            
        //!useMovement
        } else {
            
            moveRight = true;
            
            for(int i = 0; i < character.Length; i++) {
                
                if(character[i].charMove != null){
                    
                    character[i].charMove.SetPosRight();
                    character[i].charMove.faceBackward = true;
                    character[i].charMove.faceForward = false;
                    character[i].charMove.updateMove = true;
                
                }//charMove != null
                
            }//for i character

        }//!useMovement
        
        curChar++;
        
        if(curChar > character.Length){
            
            curChar = 1;
                
        }//curChar > character.Length
        
        if(useNames){
        
            if(curChar > 0){
            
                charNameText.text = character[curChar - 1].name;
        
            //curChar > 0
            } else {
            
                charNameText.text = character[curChar].name;
                
            }//curChar > 0
            
        }//useNames
        
        yield return new WaitForSeconds(0.1f);
        
        if(!useMovement){
            
            detInput = true;
            
        }//!useMovement
        
    }//MoveRight
    
    
//////////////////////////////////////
///
///     GIZMOS ACTIONS
///
///////////////////////////////////////
    
    
    void OnDrawGizmos() {
        
        if (drawGizmos){

            if(character.Length > 0){
                
                for(int i = 0; i < character.Length; i++) {

                    if(character[i].spawnTrans != null){
                        
                        Gizmos.color = Color.cyan;
                        Gizmos.DrawCube(character[i].spawnTrans.position, new Vector3(0.5f, 0.5f, 0.5f));
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireSphere(character[i].spawnTrans.position, gizmoRadius);

                    }//spawnTrans != null
                    
                }//for i character
                
            }//character.Length > 0
            
        }//drawGizmos
        
    }//OnDrawGizmos
    
}
