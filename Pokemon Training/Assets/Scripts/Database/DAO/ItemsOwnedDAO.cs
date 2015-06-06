using SQLite4Unity3d;
using System.Collections.Generic;
using System.Linq;

public class ItemsOwnedDAO{

	public IEnumerable<ItemsOwned> GetItemsOwned(){
		return DataService.instance._connection.Table<ItemsOwned> ();
	}

	public void CreateItemOwned(string name){
		ItemsOwned itemOwned = new ItemsOwned ();
		itemOwned.Id = GetItemsOwned ().ToList ().Count () + 1;
		itemOwned.NameBasic = name;
		DataService.instance._connection.Insert (itemOwned);
	}

	public void DeleteItemOwned(int id){
		DataService.instance._connection.Execute ("Delete from ItemsOwned where Id = ?", id);
	}

	public void DeleteAllItems(){
		DataService.instance._connection.DeleteAll<ItemsOwned>();
	}
}
