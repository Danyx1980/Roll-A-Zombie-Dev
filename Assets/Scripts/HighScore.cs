using MongoDB.Bson; 

    public class HighScores
    {
        //Basic Information
        string Username;
        int Score;
        BsonDateTime Date;
        float TimePlayed;

        //Game Information
        int RedZombieDeath;
        int BlueZombieDeath;
        int GreenZombieDeath;
        int YellowZombieDeath;

        int RedZombiePoints;
        int BlueZombiePoints;
        int GreenZombiePoints;
        int YellowZombiePoints;
    }

