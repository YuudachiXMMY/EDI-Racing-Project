using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[AddComponentMenu("Dizzy Media/Easy Selector/Retro Edition/2D/Retro 2D")]
public class EasySelector_Retro2D : MonoBehaviour {
    
    [System.Serializable]
    public class CharacterSprites {
        
        public Sprite[] normal;
        public Sprite[] fade;
        
    }//CharacterSprites
    
    public bool autoStart;
    
    public bool useArrow;
    public Transform arrowTrans;
    public Transform[] arrowPositions;

    public bool useCharBack;
    public GameObject[] charBacks;

    public bool showNames;
    public GameObject[] charNames;

    public bool useSpriteSwap;
    public Image[] charImages;
    public CharacterSprites charSprites;

    public bool useCharPop;
    public Transform[] charTrans;
    public float charPop;
    public float charPopReset;

    [Space]
    
    public bool useAutoSelect;
    public Button[] charButtons;
    public float autoSelWait;
    
    [Space]
    
    public AudioSource audSource;

    [Space]
    
    public int tabs;
    public bool startTab;
    public bool arrowTab;
    public bool spritesTab;
    public bool charTab;
    public bool autoSelTab;


//////////////////////////////////////
///
///     START ACTIONS
///
///////////////////////////////////////
    
    
	void Start () {
        
        if(autoStart){
            
            StartInit();        
        
        }//autoStart
        
	}//Start
    
    public void StartInit(){
        
        if(showNames){
            
            if(charNames.Length > 0){
                
                for (int cn = 0; cn < charNames.Length; ++cn) {
                
                    charNames[cn].SetActive(true);
                
                }//for cn charNames
            
            }//charNames.Length > 0
            
        //showNames
        } else {
            
            if(charNames.Length > 0){
                
                for (int cn = 0; cn < charNames.Length; ++cn) {
                
                    charNames[cn].SetActive(false);
                
                }//for cn charNames
            
            }//charNames.Length > 0
            
        }//showNames
                    
        if(!useCharBack){
                        
            if(charBacks.Length > 0){
                
                for (int cb = 0; cb < charBacks.Length; ++cb) {
                    
                    charBacks[cb].SetActive(false);
                    
                }//for cb charBacks
                
            }//charBacks.Length > 0
            
        }//!useCharBack
        
        if(useArrow){
            
            if(arrowTrans != null){
                
                if(!arrowTrans.gameObject.activeSelf){
                    
                    arrowTrans.gameObject.SetActive(true);
            
                }//!activeSelf
                
            }//arrowTrans != null
            
        //useArrow
        } else {
            
            if(arrowTrans != null){
                
                arrowTrans.gameObject.SetActive(false);
                
            }//arrowTrans != null
            
        }//useArrow
        
        CheckIndex(1);
        
        if(useAutoSelect){
            
            StartCoroutine("SelectBuff");
        
        }//useAutoSelect
        
    }//StartInit

    private IEnumerator SelectBuff(){
        
        EventSystem.current.SetSelectedGameObject(null);
        
        yield return new WaitForSeconds(autoSelWait);
        
        if(charButtons[0] != null){
            
            charButtons[0].Select();
        
        }//charButtons[0] != null
        
    }//SelectBuff
    
    
//////////////////////////////////////
///
///     CHECK ACTIONS
///
///////////////////////////////////////
    
    
    public void CheckIndex(int index){
            
        if(useArrow){
                        
            if(arrowPositions.Length >= index){
            
                arrowTrans.position = arrowPositions[index - 1].position;
            
            }//arrowPositions.Length > 0
                    
        }//useArrow
                    
        if(useCharPop){
                        
            for(int cp = 0; cp < charTrans.Length; ++cp) {
                        
                charTrans[cp].localScale = new Vector3(charPopReset, charPopReset, 1);
                            
            }//for cp charTrans
                        
            charTrans[index - 1].localScale = new Vector3(charPop, charPop, 1);
                    
        }//useCharPop
       
        if(useCharBack){
                    
            if(charBacks.Length >= index){
                            
                for (int i = 0; i < charBacks.Length; ++i) {
                    
                    charBacks[i].SetActive(false);
                        
                }//for i charBacks
                        
                if(charBacks[index - 1] != null){
                            
                    charBacks[index - 1].SetActive(true);
                        
                }//charBacks[index - 1] != null
                    
            }//charBacks.Length > 0
                
        }//useCharBack
                    
        if(useSpriteSwap){
                  
            if(charImages.Length >= index){
                    
                if(charSprites.fade.Length >= index){
                    
                    for (int ci = 0; ci < charImages.Length; ++ci) {

                        charImages[ci].sprite = charSprites.fade[ci];

                    }//for ci charImages && normal.Length >= index

                }//fade.Length >= index

                if(charSprites.normal.Length >= index){
                        
                    charImages[index - 1].sprite = charSprites.normal[index - 1];
                
                }//normal.Length >= index
                    
            }//charImages.Length >= index
                
        }//useSpriteSwap
    
    }//CheckIndex
    
    
//////////////////////////////////////
///
///     EXTRA ACTIONS
///
///////////////////////////////////////
    
    
    public void PlayClip(AudioClip clip){
        
        audSource.PlayOneShot(clip, audSource.volume);
        
    }//PlayClip
    

}//CharacterSelect
