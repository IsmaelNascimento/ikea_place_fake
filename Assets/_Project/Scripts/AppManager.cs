using System.Collections.Generic;
using UnityARInterface;
using UnityEngine;

public class AppManager : ARBase
{
    public static AppManager Instance;

    [Header("Prefabs")]
    [SerializeField] private CardSection prefabCardSection;

    private Transform contentCurrentInstantiate;

    [Header("Others")]
    [SerializeField] private ARFocusSquareAltered focusSquare;
    private GameObject objSelectedCurrent = null;
    [SerializeField] private GameObject uiSelectedModel;


    [Header("Scroll Contents")]
    [SerializeField] private Transform contentSectionParent;
    public Transform contentViewAboutModel;

    [Header("Contents")]
    [SerializeField] private List<Category> categorys;

    [Header("Screens")]
    [SerializeField] private GameObject screenWarningLoadContent;
    public GameObject screenViewAboutModel;

    #region MonoBehaviour

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        LoadCardSections();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var camera = GetCamera();

            if (camera == null)
                return;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, float.MaxValue))
            {
                var content = rayHit.transform;

                if(content.tag == "Player")
                {
                    objSelectedCurrent = content.gameObject;
                    uiSelectedModel.SetActive(true);
                    print("Content AR name:: " + content.name);
                }
                else
                {
                    print("Conten normal with name:: " + content.name);
                }
            }
        }
    }

    #endregion

    #region Methods Created

    private void LoadCardSections()
    {
        foreach (var category in categorys)
        {
            var section = Instantiate(prefabCardSection, contentSectionParent);
            section.titleSection = category.nameCategory;
            section.cardContents = category.contents;
        }

        screenWarningLoadContent.SetActive(false);
    }

    #endregion

    #region User Interface

    public void OnButtonARNowClicked()
    {
        var content = Instantiate(contentCurrentInstantiate, focusSquare.OnFoundPlanePosition, Quaternion.identity);
        print("New content:: " + content.name);
    }

    public void GetContentCurrent(Transform prefabCurrent)
    {
        contentCurrentInstantiate = prefabCurrent;
    }

    public void OnButtonDeleteModelClicked()
    {
        Destroy(objSelectedCurrent);
        uiSelectedModel.SetActive(false);
    }

    #endregion
}