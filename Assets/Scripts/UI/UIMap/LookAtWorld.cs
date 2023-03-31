using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LookAtWorld : MonoBehaviour {
    
    private Camera cameraMap;
    private Camera cameraWorld;
    private Button lookAtWorldButton;

    void Start(){
    }

    void Update(){
    }
    
    public void setup(Camera cameraMap, Camera cameraWorld){
        this.cameraMap = cameraMap;
        this.cameraWorld = cameraWorld;
        this.lookAtWorldButton = gameObject.GetComponenet<Button>();
        this.lookAtWorldButton.onClick.AddListener(lookAtWorld);
    }

    private void lookAtWorld() {
        cameraMap.setInactive();
        cameraWorld.setActive();
    }
}
