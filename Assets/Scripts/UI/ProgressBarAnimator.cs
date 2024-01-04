using Auxiliars;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarAnimator : MonoBehaviour {

    [SerializeField]
    Image delayedForeground;
    [SerializeField]
    Image foreground;
    [SerializeField]
    TextMeshProUGUI percentageText;

    private const float SPEED = 0.5f;
    private const float DELAYED_SPEED = SPEED / 2f;
    private float targetValue;
    public bool IsAnimating {  get; private set; }
    public bool IsAnimationFinished => delayedForeground.fillAmount >= targetValue && foreground.fillAmount >= targetValue;

    private void OnEnable ()
    {
        delayedForeground.fillAmount = 0;
        foreground.fillAmount = 0;
        this.IsAnimating = false;
    }

    private void Update () {
        if (!this.IsAnimating || IsAnimationFinished)
        {
            this.IsAnimating = false;
            return;
        }
        delayedForeground.fillAmount += Time.deltaTime * DELAYED_SPEED;
        foreground.fillAmount += Time.deltaTime * SPEED;
        delayedForeground.fillAmount = SpartanMath.Clamp(delayedForeground.fillAmount, 0, targetValue);
        foreground.fillAmount = SpartanMath.Clamp(foreground.fillAmount, 0, targetValue);
        
        //Animate the associated text as well
        if (percentageText == null) return;
        //Note: this could be a lerp, but for now this will do
        float percentage = delayedForeground.fillAmount * 100f;
        this.percentageText.text = $"{SpartanMath.RoundToSignificantFigures(percentage, 3)}%";
    }

    public void StartAnimation(float targetValue, float maxPossibleValue)
    {
        this.IsAnimating = true;
        this.targetValue = targetValue / maxPossibleValue;
    }

}
