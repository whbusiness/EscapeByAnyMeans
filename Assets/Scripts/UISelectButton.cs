using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISelectButton : MonoBehaviour
{
    public Button primaryButton;
    
    void Start()
    {
        primaryButton.Select();
    }
}
