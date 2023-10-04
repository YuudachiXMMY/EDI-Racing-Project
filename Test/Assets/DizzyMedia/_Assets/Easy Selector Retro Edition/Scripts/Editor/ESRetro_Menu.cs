using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ESRetro_Menu : EditorWindow {


//////////////////////////////////////
///
///     MENU BUTTONS
///
///////////////////////////////////////
    
    
////////////////////
///
///     2D
///
////////////////////
    
    
    [MenuItem("Dizzy Media/Easy Selector/Retro Edition/2D/Retro 2D", false , 0)]
    public static void Create_Retro2D() {
        
        if(Selection.gameObjects.Length > 0){
            
            Selection.gameObjects[0].AddComponent<EasySelector_Retro2D>();
        
        //Selection > 0
        } else {
            
            if(EditorUtility.DisplayDialog("Error", "You must select an object to add the component to.", "Ok")){}
            
        }//Selection > 0
        
    }//Create_Retro2D
    
    
////////////////////
///
///     3D
///
////////////////////
    
    
    [MenuItem("Dizzy Media/Easy Selector/Retro Edition/3D/Retro 3D", false , 0)]
    public static void Create_Retro3D() {
        
        if(Selection.gameObjects.Length > 0){
            
            Selection.gameObjects[0].AddComponent<EasySelector_Retro3D>();
        
        //Selection > 0
        } else {
            
            if(EditorUtility.DisplayDialog("Error", "You must select an object to add the component to.", "Ok")){}
            
        }//Selection > 0
        
    }//Create_Retro3D
    
    [MenuItem("Dizzy Media/Easy Selector/Retro Edition/3D/Retro 3D v2", false , 0)]
    public static void Create_Retro3Dv2() {
        
        if(Selection.gameObjects.Length > 0){
            
            Selection.gameObjects[0].AddComponent<EasySelector_Retro3D_v2>();
        
        //Selection > 0
        } else {
            
            if(EditorUtility.DisplayDialog("Error", "You must select an object to add the component to.", "Ok")){}
            
        }//Selection > 0
        
    }//Create_Retro3Dv2
    
    [MenuItem("Dizzy Media/Easy Selector/Retro Edition/3D/Character Mover", false , 0)]
    public static void Create_CharMover() {
        
        if(Selection.gameObjects.Length > 0){
            
            Selection.gameObjects[0].AddComponent<Retro3D_CharMover>();
        
        //Selection > 0
        } else {
            
            if(EditorUtility.DisplayDialog("Error", "You must select an object to add the component to.", "Ok")){}
            
        }//Selection > 0
        
    }//Create_CharMover
    
    
//////////////////////////////////////
///
///     HELPERS
///
///////////////////////////////////////
    
    
    [MenuItem("Dizzy Media/Easy Selector/Retro Edition/Helpers/Parallax", false , 0)]
    public static void Create_Parallax() {
        
        if(Selection.gameObjects.Length > 0){
            
            Selection.gameObjects[0].AddComponent<Parallax>();
        
        //Selection > 0
        } else {
            
            if(EditorUtility.DisplayDialog("Error", "You must select an object to add the component to.", "Ok")){}
            
        }//Selection > 0
        
    }//Create_Parallax
    

}//ESRetro_Menu
