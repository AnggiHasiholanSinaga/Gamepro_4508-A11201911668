using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour{
    int score;
    public void OnPlay(){
        SceneManager.LoadScene("Difficulty");
    }
    public void OnCredits(){
        SceneManager.LoadScene("Credits");
    }
    public void OnCreditsPlus(){
        SceneManager.LoadScene("Credits+");
    }
    public void OnHelp(){
        SceneManager.LoadScene("Help");
    }
    public void OnHelpPlus(){
        SceneManager.LoadScene("Help+");
    }
    public void OnHelp2(){
        SceneManager.LoadScene("Help1");
    }
    public void OnHelp2Plus(){
        SceneManager.LoadScene("Help1+");
    }
    public void OnBack(){
        SceneManager.LoadScene("Menu");
    }
    public void OnExit(){
        Application.Quit();
    }
    public void OnNewbie(){
        SceneManager.LoadScene("Newbie");
    }
    public void OnNormal(){
        SceneManager.LoadScene("Normal");
    }
    public void OnExpert(){
        SceneManager.LoadScene("Expert");
    }
    public void OnWinBoss(){
        SceneManager.LoadScene("Menu+");
    }
    public void OnExtraPlay(){
        SceneManager.LoadScene("Difficulty+");
    }
    public void OnSecret(){
        SceneManager.LoadScene("Secret");
    }
    public void OnWarn(){
        SceneManager.LoadScene("SecretWarning");
    }
}
