public class PlayerData
{
    // Identity
    public int id;
    public string name = "not set";

    // Transform
    public float x = 0.0f;
    public float y = 0.0f;
    public float z = 0.0f;

    public float xr = 0.0f;
    public float yr = 0.0f;
    public float zr = 0.0f;

    public float xc = 0.0f;
    public float yc = 0.0f;
    public float zc = 0.0f;

    //crouch
    public bool crouch = false;
    
    // Movement and visibility
    public bool isMoving = false;
    public bool isVisible = true;
    public long lastPositionUpdate = 0;

    public bool destroy = false;
    public bool die = false;
    public bool isAlive = false;

    // stats
    public float kills = 0;
    public float deaths = 0;
    public float health = 100.0f; // Player health (100 = full health)
    public float maxHealth = 100.0f; // Maximum health

    // Current weapon ID
    public bool weaponChanged = false;
    public int weapon = 1;

    // appereances
    public bool appereancesChanged = false;
    public int holo = -1;
    public int head = -1;
    public int face = -1;
    public int gloves = -1;
    public int upperbody = -1;
    public int lowerbody = -1;
    public int boots = -1;

    public int lastKiller = 0;

    // Weapon shoot
    public bool pendingPrimaryFire = false;

    public bool pendingFinalWord = false;

    public PlayerData(string name)
    {
        this.name = name;
    }
}
