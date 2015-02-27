using UnityEngine;
using System.Collections;
using System;//added for enums

public class BaseCharacter : MonoBehaviour {

	private string _name;
	private int _level;
	private uint _freeExp;

	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;


	public void Awake()
	{
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;

		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill= new Skill[Enum.GetValues(typeof(SkillName)).Length];

		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string Name
	{
		get{ return _name;}
		set{ _name = value;}
		
	}
	
	public int Level
	{
		get{ return _level;}
		set{ _level = value;}
		
	}
	
	public uint FreeExp
	{
		get{ return _freeExp;}
		set{ _freeExp = value;}
	}

	public void AddExp(uint exp)
	{
		_freeExp +=  exp;

		CalculateLevel();
	}

	public void CalculateLevel()
	{

	}

	private void SetupPrimaryAttributes()
	{
		for(int cnt = 0; cnt < _primaryAttribute.Length; cnt++)
		{
			_primaryAttribute[cnt] = new Attribute();
		}
	}
	private void SetupVitals()
	{
		for(int cnt = 0; cnt < _vital.Length; cnt++)
		{
			_vital[cnt] = new Vital();
		}
		SetUpVitalModifiers();
		
	}
	private void SetupSkills()
	{
		for(int cnt = 0; cnt < _skill.Length; cnt++)
		{
			_skill[cnt] = new Skill();
		}
		SetUpSkillModifiers();
		
	}

	public Attribute GetPrimaryAttribute(int index)
	{
		return _primaryAttribute[index];
	}

	public Skill GetSkill(int index)
	{
		return _skill[index];
	}

	public Vital GetVital(int index)
	{
	
		return _vital[index];
	}


	private void SetUpVitalModifiers()
	{
		//modifying health through the stam
		ModifyingAttribute healthModifier = new ModifyingAttribute();
		healthModifier.attribute = GetPrimaryAttribute((int)AttributeName.Stamina);
		healthModifier.ratio = 0.5f;
		GetVital((int)VitalName.Health).AddModifier(healthModifier);

		//Modifying Energy through Mastery

		ModifyingAttribute energyModifier  = new ModifyingAttribute();
		energyModifier.attribute = GetPrimaryAttribute((int)AttributeName.Mastery);
		energyModifier.ratio = 0.8f;
		GetVital((int)VitalName.Energy).AddModifier(energyModifier);

		//Modifying Mana through int(intellect)
		ModifyingAttribute manaModifier  = new ModifyingAttribute();
		manaModifier.attribute = GetPrimaryAttribute((int)AttributeName.Intellect);
		manaModifier.ratio = 0.8f;
		GetVital((int)VitalName.Mana).AddModifier(manaModifier );


	}
	private void SetUpSkillModifiers()
	{

		//modifying meleeoff through agility
		ModifyingAttribute meleeOffenceMod1 = new ModifyingAttribute();
		meleeOffenceMod1.attribute = GetPrimaryAttribute((int)AttributeName.Agility);
		meleeOffenceMod1.ratio = 0.33f;
		GetSkill((int)SkillName.Melee_Attack).AddModifier(meleeOffenceMod1);

		//modifying meleeDefence with stamina
		ModifyingAttribute meleeDefenceMod = new ModifyingAttribute();
		meleeDefenceMod.attribute = GetPrimaryAttribute((int)AttributeName.Stamina);
		meleeDefenceMod.ratio = 0.33f;
		GetSkill((int)SkillName.Melee_Defence).AddModifier(meleeDefenceMod);


		//modifying rangeoff through agility
		ModifyingAttribute rangeOffenceMod1 = new ModifyingAttribute();
		rangeOffenceMod1.attribute = GetPrimaryAttribute((int)AttributeName.Haste);
		rangeOffenceMod1.ratio = 0.33f;
		GetSkill((int)SkillName.Ranged_Attack).AddModifier(rangeOffenceMod1);

		//modifying rangeDefence with stamina
		ModifyingAttribute rangeDefenceMod = new ModifyingAttribute();
		rangeDefenceMod.attribute = GetPrimaryAttribute((int)AttributeName.Stamina);
		rangeDefenceMod.ratio = 0.33f;
		GetSkill((int)SkillName.Ranged_Defence).AddModifier(rangeDefenceMod);

		//modifying spelloff through int
		ModifyingAttribute spellOffenceMod1 = new ModifyingAttribute();
		spellOffenceMod1.attribute = GetPrimaryAttribute((int)AttributeName.Intellect);
		spellOffenceMod1.ratio = 0.33f;
		GetSkill((int)SkillName.Magic_Offence).AddModifier(spellOffenceMod1);
		
		//modifying spellDefence with spirit
		ModifyingAttribute spellDefenceMod = new ModifyingAttribute();
		spellDefenceMod.attribute = GetPrimaryAttribute((int)AttributeName.Spirit);
		spellDefenceMod.ratio = 0.33f;
		GetSkill((int)SkillName.Magic_Defence).AddModifier(spellDefenceMod);
		
			
	}

public void StatUpdate()
	{
		for (int cnt = 0; cnt< _vital.Length; cnt++)
		{
			_vital[cnt].Update();
		}
		for (int cnt = 0; cnt< _skill.Length; cnt++)
		{
			_skill[cnt].Update();
		}
	}

}
