using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeSystem : MonoBehaviour
{
    [Range(1, 100)] public byte playerHP = 100;
    [SerializeField] Text hpGUIText;
    [SerializeField] Image healhBarImage;
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Sprite healthBarSlider_Green, healthBarSlider_Yellow, healthBarSlider_Red;
    [SerializeField] GameObject crosshair, weapontip, EnergyShotUpgrade, minimapGUI, MinimapUpgrade, KeyUpgrade, ClosedExit, OpenedExit,
        Menu, levelResults, restartMenu;
    [SerializeField] AudioSource gunGetSound, minimapGetSound, keyGetSound, happyEndSound, bgMusic, menuMusic, playerOuch;
    [SerializeField] DialogueSystem dialogueSystem;
    private bool exitIsOpened, lastlevel;
    private float menuTriggerTimer, menuTriggerMinimumTime = 0.4f;
    private Scene currentScene;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        UpdateHPtext();
        crosshair.SetActive(false);
        weapontip.SetActive(false);
        minimapGUI.SetActive(false);
        exitIsOpened = false;
        OpenedExit.SetActive(false);
        ClosedExit.SetActive(true);
        Menu.SetActive(false);
        restartMenu.SetActive(false);
        menuMusic.Stop();
        menuTriggerTimer = Time.timeSinceLevelLoad;
        currentScene = SceneManager.GetActiveScene();
        print(SceneManager.sceneCountInBuildSettings.ToString());
        if (currentScene.buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            lastlevel = false;
        }
        else
        {
            lastlevel = true;
        }
    }

    void Update()
    {
        if (Input.GetAxis("Cancel") > 0.3f)
        {
            if (Time.timeSinceLevelLoad - menuTriggerTimer > menuTriggerMinimumTime)
            {
                ToggleMenu();
            }
            menuTriggerTimer = Time.timeSinceLevelLoad;
        }
    }

    public void UpdateHPtext()
    {
        hpGUIText.text = "HP: " + playerHP.ToString() + "%";
        healthBarSlider.value = playerHP;
        if (playerHP > 50)
        {
            healhBarImage.sprite = healthBarSlider_Green;
        }
        else if (playerHP > 25)
        {
            healhBarImage.sprite = healthBarSlider_Yellow;
        }
        else
        {
            healhBarImage.sprite = healthBarSlider_Red;
        }
    }

    public void PurchaseEnergyShot()
    {
        if (playerHP <= 30)
        {
            PlayerIsDead();
        }
        else
        {
            playerHP -= 30;
            //playerOuch.Play();
            UpdateHPtext();
            EnableEnergyShot();
        }
    }

    public void PurchaseMinimap()
    {
        if (playerHP <= 30)
        {
            PlayerIsDead();
        }
        else
        {
            playerHP -= 30;
            //playerOuch.Play();
            UpdateHPtext();
            EnableMinimap();
        }
    }

    public void PurchaseKey()
    {
        if (playerHP <= 10)
        {
            PlayerIsDead();
        }
        else
        {
            playerHP -= 10;
            //playerOuch.Play();
            UpdateHPtext();
            EnableKey();
        }
    }

    void PlayerIsDead()
    {
        dialogueSystem.HideAllBottomText();
        playerHP = 0;
        playerOuch.Play();
        UpdateHPtext();
        hpGUIText.text = "OH NO!";
        crosshair.SetActive(false);
        restartMenu.SetActive(true);
        bgMusic.Stop();
        menuMusic.Play();
        Time.timeScale = 0.0f;
    }

    private void OnTriggerEnter(Collider triggerEntered)
    {
        if (triggerEntered.gameObject == EnergyShotUpgrade)
        {
            dialogueSystem.ShowEnergyShotMerchText();
        }
        if (triggerEntered.gameObject == MinimapUpgrade)
        {
            dialogueSystem.ShowMinimapMerchText();
        }
        if (triggerEntered.gameObject == KeyUpgrade)
        {
            dialogueSystem.ShowKeyMerchText();
        }
        if (triggerEntered.gameObject == ClosedExit)
        {
            dialogueSystem.ShowExitIsClosedText();
        }
        if (triggerEntered.gameObject == OpenedExit)
        {
            dialogueSystem.ShowExitIsOpenedText();
        }
    }


    private void OnTriggerStay(Collider triggerArea)
    {
        if (triggerArea.gameObject == EnergyShotUpgrade)
        {
            if (!weapontip.activeSelf && Input.GetAxis("Jump") > 0)
            {
                PurchaseEnergyShot();
            }
        }
        if (triggerArea.gameObject == MinimapUpgrade)
        {
            if (!minimapGUI.activeSelf && Input.GetAxis("Jump") > 0)
            {
                PurchaseMinimap();
            }
        }
        if (triggerArea.gameObject == KeyUpgrade)
        {
            if (!exitIsOpened && Input.GetAxis("Jump") > 0)
            {
                PurchaseKey();
            }
        }
        if (triggerArea.gameObject == OpenedExit)
        {
            if (exitIsOpened && Input.GetAxis("Jump") > 0)
            {
                FinishLevel();
            }
        }
    }

    private void OnTriggerExit(Collider triggerExited)
    {
        if (triggerExited.gameObject == EnergyShotUpgrade)
        {
            dialogueSystem.HideEnergyShotMerchText();
        }
        if (triggerExited.gameObject == MinimapUpgrade)
        {
            dialogueSystem.HideMinimapMerchText();
        }
        if (triggerExited.gameObject == KeyUpgrade)
        {
            dialogueSystem.HideKeyMerchText();
        }
        if (triggerExited.gameObject == ClosedExit)
        {
            dialogueSystem.HideExitIsClosedText();
        }
        if (triggerExited.gameObject == OpenedExit)
        {
            dialogueSystem.HideExitIsOpenedText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 13)
        {
            PlayerDamage();
        }
    }

    void EnableEnergyShot()
    {
        dialogueSystem.HideEnergyShotMerchText();
        crosshair.SetActive(true);
        weapontip.SetActive(true);
        gunGetSound.Play();
        EnergyShotUpgrade.SetActive(false);
    }

    void EnableMinimap()
    {
        dialogueSystem.HideMinimapMerchText();
        minimapGUI.SetActive(true);
        minimapGetSound.Play();
        MinimapUpgrade.SetActive(false);
    }

    void EnableKey()
    {
        dialogueSystem.HideKeyMerchText();
        exitIsOpened = true;
        keyGetSound.Play();
        KeyUpgrade.SetActive(false);
        ClosedExit.SetActive(false);
        OpenedExit.SetActive(true);
    }

    void FinishLevel()
    {
        if (currentScene.buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            happyEndSound.Play();
            hpGUIText.text = "GGWP!";
            dialogueSystem.ThanksForPlayingText();
            crosshair.SetActive(false);
            levelResults.SetActive(true);
            bgMusic.Stop();
            menuMusic.Play();
            Time.timeScale = 0.0f;
        }
        else
        {
            happyEndSound.Play();
            hpGUIText.text = "GGWP!";
            dialogueSystem.ThanksForPlayingText();
            crosshair.SetActive(false);
            Menu.SetActive(true);
            bgMusic.Stop();
            menuMusic.Play();
            Time.timeScale = 0.0f;
        }
    }

    void ToggleMenu()
    {
        switch (Menu.activeSelf)
        {
            case false:
                Menu.SetActive(true);
                bgMusic.Stop();
                menuMusic.Play();
                crosshair.SetActive(false);
                break;
            case true:
                Menu.SetActive(false);
                menuMusic.Stop();
                bgMusic.Play();
                crosshair.SetActive(weapontip.activeSelf);
                break;
            default:
                break;
        }
    }

    public void GoToNextLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(currentScene.buildIndex + 1, LoadSceneMode.Single);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayerDamage()
    {
        if (playerHP <= 5)
        {
            PlayerIsDead();
        }
        else
        {
            playerHP -= 5;
            playerOuch.Play();
            UpdateHPtext();
        }
    }
}
