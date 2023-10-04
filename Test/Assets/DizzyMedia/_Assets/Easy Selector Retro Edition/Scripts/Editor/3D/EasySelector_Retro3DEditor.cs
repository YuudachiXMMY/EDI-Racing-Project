using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[CustomEditor(typeof(EasySelector_Retro3D))]
public class EasySelector_Retro3DEditor : Editor {
    

//////////////////////////
//
//      EDITOR DISPLAY
//
//////////////////////////
    
    
    EasySelector_Retro3D easySel_Retr3D;
    GUISkin oldSkin;
    
    private void OnEnable() {
        
        easySel_Retr3D = (EasySelector_Retro3D)target;
        
    }//OnEnable
    
    public override void OnInspectorGUI() { 
    
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
    
        GUILayout.Space(15);
        
        var style = new GUIStyle(EditorStyles.largeLabel) {alignment = TextAnchor.MiddleCenter};
        
        if(oldSkin == null){
        
            if(oldSkin != Resources.Load("EditorContent/EasySelector Skin") as GUISkin){

                oldSkin = GUI.skin;

                //Debug.Log("Old Skin Name " + GUI.skin.name);

            }//oldSkin != IWC Skin
            
        }//oldSkin == null
        
        GUI.skin = Resources.Load("EditorContent/EasySelector Skin") as GUISkin;
        
        Texture2D t = (Texture2D)Resources.Load("EditorContent/Editor-Icon");
        
        GUILayout.BeginHorizontal("Retro 3D", "headerText");
        
        GUILayout.Label(t, "headerIcon");
        
        EditorGUILayout.EndHorizontal();
        
        GUILayout.Space(5);
        
        GUI.skin = oldSkin;
        
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        
        EditorGUILayout.Space();
        
        EditorGUILayout.BeginVertical();
        
        easySel_Retr3D.tabs = GUILayout.SelectionGrid(easySel_Retr3D.tabs, new string[] { "User Options", "Events", "Debug/Gizmos"}, 3);
        
        EditorGUI.BeginChangeCheck();
        
        SerializedProperty actionInput = serializedObject.FindProperty("actionInput");
        SerializedProperty directionInput = serializedObject.FindProperty("directionInput");
        
        SerializedProperty character = serializedObject.FindProperty("character");
        SerializedProperty charNameText = serializedObject.FindProperty("charNameText");
        
        SerializedProperty bgCurve = serializedObject.FindProperty("bgCurve");
        SerializedProperty bgMath = serializedObject.FindProperty("bgMath");
        
        SerializedProperty charMoveCurvePercent = serializedObject.FindProperty("charMoveCurvePercent");
        
        SerializedProperty audSource = serializedObject.FindProperty("audSource");
        
        SerializedProperty moveAudClip = serializedObject.FindProperty("moveAudClip");
        SerializedProperty randMoveClips = serializedObject.FindProperty("randMoveClips");
        
        SerializedProperty selectClip = serializedObject.FindProperty("selectClip");
        SerializedProperty lateSelectClip = serializedObject.FindProperty("lateSelectClip");
        
        SerializedProperty flashImg = serializedObject.FindProperty("flashImg");
        SerializedProperty selFlashCol = serializedObject.FindProperty("selFlashCol");
        
        SerializedProperty charVects = serializedObject.FindProperty("charVects");
        SerializedProperty charAnim = serializedObject.FindProperty("charAnim");
        
        SerializedProperty selectEvent = serializedObject.FindProperty("selectEvent");
        
        EditorGUILayout.Space();
        
        if(easySel_Retr3D.tabs == 0){
        
            easySel_Retr3D.startTab = GUILayout.Toggle(easySel_Retr3D.startTab, "Start Options", GUI.skin.button);
            
            if(easySel_Retr3D.startTab){

                EditorGUILayout.Space();
                
                easySel_Retr3D.createInstance = EditorGUILayout.Toggle("Create Instance?", easySel_Retr3D.createInstance);
                
                EditorGUILayout.Space();
                
                easySel_Retr3D.startWait = EditorGUILayout.FloatField("Start Wait", easySel_Retr3D.startWait);
                
            }//startTab
            
            EditorGUILayout.Space();
        
            easySel_Retr3D.inputTab = GUILayout.Toggle(easySel_Retr3D.inputTab, "Input Options", GUI.skin.button);

            if(easySel_Retr3D.inputTab){

                EditorGUILayout.Space();
                
                easySel_Retr3D.useActionInput = EditorGUILayout.Toggle("Use Action Input?", easySel_Retr3D.useActionInput);
                
                if(easySel_Retr3D.useActionInput){
                
                    EditorGUILayout.PropertyField(actionInput, true);
                
                }//useActionInput
                
                EditorGUILayout.Space();
                
                easySel_Retr3D.useDirInput = EditorGUILayout.Toggle("Use Directional Input?", easySel_Retr3D.useDirInput);

                if(easySel_Retr3D.useDirInput){
                
                    EditorGUILayout.PropertyField(directionInput, true);
                
                }//useDirInput
                
            }//inputTab

            EditorGUILayout.Space();
            
            easySel_Retr3D.charTab = GUILayout.Toggle(easySel_Retr3D.charTab, "Characters Options", GUI.skin.button);
            
            if(easySel_Retr3D.charTab){

                EditorGUILayout.Space();
                
                EditorGUILayout.PropertyField(character, true);
                
                EditorGUILayout.Space();
                
                easySel_Retr3D.useNames = EditorGUILayout.Toggle("Use Names?", easySel_Retr3D.useNames);
                
                if(easySel_Retr3D.useNames){
                
                    EditorGUILayout.PropertyField(charNameText, true);
                
                }//useNames
                
            }//charTab
            
            EditorGUILayout.Space();
            
            easySel_Retr3D.moveTab = GUILayout.Toggle(easySel_Retr3D.moveTab, "Movement Options", GUI.skin.button);
            
            if(easySel_Retr3D.moveTab){

                EditorGUILayout.Space();
                
                easySel_Retr3D.useMovement = EditorGUILayout.Toggle("Use Movement?", easySel_Retr3D.useMovement);

                EditorGUILayout.Space();
                
                EditorGUILayout.PropertyField(charMoveCurvePercent, true);
                
                easySel_Retr3D.distMulti = EditorGUILayout.FloatField("Distance Multi", easySel_Retr3D.distMulti);
                easySel_Retr3D.distMulti2 = EditorGUILayout.FloatField("Distance Multi 2", easySel_Retr3D.distMulti2);
                
                EditorGUILayout.Space();
                
                EditorGUILayout.PropertyField(bgCurve, true);
                EditorGUILayout.PropertyField(bgMath, true);
                
            }//moveTab
            
            EditorGUILayout.Space();
            
            easySel_Retr3D.audioTab = GUILayout.Toggle(easySel_Retr3D.audioTab, "Audio Options", GUI.skin.button);
            
            if(easySel_Retr3D.audioTab){

                EditorGUILayout.Space();
                
                easySel_Retr3D.useSounds = EditorGUILayout.Toggle("Use Sounds?", easySel_Retr3D.useSounds);
                EditorGUILayout.PropertyField(audSource, true);
                
                EditorGUILayout.Space();
                
                easySel_Retr3D.useMoveClip = EditorGUILayout.Toggle("Use Move Clip?", easySel_Retr3D.useMoveClip);
                
                if(easySel_Retr3D.useMoveClip){
                
                    easySel_Retr3D.randomMoveClip = EditorGUILayout.Toggle("Random Move Clip?", easySel_Retr3D.randomMoveClip);
                    EditorGUILayout.PropertyField(moveAudClip, true);
                    
                    if(easySel_Retr3D.randomMoveClip){
                    
                        EditorGUILayout.PropertyField(randMoveClips, true);
                
                    }//randomMoveClip
                
                }//useMoveClip
                
                EditorGUILayout.Space();
                
                easySel_Retr3D.useSelectClip = EditorGUILayout.Toggle("Use Select Clip?", easySel_Retr3D.useSelectClip);
                
                if(easySel_Retr3D.useSelectClip){
                
                    EditorGUILayout.PropertyField(selectClip, true);
                
                }//useSelectClip
                
                EditorGUILayout.Space();
                
                easySel_Retr3D.useLateSelect = EditorGUILayout.Toggle("Use Late Select?", easySel_Retr3D.useLateSelect);
                
                if(easySel_Retr3D.useLateSelect){
                
                    EditorGUILayout.PropertyField(lateSelectClip, true);
                    easySel_Retr3D.lateSelectWait = EditorGUILayout.FloatField("Late Select Wait", easySel_Retr3D.lateSelectWait);
                
                }//useLateSelect
                
            }//audioTab
            
            EditorGUILayout.Space();
            
            easySel_Retr3D.flashTab = GUILayout.Toggle(easySel_Retr3D.flashTab, "Flash Options", GUI.skin.button);
            
            if(easySel_Retr3D.flashTab){

                EditorGUILayout.Space();
                
                easySel_Retr3D.useFlash = EditorGUILayout.Toggle("Use Screen Flash?", easySel_Retr3D.useFlash);
                
                EditorGUILayout.Space();
                
                EditorGUILayout.PropertyField(flashImg, true);
                EditorGUILayout.PropertyField(selFlashCol, true);
                
                EditorGUILayout.Space();
                
                easySel_Retr3D.flashMulti = EditorGUILayout.FloatField("Flash Multi", easySel_Retr3D.flashMulti);
                easySel_Retr3D.flashMultiReset = EditorGUILayout.FloatField("Flash Multi Reset", easySel_Retr3D.flashMultiReset);
                easySel_Retr3D.flashMultiBuff = EditorGUILayout.FloatField("Flash Multi Buff", easySel_Retr3D.flashMultiBuff);
                
            }//flashTab
        
        }//tabs = user options
        
        if(easySel_Retr3D.tabs == 1){
        
            EditorGUILayout.Space();
            
            EditorGUILayout.PropertyField(selectEvent, true);
            
        }//tabs = events
        
        if(easySel_Retr3D.tabs == 2){
        
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Debug Notifications", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.Space();

            easySel_Retr3D.debugInt = GUILayout.Toolbar(easySel_Retr3D.debugInt, new string[] { "OFF", "ON" });

            if(easySel_Retr3D.debugInt == 0){

                easySel_Retr3D.useDebug = false;

            }//debugInt == 0

            if(easySel_Retr3D.debugInt == 1){

                easySel_Retr3D.useDebug = true;

            }//debugInt == 1
            
            GUILayout.Space(15);
            
            EditorGUILayout.LabelField("Gizmos", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.Space();

            easySel_Retr3D.gizmoInt = GUILayout.Toolbar(easySel_Retr3D.gizmoInt, new string[] { "OFF", "ON" });

            if(easySel_Retr3D.gizmoInt == 0){

                easySel_Retr3D.drawGizmos = false;

            }//gizmoInt == 0

            if(easySel_Retr3D.gizmoInt == 1){

                easySel_Retr3D.drawGizmos = true;
                
                EditorGUILayout.Space();
                
                easySel_Retr3D.gizmoRadius = EditorGUILayout.FloatField("Gizmo Radius", easySel_Retr3D.gizmoRadius);

            }//gizmoInt == 1
            
            GUILayout.Space(15);

            EditorGUILayout.LabelField("Automatic Values", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.Space();
            
            easySel_Retr3D.detInput = EditorGUILayout.Toggle("Detect Input", easySel_Retr3D.detInput);
            
            EditorGUILayout.Space();
            
            easySel_Retr3D.tempInt = EditorGUILayout.IntField("Temp Int", easySel_Retr3D.tempInt);
            easySel_Retr3D.curChar = EditorGUILayout.IntField("Cur Char", easySel_Retr3D.curChar);
            
            EditorGUILayout.Space();
            
            EditorGUILayout.PropertyField(charVects, true);
            EditorGUILayout.PropertyField(charAnim, true);
            
            EditorGUILayout.Space();
            
            easySel_Retr3D.flash = EditorGUILayout.Toggle("Flash", easySel_Retr3D.flash);
            easySel_Retr3D.flashColorUpdate = EditorGUILayout.Toggle("Flash Color Update", easySel_Retr3D.flashColorUpdate);
            easySel_Retr3D.flashLock = EditorGUILayout.Toggle("Flash Lock", easySel_Retr3D.flashLock);
            
            EditorGUILayout.Space();
            
            easySel_Retr3D.moveLeft = EditorGUILayout.Toggle("Move Left", easySel_Retr3D.moveLeft);
            easySel_Retr3D.moveRight = EditorGUILayout.Toggle("Move Right", easySel_Retr3D.moveRight);
        
        }//tabs = auto
        
        EditorGUILayout.Space();
        
        if(EditorGUI.EndChangeCheck()){

            serializedObject.ApplyModifiedProperties();

        }//EndChangeCheck
  
        if(GUI.changed){
            
            EditorUtility.SetDirty(easySel_Retr3D);
            
            if(!EditorApplication.isPlaying){
            
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            
            }//!isPlaying
        
        }//changed
        
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.EndVertical();
        
    }//OnInspectorGUI
    
}
