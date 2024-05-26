using System;
using System.Collections;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviours
{
  public class AbilityCard : MonoBehaviour
  {
    private const float StampAnimationTime = 1f;
    public AbilityId AbilityId;
    public Image Icon;
    public TextMeshProUGUI Description;
    public Button Button;
    public GameObject Stamp;
    
    private Action<AbilityId> _onSelected;

    public void Setup(AbilityId abilityId, AbilityLevel abilityLevel, Action<AbilityId> onSelected)
    {
      AbilityId = abilityId;
      Icon.sprite = abilityLevel.Icon;
      Description.text = abilityLevel.Description;
      _onSelected = onSelected;
      Button.onClick.AddListener(SelectCard);
    }

    private void SelectCard()
    {
      StartCoroutine(StampAndReport());
    }

    private IEnumerator StampAndReport()
    {
      Stamp.SetActive(true);
      yield return new WaitForSeconds(StampAnimationTime);
      _onSelected.Invoke(AbilityId);
    }
  }
}