using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public Transform popUpCanvas;
    [SerializeField]
    private TutorialManager tutorialManager;
    public GameObject DisplayPopUp(GameObject prefab)
    {
        
        GameObject popUp = Instantiate(prefab, new Vector3(prefab.transform.position.x, prefab.transform.position.y, 0), Quaternion.identity);
        popUp.transform.SetParent(popUpCanvas, false);
        popUp.GetComponentInChildren<Button>()?.onClick.AddListener(tutorialManager.NextScreen);


        return popUp;
    }
}
