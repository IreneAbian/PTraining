using SQLite4Unity3d;

public class ItemsOwned {

	[PrimaryKey]
	public int Id{ get; set; }
	public string NameBasic{ get; set; }

	public override string ToString ()
	{
		return string.Format ("[ItemsOwned: Id={0}, NameBasic={1}]", Id, NameBasic);
	}

}