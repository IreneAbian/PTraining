using SQLite4Unity3d;
using UnityEngine;

public class PlayerDAO{

	public void UpdateGold(int newGold){
		   DataService.instance._connection.Execute("Update Player set Gold = ?", newGold);
	}

	public Player GetPlayer(){
		Player player = DataService.instance._connection.Table<Player> ().FirstOrDefault();
		return player;
	}

	public void DeletePlayer(){
		DataService.instance._connection.DeleteAll<Player>();
	}

	public void CrearJugador(string nombre){
		Player player = new Player ();
		player.Name = nombre;
		player.Gold = 0;
		DataService.instance._connection.Insert(player);
	}
}
