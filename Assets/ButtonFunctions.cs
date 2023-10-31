using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using TMPro;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("directions");
    }

    public void PlayGame()
    {
        string s = nameInput.text;
        Debug.Log("your name is: " + s);
        //store in persistent data
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menuScene");
    }
}
