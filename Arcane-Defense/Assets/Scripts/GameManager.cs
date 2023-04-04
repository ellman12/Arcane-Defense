using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Spells;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
	public EventHandler RoundAdvance;

	[SerializeField, Tooltip("The round that is guaranteed to be the first boss round.")]
	private int firstBossRound;

	[SerializeField, Tooltip("The odds [0-1] of the next round being a boss round.")]
	private float oddsOfBossRound;

	[SerializeField, Tooltip("How much the odds of a round being a boss round should increase after a round.")]
	private float oddsOfBossRoundDelta; //TODO: this needs to cap at 1 and eventually every round is a boss round. Probs use the clamp method.

	[SerializeField, Tooltip("How many seconds to wait until starting the next round.")]
	private float secondsUntilNextRound;
	private float remainingTime;

	[SerializeField, Tooltip("How many enemies there are in round 1. Increases each round by a random amount.")]
	private int startingEnemiesAmount;
	
	[SerializeField, Tooltip("When a round finishes, the min amount of enemies to add onto the the total number of enemies for the next round.")]
	private int minAdditionalEnemies;
	
	[SerializeField, Tooltip("When a round finishes, the max amount of enemies to add onto the the total number of enemies for the next round.")]
	private int maxAdditionalEnemies;

	[SerializeField, Tooltip("The areas in the scene where enemies can spawn.")]
	private List<EnemySpawner> enemySpawners;

	[SerializeField] private TextMeshProUGUI roundText, secondsRemainingText;

	[SerializeField, ReadOnly]
	private int roundNumber = 1, enemiesThisRound, enemiesAlive;

	public int RoundNumber
	{
		get => roundNumber;
		private set => roundNumber = value;
	}
	
	public int RemainingAmountToSpawn { get; set; }

	public int EnemiesAlive
	{
		get => enemiesAlive;
		set
		{
			enemiesAlive = value;
			if (RemainingAmountToSpawn <= 0 && enemiesAlive <= 0)
				StartCoroutine(AdvanceRound());
		}
	}
	
	private new void Awake()
	{
		secondsRemainingText.text = "";
		RemainingAmountToSpawn = EnemiesAlive = enemiesThisRound = startingEnemiesAmount;
		
		if (ChainLightning.targets != null || ChainLightning.targets.Count > 0)
		{
			Debug.Log(ChainLightning.targets.Count);
			ChainLightning.targets.Clear();
		}
	}
	
	private IEnumerator AdvanceRound()
	{
		remainingTime = secondsUntilNextRound;
		secondsRemainingText.text = remainingTime.ToString();
		
		foreach (var enemySpawner in enemySpawners)
			enemySpawner.enabled = false;

		yield return null;
		
		while (remainingTime > 0)
		{
			remainingTime -= Time.deltaTime;
			secondsRemainingText.text = Mathf.RoundToInt(remainingTime).ToString();
			yield return null;
		}

		secondsRemainingText.text = "";
		
		yield return null;
		
		roundNumber++;
		roundText.text = $"Round {roundNumber}";
		yield return null;
		RoundAdvance?.Invoke(this, EventArgs.Empty);

		yield return new WaitForSeconds(0.1f);
		
		foreach (var enemySpawner in enemySpawners)
			enemySpawner.enabled = true;

		enemiesThisRound += Random.Range(minAdditionalEnemies, maxAdditionalEnemies);
		RemainingAmountToSpawn = EnemiesAlive = enemiesThisRound;
	}
	
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ExitGame()
	{
		#if UNITY_EDITOR
				EditorApplication.isPlaying = false;
		#else
		            Application.Quit();
		#endif
	}
}