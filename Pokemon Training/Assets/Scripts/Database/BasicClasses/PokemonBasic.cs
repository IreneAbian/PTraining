using SQLite4Unity3d;

public class PokemonBasic {
	[PrimaryKey]
	public int Id{ get; set; }
	public string Name{ get; set; }
	public string Description{ get; set; }
	public int BasicHp{ get; set; }
	public int BasicAttack{ get; set; }
	public int BasicDefense{ get; set; }
	public int BasicSpecialAttack{ get; set; }
	public int BasicSpecialDefense{ get; set; }
	public int BasicSpeed{ get; set; }
	public int EvolvesTo{ get; set; }
	public int EvolvesAt{ get; set; }
	public string GrowthRate{ get; set; }
	public int EggCyles{ get; set; }
	public bool IsBasic{ get; set; }
	public string Type{ get; set; }
	public int Happyness{ get; set; }
	public string SpriteImage{ get; set; }


	public override string ToString ()
	{
		return string.Format ("[PokemonBasic: Name={0}, Description={1}, BasicHp={2}, BasicAttack={3}, BasicDefense={4}, BasicSpecialAttack={5}, BasicSpecialDefense={6}, BasicSpeed={7}, EvolvesTo={8}, EvolvesAt={9}, GrowthRate={10}, EggCyles={11}, IsBasic={12}, Type={13}, Happyness={14}]", Name, Description, BasicHp, BasicAttack, BasicDefense, BasicSpecialAttack, BasicSpecialDefense, BasicSpeed, EvolvesTo, EvolvesAt, GrowthRate, EggCyles, IsBasic, Type, Happyness);
	}
	
}
