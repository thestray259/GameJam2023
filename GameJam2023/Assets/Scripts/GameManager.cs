using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image foreground1;
    [SerializeField] Image foreground2;
    [SerializeField] Image foreground3;
    [SerializeField] Image foreground4;

    public bool sliderOn1 = false;
    public bool sliderOn2 = false;
    public bool sliderOn3 = false;
    public bool sliderOn4 = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (sliderOn1)
        {
            if (foreground1.fillAmount < 1)
            {
                foreground1.fillAmount += Time.deltaTime;
            }
        }
    }
}
