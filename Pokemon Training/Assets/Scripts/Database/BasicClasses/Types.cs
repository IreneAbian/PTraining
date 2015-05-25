using SQLite4Unity3d;

public class Types {

	[PrimaryKey]
	public string Type{ get; set; }

	public override string ToString ()
	{
		return string.Format ("[Types: Type={0}]", Type);
	}
	
}
