using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.PlayerLoop;

public class GameObjectLifecycle : MonoBehaviour
{
    [SerializeField] int field;

    // This function is always called before any Start functions and
    // also just after a prefab is instantiated.
    // (If a GameObject is inactive during start up
    // Awake is not called until it is made active.
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // (only called if the Object is active):
    // This function is called just after the object is enabled.
    // This happens when a MonoBehaviour instance is created,
    // such as when a level is loaded or a GameObject
    // with the script component is instantiated.
    private void OnEnable()
    {
        Debug.Log("Enable");
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    // Reset is called to initialize the script’s properties
    // when it is first attached to an object and also when
    // the Reset command is used.
    private void Reset()
    {
        Debug.Log("Reset");
    }

    // Start is called before the first frame update
    // only if the script instance is enabled.
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
    }

    // LateUpdate is called once per frame, after Update has finished.
    // Any calculations that are performed in Update will have completed
    // when LateUpdate begins. A common use for LateUpdate would be a
    // following third-person camera. If you make your character move
    // and turn inside Update, you can perform all camera movement and
    // rotation calculations in LateUpdate. This will ensure that the
    // character has moved completely before the camera tracks its position
    private void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    // FixedUpdate is often called more frequently than Update.
    // It can be called multiple times per frame, if the frame rate
    // is low and it may not be called between frames at all if the
    // frame rate is high.All physics calculations and updates occur
    // immediately after FixedUpdate.When applying movement
    // calculations inside FixedUpdate, you do not need to multiply
    // your values by Time.deltaTime.This is because FixedUpdate is
    // called on a reliable timer, independent of the frame rate.
    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    // This is called at the end of the frame where the pause is detected,
    // effectively between the normal frame updates. One extra frame
    // will be issued after OnApplicationPause is
    // called to allow the game to show graphics that indicate the paused state.
    private void OnApplicationPause(bool pause)
    {
        Debug.Log("OnPause " + pause.ToString()) ;
    }

    // This function is called on all game objects before the application is quit.
    // In the editor it is called when the user stops playmode.
    private void OnApplicationQuit()
    {
        Debug.Log("OnQuit");
    }


    // OnValidate is called whenever the script’s properties are set,
    // including when an object is deserialized, which can occur at various times,
    // such as when you open a scene in the Editor and after a domain reload.
    private void OnValidate()
    {
        Debug.Log("OnValidate");
    }

    // This is called when the application gets into or out of focus.
    private void OnApplicationFocus(bool focus)
    {
        Debug.Log("OnFocus " + focus.ToString());
    }
}
