public static class GameSettings // Settings >> (Here) >> Game
{
    public const float DefaultMusicVolume = 0.25f;
    public const bool DefaultMusicOn = true;
    public const float DefaultEnemySpeed = 3.5f;

    public static float MusicVolume = DefaultMusicVolume;
    public static bool MusicOn = DefaultMusicOn;
    public static float EnemySpeed = DefaultEnemySpeed;

    public static void ResetToDefaults()
    {
        MusicVolume = DefaultMusicVolume;
        MusicOn = DefaultMusicOn;
        EnemySpeed = DefaultEnemySpeed;
    }
}