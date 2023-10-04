using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

[AddComponentMenu("Dizzy Media/Easy Selector/Retro Edition/3D/Retro 3D v2")]
public class EasySelector_Retro3D_v2 : MonoBehaviour {
    
    public static EasySelector_Retro3D_v2 instance;
    
    [System.Serializable]
    public class Character {
        
        [Space]
        
        public string name;
        public Text nameText;
        
        [Space]
        
        public GameObject prefab;
        
        [Space]
        
        public RectTransform charSlotRect;
        public EventTrigger charSlotEvent;
        
    }//Character
    
    [System.Serializable]
    public class PlayerFlash {
        
        [Space]
        
        public Image flashImg;
        public RectTransform highlightRect;
        public Color[] selFlashCol;
        
        [Space]
        
        public float flashMulti;
        public float flashMultiReset;
        public float flashMultiBuff;
        
    }//PlayerFlash
    
    public bool createInstance;
    
    public Character[] character;
    public Transform[] spawnTrans;
    
    public bool useAutoSelect;
    public float autoSelWait;
    public Button firstSelButton;
    
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

    public bool selDis;
    public bool useNames;
    
    public bool useFlash;
    public PlayerFlash[] playFlash;   
    
    public int playerCount;
    public int tempPlayer;
    
    public List<GameObject> charInsts_P1;
    public List<Animator> charAnims_P1;
    
    public List<GameObject> charInsts_P2;
    public List<Animator> charAnims_P2;
    
    public int play1CurSel;
    public int play2CurSel;
    
    public bool play1Sel;
    public bool play2Sel;
    
    public bool flash;
    public bool flashColorUpdate;
    public bool flashLock;
    
    public int tabs;
    public bool startTab;
    public bool charTab;
    public bool audioTab;
    public bool flashTab;
    
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
        
        playerCount = 1;
        tempPlayer = 1;
        
        charInsts_P1 = new List<GameObject>();
        charAnims_P1 = new List<Animator>();
        
        play1CurSel = -1;
        play2CurSel = -1;
        
        play1Sel = false;
        play2Sel = false;
        
        flash = false;
        flashColorUpdate = false;
        flashLock = false;
        
        if(playFlash.Length > 0){
            
            for(int f = 0; f < playFlash.Length; f++) {

                if(playFlash[f].flashImg != null){
                    
                    playFlash[f].highlightRect.gameObject.SetActive(false);
                    playFlash[f].flashImg.enabled = false;
                    playFlash[f].flashImg.color = playFlash[f].selFlashCol[0];

                }//flashImg != null
                
            }//for f playFlash
            
            playFlash[0].highlightRect.gameObject.SetActive(true);
        
        }//playFlash.Length > 0
        
        StartCoroutine("CharStart");
        
    }//StartInit
	
    
//////////////////////////////////////
///
///     UPDATE ACTIONS
///
///////////////////////////////////////
    

	void Update () {
        
        if(flashColorUpdate){
        
            if(flash){

                playFlash[tempPlayer - 1].flashImg.color = Color.Lerp(playFlash[tempPlayer - 1].flashImg.color, playFlash[tempPlayer - 1].selFlashCol[1], playFlash[tempPlayer - 1].flashMulti * Time.deltaTime);
                
                if(!flashLock){
                    
                    flashLock = true;
                    StartCoroutine("FlashBuff", false);
                    
                }//!flashLock

            //flash
            } else {

                playFlash[tempPlayer - 1].flashImg.color = Color.Lerp(playFlash[tempPlayer - 1].flashImg.color, playFlash[tempPlayer - 1].selFlashCol[0], playFlash[tempPlayer - 1].flashMultiReset * Time.deltaTime);
                
                if(!flashLock){
                    
                    flashLock = true;
                    StartCoroutine("FlashBuff", true);
                    
                }//!flashLock

            }//flash
            
        }//flashColorUpdate
		
	}//Update

    
//////////////////////////////////////
///
///     FLASH ACTIONS
///
///////////////////////////////////////
    
    
    public IEnumerator FlashBuff(bool state){
        
        yield return new WaitForSeconds(playFlash[tempPlayer - 1].flashMultiBuff);

        if(state){
            
            flash = false;
            flashLock = false;
            flashColorUpdate = false;
        
        //state
        } else {
            
            flash = false;
            flashLock = false;
            playFlash[tempPlayer - 1].flashImg.enabled = false;
            
        }//state
        
    }//FlashBuff
    
    
//////////////////////////////////////
///
///     CHARACTER ACTIONS
///
///////////////////////////////////////
    
    
    public IEnumerator CharStart(){
        
        play1CurSel = 1;
        play2CurSel = character.Length;
        
        yield return new WaitForSeconds(0.1f);
            
        for(int c = 0; c < character.Length; c++) {
           
            CreateCharacters_P1(c);
            CreateCharacters_P2(c);
           
        }//for c character
        
        if(useNames){
            
            for(int i = 0; i < character.Length; i++) {
                
                if(character[i].nameText != null){
                    
                    character[i].nameText.text = character[i].name;
                
                }//nameText != null
                
            }//for i character
        
        //useNames
        } else {
            
            for(int i = 0; i < character.Length; i++) {
                
                if(character[i].nameText != null){
                    
                    character[i].nameText.gameObject.SetActive(false);
                
                }//nameText != null
                
            }//for i character
            
        }//useNames
        
        if(useAutoSelect){
            
            StartCoroutine("SelectBuff");
        
        }//useAutoSelect
        
    }//CharStart
    
    private IEnumerator SelectBuff(){

        EventSystem.current.SetSelectedGameObject(null);

        yield return new WaitForSeconds(autoSelWait);

        if(firstSelButton != null){

            firstSelButton.Select();

        }//firstSelButton != null

    }//SelectBuff
    
    public void CreateCharacters_P1(int slot){
        
        if(character.Length >= slot){

            int tempSlot = slot + 1;
            
            GameObject newCharacter = Instantiate(character[slot].prefab, spawnTrans[0].position, spawnTrans[0].rotation);
            newCharacter.transform.parent = spawnTrans[0];
            newCharacter.name = character[slot].name + "_" + tempSlot;

            newCharacter.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            if(newCharacter.GetComponent<Animator>() != null){

                charAnims_P1.Add(newCharacter.GetComponent<Animator>());

            }//Animator != null
                
            charInsts_P1.Add(newCharacter);
                
            if(slot > 0){
                    
                newCharacter.SetActive(false);
                    
            }//slot > 0
        
        }//character.Length >= slot
        
    }//CreateCharacters_P1
    
    public void CreateCharacters_P2(int slot){
        
        if(character.Length >= slot){

            int tempSlot = slot + 1;

            GameObject newCharacter = Instantiate(character[slot].prefab, spawnTrans[1].position, spawnTrans[1].rotation);
            newCharacter.transform.parent = spawnTrans[1];
            newCharacter.name = character[slot].name + "_" + tempSlot;

            newCharacter.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            if(newCharacter.GetComponent<Animator>() != null){

                charAnims_P2.Add(newCharacter.GetComponent<Animator>());

            }//Animator != null
                
            charInsts_P2.Add(newCharacter);
            newCharacter.SetActive(false);
        
        }//character.Length >= slot
        
    }//CreateCharacters_P2
    
    public void CurPlayer_Set(int curPlay){
        
        tempPlayer = curPlay;
        
    }//CurPlayer_Set
    
    public void CurChar_Set(int charInt){
        
        int tempInt = play1CurSel;
        
        play1CurSel = charInt;

        if(tempInt != play1CurSel){
            
            charInsts_P1[tempInt - 1].SetActive(false);
            charInsts_P1[play1CurSel - 1].SetActive(true);
        
        //tempInt != play1CurSel
        } else {
            
            if(!charInsts_P1[play1CurSel - 1].activeSelf){
                
                charInsts_P1[play1CurSel - 1].SetActive(true);
                
            }//!activeSelf
            
        }//tempInt != play1CurSel
        
    }//CurChar_Set

    public void SetHighlight(){
        
        playFlash[tempPlayer - 1].highlightRect.localPosition = character[play1CurSel - 1].charSlotRect.localPosition;
        
        if(useMoveClip){
        
            if(randomMoveClip){

                audSource.PlayOneShot(randMoveClips[Random.Range(0, randMoveClips.Length)], audSource.volume);
            
            //randomMoveClip
            } else {
            
                audSource.PlayOneShot(moveAudClip, audSource.volume);
            
            }//randomMoveClip
            
        }//useMoveClip
        
    }//SetHighlight
    
    public void CharSelCall(){
        
        StartCoroutine("CharSelect");
        
    }//CharSelCall
    
    public IEnumerator CharSelect(){
        
        charAnims_P1[play1CurSel - 1].SetBool("Selected", true);
        
        if(selDis){
            
            for(int i = 0; i < character.Length; i++) {
             
                character[i].charSlotEvent.enabled = false;
                
            }//for i charSlotsEvents
            
        }//selDis
        
        if(useFlash){
            
            playFlash[tempPlayer - 1].flashImg.enabled = true;
            flash = true;
            flashColorUpdate = true;
        
        //useFlash
        } else {
            
            playFlash[tempPlayer - 1].flashImg.enabled = false;
            flash = false;
            flashColorUpdate = false;
            playFlash[tempPlayer - 1].flashImg.color = playFlash[tempPlayer - 1].selFlashCol[0];
            
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
///     EXTRA ACTIONS
///
///////////////////////////////////////
    
    
    public void PlaySound(AudioClip clip){
        
        if(useSounds){
            
            audSource.PlayOneShot(clip, audSource.volume);
            
        }//useSounds
        
    }//PlaySound
    
}
