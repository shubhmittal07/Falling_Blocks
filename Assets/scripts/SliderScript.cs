using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    //public Player player;
    [SerializeField]private Slider _slider;
    [SerializeField]private TextMeshProUGUI _sliderText;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("senstivity") != null){
            _slider.value = PlayerPrefs.GetInt("senstivity");
            _sliderText.text = PlayerPrefs.GetInt("senstivity").ToString();
        }
        else{
            _sliderText.text = "5.0";
            _slider.value = 5;
        }
        _slider.onValueChanged.AddListener((v) => {
            _sliderText.text = v.ToString("0.0");
            PlayerPrefs.SetInt("senstivity", (int)v);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
