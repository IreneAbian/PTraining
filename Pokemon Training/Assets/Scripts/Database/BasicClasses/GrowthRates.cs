using SQLite4Unity3d;

public class GrowthRates {

	[PrimaryKey]
	public string GrowthRate{ get; set; }

	public override string ToString ()
	{
		return string.Format ("[GrowthRates: GrowthRate={0}]", GrowthRate);
	}
	
}
