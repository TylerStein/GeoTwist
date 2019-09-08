using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    public void setLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }
}
