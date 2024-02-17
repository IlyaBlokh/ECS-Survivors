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
    
    public AbilityId Id;
    public Image Icon;
    public TextMeshProUGUI Description;
    public Button SelectCardButton;
    public GameObject Stamp;
    
    private Action<AbilityId> _onSelected;

    public AbilityCard Setup(AbilityId id, AbilityLevel abilityLevel, Action<AbilityId> onSelected)
    {
      _onSelected = onSelected;
      Id = id;
      Icon.sprite = abilityLevel.Icon;
      Description.text = abilityLevel.Description;

      SelectCardButton.onClick.AddListener(SelectCard);

      return this;
    }

    private void OnDestroy() => 
      SelectCardButton.onClick.RemoveListener(SelectCard);

    private void SelectCard() => 
      StartCoroutine(StampAndReport());

    private IEnumerator StampAndReport()
    {
      Stamp.SetActive(true);
      yield return new WaitForSeconds(StampAnimationTime);
      
      _onSelected(Id);
    }
  }}