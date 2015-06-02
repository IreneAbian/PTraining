using SQLite4Unity3d;

public class PokemonOwned {

	[PrimaryKey]
	public int Id{ get; set; }
	public int IdBasic{ get; set; }
	public int HpTotal{ get; set; }
	public int Hp{ get; set; }
	public int Attack{ get; set; }
	public int Defense{ get; set; }
	public int SpecialAttack{ get; set; }
	public int SpecialDefense{ get; set; }
	public int Speed{ get; set; }
	public int Happyness{ get; set; }
	public int CurrentExperience{ get; set; }
	public int ExperienceNeeded{ get; set; }
	public bool InTeam{ get; set; }
	public int Level{ get; set; }

	public override string ToString ()
	{
		return string.Format ("[PokemonOwned: Id={0}, IdBasic={1}, Hp={2}, Attack={3}, Defense={4}, SpecialAttack={5}, SpecialDefense={6}, Speed={7}, Happyness={8}, CurrentExperience={9}, ExperienceNeeded={10}, InTeam={11}, Level={12}]",
		                      Id, IdBasic, Hp, Attack, Defense, SpecialAttack, SpecialDefense, Speed, Happyness, CurrentExperience, ExperienceNeeded, InTeam, Level);
	}
	
}
