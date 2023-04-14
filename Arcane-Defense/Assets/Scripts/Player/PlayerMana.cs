using InputSystem;
using UnityEngine;
using Utilities;

namespace Player
{
	public class PlayerMana : Singleton<PlayerMana>
	{
		[SerializeField] private StatBar manaBar;
		[SerializeField] private float regenRate;
		[SerializeField] private int regenAmountMoving, regenAmountStationary;
		
		[SerializeField, ReadOnly] private int mana, maxMana;

		public int Mana
		{
			get => mana;
			set
			{
				mana = value;
				if (mana > maxMana)
					mana = maxMana;
				
				manaBar.SetValue(mana);
			}
		}

		public int MaxMana
		{
			get => maxMana;
			private set
			{
				maxMana = value;
				manaBar.SetMaxValue(maxMana);
			}
		}

		private void Start()
		{
			Mana = MaxMana = 100;
			InvokeRepeating(nameof(RegenerateMana), 0, regenRate);
		}

		private void RegenerateMana() => Mana += PlayerMovement.I.movementInput == Vector3.zero ? regenAmountStationary : regenAmountMoving;
	}
}