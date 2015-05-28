using SQLite4Unity3d;
using System.Collections.Generic;

public class EggBasicDAO{
	
	public IEnumerable<EggBasic> GetEggBasicList(){
        return DataService.instance._connection.Table<EggBasic>();
	}

	public void CreateEggBasic(EggBasic newEggBasic){
		DataService.instance._connection.Insert(newEggBasic);
	}

}