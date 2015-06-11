using SQLite4Unity3d;
using System.Collections.Generic;

public class ItemsBasicDAO{
	
	public IEnumerable<ItemsBasic> GetItemsBasic(){
		return DataService.instance._connection.Table<ItemsBasic>();
	}

	public ItemsBasic GetItemBasic(string name){
		return DataService.instance._connection.Table<ItemsBasic> ().Where (x => x.Name == name).FirstOrDefault();
	}

}