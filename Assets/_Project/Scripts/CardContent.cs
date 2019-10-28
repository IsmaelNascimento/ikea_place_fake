using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContent : MonoBehaviour
{
    public Transform prefabContent;
    public Sprite imageContent;
    public string titleContent;
    public float price;
    public List<Sprite> images;
    public string urlContent;
    [Space(10)]
    [SerializeField] private Image imgContent;
    [SerializeField] private Text txtTitleContent;
    [SerializeField] private Text txtPrice;
    [Header("Prefabs")]
    [SerializeField] private CardImageModel prefabCardImageModel;
    private Button button;

    private void Start()
    {
        txtTitleContent.text = titleContent;
        txtPrice.text = string.Format("PREÇO: R${0}", price);
        imgContent.sprite = imageContent;
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            AppManager.Instance.screenViewAboutModel.SetActive(true);
            AppManager.Instance.screenViewAboutModel.GetComponent<ScreenViewAboutModel>().urlContent = urlContent;
            AppManager.Instance.GetContentCurrent(prefabContent);

            for (int i = 0; i < AppManager.Instance.contentViewAboutModel.childCount; i++)
                Destroy(AppManager.Instance.contentViewAboutModel.GetChild(i).gameObject);

            for (int i = 1; i < images.Count; i++)
            {
                var cardImageModel = Instantiate(prefabCardImageModel, AppManager.Instance.contentViewAboutModel);
                cardImageModel.image = images[i];
            }
        });
    }
}