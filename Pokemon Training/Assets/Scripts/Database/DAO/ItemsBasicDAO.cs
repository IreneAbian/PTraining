using SQLite4Unity3d;
using System.Collections.Generic;

public class ItemsBasicDAO{

	private SQLiteConnection _connection;

	public ItemsBasicDAO(SQLiteConnection _connection){
		this._connection = _connection;
	}

	public IEnumerable<ItemsBasic> GetItemsBasic(){
		return _connection.Table<ItemsBasic>();
	}

	public ItemsBasic GetItemBasic(string name){
		return _connection.Table<ItemsBasic> ().Where (x => x.Name == name);
	}

}