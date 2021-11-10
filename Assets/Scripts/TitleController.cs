using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleController : MonoBehaviour {
    [SerializeField]
    private bool onAnimation = true;

    [SerializeField]
    private float dialogheight = 0.0f;

    [SerializeField]
    private float settingsDuration = 0.5f;

    [SerializeField]
    private float dialogDuration = 0.5f;

    [SerializeField]
    private GameObject fillter;

    [SerializeField]
    private RectTransform settings;

    [SerializeField]
    private RectTransform dialog;

    // Start is called before the first frame update
    void Start() {
        if (fillter.activeSelf) fillter.SetActive(false);
        if (settings.gameObject.activeSelf) settings.gameObject.SetActive(false);
        if (dialog.gameObject.activeSelf) dialog.gameObject.SetActive(false);
    }

    public void ShowSettings() {
        if (onAnimation) {
            settings.transform.localScale = new Vector3(0, 0, 0);
            ActiveUI(settings.gameObject, true);
            settings.transform.DOScale(new Vector3(1, 1, 1), settingsDuration);
        }
        else {
            ActiveUI(settings.gameObject, true);
        }
    }

    public void ShowDialog() {
        if (onAnimation) {
            dialog.position = new Vector3(Screen.width/2, -dialogheight, 0);
            ActiveUI(dialog.gameObject, true);
            dialog.DOMoveY(Screen.height/2, dialogDuration);
        }
        else {
            ActiveUI(dialog.gameObject, true);
        }
    }

    public void HideSettings() {
        if (onAnimation) {
            settings.transform
                .DOScale(new Vector3(0, 0, 0), settingsDuration)
                .OnComplete(() => {
                    ActiveUI(settings.gameObject, false);
                });
        }
        else {
            ActiveUI(settings.gameObject, false);
        }
    }

    public void HideDialog() {
        if (onAnimation) {
            dialog.transform
                .DOMoveY(-dialogheight, dialogDuration)
                .OnComplete(() => {
                    ActiveUI(dialog.gameObject, false);
                });
        }
        else {
            ActiveUI(dialog.gameObject, false);
        }
    }

    private void ActiveUI(GameObject uiObj, bool active) {
        uiObj.SetActive(active);
        fillter.SetActive(active);
    }
}
