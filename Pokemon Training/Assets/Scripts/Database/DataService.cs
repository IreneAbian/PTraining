using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	public SQLiteConnection _connection;
	public static DataService instance = null;

	public DataService(string DatabaseName){
		if (instance == null) {
			instance = this;
		} else {
			instance = this;
		}

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, false);
        Debug.Log("Final PATH: " + dbPath);     

	}

	public void CreateDB(){
	//	_connection.DropTable<EggBasic> ();
	//	_connection.DropTable<EggOwned> ();
	//	_connection.DropTable<GrowthRates> ();
	//	_connection.DropTable<ItemsBasic> ();
	//	_connection.DropTable<ItemsOwned> ();
	//	_connection.DropTable<Player> ();
	//	_connection.DropTable<PokemonBasic> ();
	//	_connection.DropTable<PokemonOwned> ();
	//	_connection.DropTable<Types> ();

	//	_connection.CreateTable<EggBasic> ();
	//	_connection.CreateTable<EggOwned> ();
	//	_connection.CreateTable<GrowthRates> ();
	//	_connection.CreateTable<ItemsBasic> ();
	//	_connection.CreateTable<ItemsOwned> ();
	//	_connection.CreateTable<Player> ();
	//	_connection.CreateTable<PokemonBasic> ();
	//	_connection.CreateTable<PokemonOwned> ();
	//	_connection.CreateTable<Types> ();

	//	_connection.Insert (new GrowthRates{GrowthRate = "Fast"});

	}
}
