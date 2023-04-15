using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISceneChange : MonoBehaviour
{

    [SerializeField] Button button;

    void ChangeScene()
    {
        SceneManager.LoadScene("level02");
    }
    private void Start()
    {
        button.onClick.AddListener(ChangeScene);
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
            ChangeScene();
    }
}
