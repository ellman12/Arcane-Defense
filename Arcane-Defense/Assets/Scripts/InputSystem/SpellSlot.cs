using Spells;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class SpellSlot : MonoBehaviour
    {
        [SerializeField] private Image slotIcon;

        [SerializeField] private SpellInfo spellInfo;

        private float cooldownRemaining;

        private void OnEnable() => slotIcon.sprite = spellInfo.spellIcon;

        private void UseSpell()
        {
            
        }
    }
}