using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

public class DBInterface
{
    private MongoClient client;
    private MongoServer server;
    private MongoDatabase database;
    private MongoCollection<HighScores> highscores;

    public DBInterface()
    {
        client = new MongoClient(new MongoUrl("mongodb://localhost"));
        server = client.GetServer();
        server.Connect();
        database = server.GetDatabase("Roll-A-Zombie");
        highscores = database.GetCollection<HighScores>("Highscores");

        GetTopTen(); 
    }

    public void InsertHighscore(HighScores highscore)
    {
        highscores.Insert(highscore); 
    }

    public List<HighScores> GetTopTen()
    {
        List<HighScores> top10;
        
        MongoCursor<HighScores> result = highscores.FindAll().SetSortOrder("Score").SetLimit(10);

        Debug.Log(result.GetType()); 

        return null; 
    }
}
