using SQLite4Unity3d;

public class ItemsBasic {

	[PrimaryKey]
	public string Name{ get; set; }
	public string Description{ get; set; }
	public string Price{ get; set; }

	public override string ToString ()
	{
		return string.Format ("[Items: Name={0}, Description={1}, Price={2}]", Name, Description, Price);
	}
	
}