using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject introCamera;
    [SerializeField] GameObject introGroup;
    [SerializeField] GameObject ingameGroup;

    [SerializeField] Image gateImage;
    [SerializeField] GameObject settingGroup;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject textPanel;
    [SerializeField] Text panelText;
    [SerializeField] GameObject clearText;

    bool ingame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        player.SetActive(true);
        playerCamera.SetActive(true);
        introCamera.SetActive(false);

        introGroup.SetActive(false);
        ingameGroup.SetActive(true);
        helpPanel.SetActive(true);

        ingame = true;
    }

    public void HelpOpen()
    {
        introGroup.SetActive(false);
        settingGroup.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void HelpClose()
    {
        helpPanel.SetActive(false);
        if (!ingame)
            introGroup.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void AllGateOpened()
    {
        gateImage.color = new Color(1, 1, 1, 1);
    }

    public void SettingOpen()
    {
        settingGroup.SetActive(true);
    }

    public void SettingClose()
    {
        settingGroup.SetActive(false);
    }

    public void DisplayTextPanel(string inputText)
    {
        panelText.text = inputText + " [E]";
        textPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        textPanel.SetActive(false);
    }

    public bool PanelActive()
    {
        return textPanel.activeSelf;
    }

    public void DisplayClear()
    {
        clearText.SetActive(true);
        Invoke("HideClear", 3f);
    }

    void HideClear()
    {
        clearText.SetActive(false);
    }
}
