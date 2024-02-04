using System.Collections.Frozen;
using System.Net;
using Ouroboros.Utilities;

//[assembly:DisableRuntimeMarshalling]

namespace Ouroboros.Defintions;

public static class CONSTANTS
{
    #region Networking Data
    public static readonly IPAddress DARKAGES_ADDRESS = Dns.GetHostAddresses("da0.kru.com")[0];
    public const ushort DARKAGES_PORT = 2610;
    public static readonly IPEndPoint DARKAGES_ENDPOINT = new(DARKAGES_ADDRESS, DARKAGES_PORT);
    public static readonly IPEndPoint LOOPBACK_LOBBY_ENDPOINT = new(IPAddress.Loopback, LOOPBACK_LOBBY_PORT);
    public const int LOOPBACK_LOBBY_PORT = 42069;
    #endregion
    
    #region Walking Data
    public static readonly Dictionary<string, IdLocation> WALK_LOCATIONS = new(StringComparer.OrdinalIgnoreCase)
    {
        {
            "Blackstar Ent", new IdLocation(3210, 69, 34)
        },
        {
            "Chaos Ent", new IdLocation(3634, 18, 10)
        },
        {
            "SW 22", new IdLocation(559, 43, 26)
        },
        {
            "SW 36", new IdLocation(566, 28, 24)
        },
        {
            "SW 38", new IdLocation(568, 28, 38)
        },
        {
            "SW 43", new IdLocation(573, 22, 26)
        },
        {
            "MTG 10", new IdLocation(2096, 4, 7)
        },
        {
            "MTG 13", new IdLocation(2095, 55, 94)
        },
        {
            "MTG 16", new IdLocation(2092, 79, 6)
        },
        {
            "MTG 25", new IdLocation(2092, 57, 93)
        },
        {
            "CR 31", new IdLocation(5031, 6, 34)
        },
        {
            "Andor Ent", new IdLocation(10101, 15, 10)
        },
        {
            "Andor 80", new IdLocation(10180, 20, 20)
        },
        {
            "Andor 140", new IdLocation(10240, 15, 15)
        },
        {
            "AJ Ent", new IdLocation(8300, 121, 33)
        },
        {
            "AJ Skills", new IdLocation(8295, 12, 7)
        },
        {
            "Crystal Caves", new IdLocation(8314, 9, 95)
        },
        {
            "Yowien Territory", new IdLocation(8318, 50, 93)
        },
        {
            "YT Vines", new IdLocation(8358, 58, 1)
        },
        {
            "YT 24", new IdLocation(8368, 48, 24)
        },
        {
            "Noam", new IdLocation(10055, 0, 0)
        }, //REPLACE THIS POINT
        {
            "Mines", new IdLocation(2901, 15, 15)
        },
        {
            "Lost Ruins", new IdLocation(8995, 41, 36)
        },
        {
            "Plamit Ent", new IdLocation(9378, 40, 20)
        },
        {
            "Plamit Boss", new IdLocation(9376, 42, 47)
        },
        {
            "Chadul Mileth", new IdLocation(8432, 5, 8)
        },
        {
            "Water Dungeon", new IdLocation(6998, 11, 9)
        },
        {
            "Tavaly", new IdLocation(11500, 76, 90)
        },
        {
            "Nobis 2-5", new IdLocation(6534, 1, 36)
        },
        {
            "Nobis 2-11", new IdLocation(6537, 65, 1)
        },
        {
            "Nobis 3-5", new IdLocation(6538, 58, 73)
        },
        {
            "Nobis 3-11", new IdLocation(6541, 73, 4)
        }
    };
    #endregion

    public const int GOLD_CALCULATOR_TOLERANCE = 250000;

    #region Regex Patterns
    public const string WHISPER_PATTERN = @"(\w+)([>""])(.*)";
    public const string CAST_PATTERN = @"You cast (.+)";
    public const string ANOTHER_CURSE_PATTERN = @"Another curse afflicts thee\. \[(.*)\]";
    public const string DURABILITY_PATTERN = @"The durability of ([a-zA-Z 0-9]+) is now (\d+)%";
    public const string LABOR_PATTERN = @"[a-zA-Z]+ works for you for 1 day";
    public const string GROUP_PATTERN = @"[a-zA-Z]+ is [a-z]+ this group\.";
    #endregion

    #region Paths
    public const string DEFAULT_DARKAGES_DIRECTORY = "C:/Program Files (x86)/KRU/Darkages";
    public const string DATA_DIRECTORY = "data";
    #endregion

    #region Memory Locations
    public const long FORCEJUMP_IP_OFFSET = 0x4333A2;
    public const long OVERWRITE_IP_OFFSET = 0x4333C2;
    public const long PORT_OFFSET = 0x4333E4;
    public const long SKIP_INTRO_OFFSET = 0x42E61F;
    public const long FORCEJUMP_INSTANCE_CHECK_OFFSET = 0x57A7D9;
    public const long SKIP_LOAD_WALLS_OFFSET = 0x5FD885;
    public const long AISLING_NAME_OFFSET = 0x73D910;
    #endregion

    #region Bot Data
    public const int BOT_DELAY_MS = 10;
    public const int DEFAULT_CAST_LIMIT = 3;
    public const int DEFAULT_MAX_RANGE = 12;
    public static readonly TimeSpan QUARTER_SECOND = TimeSpan.FromMilliseconds(250);
    public static readonly TimeSpan HALF_SECOND = TimeSpan.FromMilliseconds(500);
    public static readonly TimeSpan ONE_SECOND = TimeSpan.FromSeconds(1);
    public static readonly TimeSpan TWO_SECONDS = TimeSpan.FromSeconds(2);
    public static readonly TimeSpan THREE_SECONDS = TimeSpan.FromSeconds(3);
    public static readonly TimeSpan UNKNOWN_DURATION = TimeSpan.FromSeconds(30);

    public static readonly FrozenSet<string> AO_SITH_MAPS = new[]
    {
        "plamit",
        "sacred forest"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> ANTI_CHEAT_MAP_KEYWORDS = new[]
    {
        "arena",
        "loures battle Ring",
        "coliseum"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> CAST_WHILE_SLEEP_SPELLS = new[]
    {
        "ao suain",
        "leafhopper chirp"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> BOW_SPELLS = new[]
    {
        "star arrow",
        "frost arrow",
        "shock arrow",
        "volley",
        "barrage"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> BOW_SKILLS = new[]
    {
        "arrow shot",
        "special arrow attack"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> BAREHAND_SKILLS = new[]
    {
        "mass strike",
        "double rake",
        "tail sweep",
        "mantis kick",
        "high kick",
        "kick"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> DAGGER_SKILLS = new[]
    {
        "stab twice",
        "stab and twist",
        "kidney shot"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> CLAW_SKILLS = new[]
    {
        "claw slash"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);
    #endregion

    #region Trash
    public static readonly FrozenSet<string> KNOWN_RANGERS = new[]
    {
        "justyce",
        "justice",
        "gargoyle",
        "justify",
        "herb",
        "hulk",
        "tormund",
        "evanora",
        "reyakeely",
        "ishikawa",
        "listen",
        "error",
        "firewind",
        "xerge",
        "duenanknute",
        "joeker",
        "trial",
        "angelique",
        "evokation",
        "malache",
        "martrim",
        "ukkyo",
        "etienne",
        "algiza",
        "topic",
        "kremline",
        "venezia",
        "dionia",
        "etna",
        "viveena",
        "ladieerror",
        "errorjr"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> DEFAULT_TRASH = new[]
    {
        "amber necklace",
        "bone necklace",
        "gold jade necklace",
        "fior athar",
        "fior creag",
        "fior sal",
        "fior srad",
        "cordovan boots",
        "magma boots",
        "shagreen boots",
        "magus apollo",
        "magus diana",
        "magus gaea",
        "magus krono",
        "holy apollo",
        "holy gaea",
        "holy krono",
        "holy diana",
        "goblin helmet",
        "half talisman",
        "hy-brasyl belt",
        "hy-brasyl bracer",
        "hy-brasyl gauntlet",
        "iron greaves",
        "mythril greaves",
        "light belt",
        "blue potion",
        "purple potion",
        "passion flower"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);
    #endregion

    #region Ability Data
    public static readonly FrozenSet<string> KNOWN_DIONS = new[]
    {
        "mor dion",
        "iron skin",
        "wings of protection",
        "dion",
        "stone skin",
        "glowing stone",
        "draco stance"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> KNOWN_HEALS = new[]
    {
        "nuadhaich",
        "ard ioc",
        "mor ioc",
        "ioc",
        "beag ioc",
        "Cold Blood",
        "Spirit Essence"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> KNOWN_AITES = new[]
    {
        "ard naomh aite",
        "mor naomh aite",
        "naomh aite",
        "beag naomh aite"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> KNOWN_FASNADURS = new[]
    {
        "ard fas nadur",
        "mor fas nadur",
        "fas nadur",
        "beag fas nadur"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> KNOWN_CURSES = new[]
    {
        "beag cradh",
        "cradh",
        "mor cradh",
        "ard cradh",
        "dark seal",
        "darker seal",
        "demise"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> KNOWN_CONTROLS = new[]
    {
        "beag pramh",
        "pramh",
        "mesmerize",
        "suain"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> KNOWN_ATTACKS1 = new[]
    {
        "hail of feathers",
        "keeter",
        "groo",
        "torch",
        "mermaid",
        "star arrow",
        "barrage",
        "ard pian na dion",
        "mor pian na dion",
        "pian na dion",
        "ard deo searg",
        "deo searg",
        "deception of life",
        "dragon blast",
        "frost arrow",
        "beag athar lamh",
        "beag srad lamh",
        "athar lamh",
        "srad lamh",
        "howl"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenSet<string> KNOWN_ATTACKS2 = new[]
    {
        "mor strioch pian gar",
        "cursed tune",
        "supernova shot",
        "volley",
        "unholy explosion",
        "mor deo searg gar",
        "deo searg gar",
        "shock arrow"
    }.ToFrozenSet(StringComparer.OrdinalIgnoreCase);
    #endregion

    #region Casting Safety
    public static readonly FrozenSet<ushort> INVISIBLE_SPRITES = new ushort[]
    {
        676,
        690,
        691,
        699,
        700,
        701,
        532,
        530,
        528,
        526,
        492,
        387,
        289,
        290,
        292,
        293,
        294,
        295,
        296,
        297,
        298,
        299,
        253,
        252,
        195
    }.ToFrozenSet();

    public static readonly FrozenSet<ushort> GREEN_BOROS = new ushort[]
    {
        553,
        561,
        62
    }.ToFrozenSet();

    public static readonly FrozenSet<ushort> RED_BOROS = new ushort[]
    {
        552,
        561,
        62
    }.ToFrozenSet();

    public static readonly FrozenSet<ushort> UNDESIRABLE_SPRITES = new ushort[]
    {
        563,
        564,
        565,
        566,
        439,
        456,
        53
    }.ToFrozenSet();

    public static readonly FrozenDictionary<ushort, FrozenSet<ushort>> WHITE_LIST_BY_MAP_ID = new Dictionary<ushort, FrozenSet<ushort>>
    {
        {
            7071, new ushort[]
            {
                559,
                246,
                250,
                929
            }.ToFrozenSet() //battle of mount merry
        },
        {
            10240, new ushort[]
            {
                542,
                544
            }.ToFrozenSet() //andor bosses
        },
        {
            2120, new ushort[]
            {
                876,
                878
            }.ToFrozenSet() //mtg1 yule log bash
        },
        {
            2088, new ushort[]
            {
                876,
                878
            }.ToFrozenSet() //mtg2 yule log back
        },
        {
            8111, new ushort[]
            {
                205
            }.ToFrozenSet() //blackstar boss on map 8111
        },
        {
            8496, new ushort[]
            {
                164,
                165,
                166,
                167
            }.ToFrozenSet() //zombie survival 1
        },
        {
            8497, new ushort[]
            {
                164,
                165,
                166,
                167
            }.ToFrozenSet()
        },
        {
            8498, new ushort[]
            {
                164,
                165,
                166,
                167
            }.ToFrozenSet()
        },
        {
            8499, new ushort[]
            {
                164,
                165,
                166,
                167
            }.ToFrozenSet() //zombie survival 4
        },
        {
            8500, new ushort[]
            {
                46,
                62,
                814,
                815
            }.ToFrozenSet() //macabre event
        },
        {
            6999, new ushort[]
            {
                492
            }.ToFrozenSet() //energy sphere(boss) for water dungeon
        },
        {
            509, new ushort[]
            {
                912,
                69,
                321,
                363,
                365,
                366,
                367
            }.ToFrozenSet() //arena event
        },
        {
            8400, new ushort[]
            {
                262,
                394
            }.ToFrozenSet() //giant floppy
        },
        {
            10263, new ushort[]
            {
                454
            }.ToFrozenSet() //molten cube fire canyon
        },
        {
            8994, new ushort[]
            {
                422
            }.ToFrozenSet() //lost ruins 2 grimes
        },
        {
            8983, new ushort[]
            {
                404
            }.ToFrozenSet() //law shortcut
        },
        {
            8980, new ushort[]
            {
                404
            }.ToFrozenSet() //lr7 law
        },
        {
            10000, new ushort[]
            {
                422
            }.ToFrozenSet() //asilon town grimes
        },
        {
            8989, new ushort[]
            {
                779,
                782,
                788
            }.ToFrozenSet() //lr4
        },
        {
            8984, new ushort[]
            {
                784,
                785
            }.ToFrozenSet() //lr6
        },
        {
            9377, new ushort[]
            {
                692,
                695
            }.ToFrozenSet() //plamit boss 1
        },
        {
            9378, new ushort[]
            {
                692,
                695
            }.ToFrozenSet()
        },
        {
            9379, new ushort[]
            {
                692,
                695
            }.ToFrozenSet()
        },
        {
            9380, new ushort[]
            {
                692,
                695
            }.ToFrozenSet()
        },
        {
            9381, new ushort[]
            {
                692,
                695
            }.ToFrozenSet()
        },
        {
            9382, new ushort[]
            {
                692,
                695
            }.ToFrozenSet()
        },
        {
            9383, new ushort[]
            {
                692,
                695
            }.ToFrozenSet()
        },
        {
            9384, new ushort[]
            {
                692,
                695
            }.ToFrozenSet() //plamit boss 8
        },
        {
            6646, new ushort[]
            {
                318
            }.ToFrozenSet() //snek bosses
        },
        {
            6647, new ushort[]
            {
                318
            }.ToFrozenSet()
        },
        {
            6648, new ushort[]
            {
                318
            }.ToFrozenSet()
        },
        {
            6649, new ushort[]
            {
                318
            }.ToFrozenSet()
        },
        {
            6651, new ushort[]
            {
                316
            }.ToFrozenSet()
        },
        {
            6652, new ushort[]
            {
                316
            }.ToFrozenSet()
        },
        {
            6653, new ushort[]
            {
                316
            }.ToFrozenSet()
        },
        {
            6654, new ushort[]
            {
                316
            }.ToFrozenSet()
        },
        {
            6656, new ushort[]
            {
                207
            }.ToFrozenSet()
        },
        {
            6657, new ushort[]
            {
                207
            }.ToFrozenSet()
        },
        {
            6658, new ushort[]
            {
                207
            }.ToFrozenSet()
        },
        {
            6659, new ushort[]
            {
                207
            }.ToFrozenSet() //snek bosses
        }
    }.ToFrozenDictionary();

    public static readonly FrozenDictionary<string, FrozenSet<ushort>> WHITE_LIST_BY_MAP_NAME
        = new Dictionary<string, FrozenSet<ushort>>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "Crypt", new ushort[]
                {
                    53
                }.ToFrozenSet()
            }, //allow spider only in crypt maps cuz spider spawn spell),
            {
                "Shinewood Forest 3", new ushort[]
                {
                    263,
                    266
                }.ToFrozenSet()
            }, //allow beetle/mantis in sw2 30+),
            {
                "Shinewood Forest 4", new ushort[]
                {
                    263,
                    266
                }.ToFrozenSet()
            }, //allow beetle/mantis in sw2 40+),
            {
                "Aman Jungle", new ushort[]
                {
                    856,
                    873,
                    874,
                    875
                }.ToFrozenSet()
            }, //allow frogs in aman jungle),
            {
                "Yowien Territory", new ushort[]
                {
                    634,
                    664
                }.ToFrozenSet()
            }, //allow specific yt mobs),
            {
                "Beal na Carraige", new ushort[]
                {
                    707,
                    780,
                    781
                }.ToFrozenSet()
            }, //allow giant things in bnc),
            {
                "Cthonic Remains 4", new ushort[]
                {
                    190,
                    210
                }.ToFrozenSet()
            }, //allow skele draco in cr40+),
            {
                "Cthonic Remains 5", new ushort[]
                {
                    190,
                    210
                }.ToFrozenSet()
            }, //allow skele draco in cr50+),
            {
                "Cursed Home", new ushort[]
                {
                    609,
                    610,
                    611,
                    612
                }.ToFrozenSet()
            }, //allow casting on cursed home mobs),
            {
                "Muisir", new ushort[]
                {
                    926,
                    933,
                    940,
                    953,
                    954,
                    955,
                    960
                }.ToFrozenSet()
            }, //allow casting on muisir mobs),
            {
                "Chadul's Mileth", new ushort[]
                {
                    401
                }.ToFrozenSet()
            }, //boss of all instances of chadul mileth),
            {
                "Chadul's Abel", new ushort[]
                {
                    400
                }.ToFrozenSet()
            }, //boss of all instances of chadul abel),
            {
                "Chadul's Loures", new ushort[]
                {
                    650
                }.ToFrozenSet()
            }, //boss of all instances of chadul loures),
            {
                "Chadul's Piet", new ushort[]
                {
                    397
                }.ToFrozenSet()
            }, //boss of all instances of chadul piet),
            {
                "Blackstar Crypt 5", new ushort[]
                {
                    401
                }.ToFrozenSet()
            }, //first boss of blackstar crypt),
            {
                "Blackstar Crypt 11", new ushort[]
                {
                    205
                }.ToFrozenSet()
            }, //second boss of blackstar crypt),
            {
                "Blackstar Crypt Boss", new ushort[]
                {
                    397
                }.ToFrozenSet()
            } //last boss of blackstar crypt),
        }.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);

    public static readonly FrozenDictionary<string, FrozenSet<ushort>> BLACK_LIST_BY_MAP_NAME
        = new Dictionary<string, FrozenSet<ushort>>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "Blackstar", new ushort[]
                {
                    529
                }.ToFrozenSet() //dont allow casting on chickens in blackstar
            }
        }.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    #endregion
}