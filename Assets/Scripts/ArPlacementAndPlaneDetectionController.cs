using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ArPlacementAndPlaneDetectionController : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;
    ArPlaceManager m_ARPlacementManager;


    public GameObject placeButton;
    public GameObject adjustButton;
    public GameObject searchForGameButton;
    public GameObject scaleSlider;


    public TextMeshProUGUI informUIPanel_text;

    private void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        m_ARPlacementManager = GetComponent<ArPlaceManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        placeButton.SetActive(true);
        scaleSlider.SetActive(true);
        adjustButton.SetActive(false);
        searchForGameButton.SetActive(false);

        informUIPanel_text.text = "Move phone to detect planes and place the Cans!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableARPlacementAndPlaneDetection()
    {
        m_ARPlaneManager.enabled = false;
        m_ARPlacementManager.enabled = false;
        scaleSlider.SetActive(false);
        SetAllPlanesActiveOrDeactive(false);
        placeButton.SetActive(false);
        adjustButton.SetActive(true);
        searchForGameButton.SetActive(true);

        informUIPanel_text.text = "Great! You placed the CANS! Let's start the game";
    }

    public void EnableARPlacementAndPlaneDetection()
    {
        m_ARPlaneManager.enabled = true;
        m_ARPlacementManager.enabled = true;
        SetAllPlanesActiveOrDeactive(true);
        placeButton.SetActive(true);
        scaleSlider.SetActive(true);
        adjustButton.SetActive(false);
        searchForGameButton.SetActive(false);

        informUIPanel_text.text = "Move phone to detect planes and place the Cans!";
    }

    private void SetAllPlanesActiveOrDeactive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
