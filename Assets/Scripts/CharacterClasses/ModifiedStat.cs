
using System.Collections.Generic;


public struct ModifyingAttribute
{
	public Attribute attribute;
	public float ratio;
	
}


public class ModifiedStat : BaseStat {

	private List<ModifyingAttribute> _modst; //this is a list of attributes that modify the stat
	private int _modValue;						// the amount added to the base value from the modifiers

	public ModifiedStat()
	{
		_modst = new List<ModifyingAttribute>();
		_modValue = 0;
	}
	public void AddModifier(ModifyingAttribute mod)
	{
		_modst.Add(mod);
	}
	private void CalculateModValue()
	{
		_modValue = 0;

		if (_modst.Count > 0)
		{
			foreach(ModifyingAttribute att in _modst)
				_modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
		}
	}

	public new int AdjustedBaseValue
	{
		get{return BaseValue + BuffValue + _modValue;}

	}
	public void Update()
	{
		CalculateModValue();
	}

}

