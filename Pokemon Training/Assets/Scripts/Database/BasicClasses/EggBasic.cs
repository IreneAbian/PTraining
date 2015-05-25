using SQLite4Unity3d;

public class EggBasic {
	[PrimaryKey]
	public string Category{ get; set; }
	public int Price{ get; set; }

	public override string ToString ()
	{
		return string.Format ("[EggBasic: Category={0}, Price={1}]", Category, Price);
	}

}
