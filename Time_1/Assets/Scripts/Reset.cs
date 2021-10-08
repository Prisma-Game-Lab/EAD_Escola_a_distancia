using UnityEngine;
using UnityEngine.SceneManagement;
public class Reset : MonoBehaviour {

    public VariableManager variableManager;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            variableManager.clara=true;
            variableManager.ericson=true;
            variableManager.maria=true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}