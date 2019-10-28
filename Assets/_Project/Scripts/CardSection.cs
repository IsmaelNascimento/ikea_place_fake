using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSection : MonoBehaviour
{
    [Header("External")]
    public Transform contentParent;
    public string titleSection;
    public List<ContentAR> cardContents;

    [Header("Components")]
    [SerializeField] private Text txtTitleSection;

    [Header("Prefabs")]
    [SerializeField] private CardContent prefabCardContent;

    private void Start()
    {
        txtTitleSection.text = titleSection;
        LoadCardContens();
    }

    private void LoadCardContens()
    {
        foreach (var cardContent in cardContents)
        {
            var content = Instantiate(prefabCardContent, contentParent);
            content.imageContent = cardContent.images[0];
            content.titleContent = cardContent.name;
            content.price = cardContent.price;
            content.images = cardContent.images;
            content.urlContent = cardContent.linkProduct;
            content.prefabContent = cardContent.prefabModel.transform;
        }
    }
}