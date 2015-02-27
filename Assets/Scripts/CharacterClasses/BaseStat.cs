﻿

public class BaseStat  {

	private int _baseValue;             //the base value of the stat
	private int _buffValue;             //amount that we buss the stat by
	private int _expToLevel; 			//how much exp is needed to exp the stat
	private float _levelModifier;		// modifier applied to the exp needed to raiser the skill

	public BaseStat()
	{
		_baseValue = 0;
		_buffValue = 0;
		_expToLevel = 100;
		_levelModifier = 1.1f;
	}
	#region Bsic Setters and Getters
	// STTERS AND GUTTERS

	public int BaseValue
	{
		get{ return _baseValue;}
		set{ _baseValue = value;}

	}

	public int BuffValue
	{
		get{ return _buffValue;}
		set{ _buffValue = value;}
		
	}

	public int ExpToLevel
	{
		get{ return _expToLevel;}
		set{ _expToLevel = value;}
		
	}

	public float LevelModifier
	{
		get{ return _levelModifier;}
		set{ _levelModifier = value;}
		
	}

	#endregion

	private int CalcExpToLevel()
	{
		return (int)(_expToLevel * _levelModifier);
	}
	public void LevelUp()
	{
		_expToLevel = CalcExpToLevel();
		_baseValue ++;
	}
	public int AdjustedBaseValue{
		get{return _baseValue + BuffValue;}
	}
}
