using System.Collections.ObjectModel;
using System.Net;
using System.Runtime.CompilerServices;
using Ouroboros.Utilities;

//[assembly:DisableRuntimeMarshalling]

namespace Ouroboros.Defintions;

public static class CONSTANTS
{
    public static readonly IPAddress DARKAGES_ADDRESS = Dns.GetHostAddresses("da0.kru.com")[0];
    public const ushort DARKAGES_PORT = 2610;
    public static readonly IPEndPoint DARKAGES_ENDPOINT = new(DARKAGES_ADDRESS, DARKAGES_PORT);
    public static readonly IPEndPoint LOOPBACK_LOBBY_ENDPOINT = new(IPAddress.Loopback, LOOPBACK_LOBBY_PORT);
    public const int LOOPBACK_LOBBY_PORT = 42069;
    public const string DEFAULT_DARKAGES_DIRECTORY = "C:/Program Files (x86)/KRU/Darkages";
    public const string DATA_DIRECTORY = "data";
    
    #region Walking Data
        internal static readonly Dictionary<string, IdLocation> WALK_LOCATIONS = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Blackstar Ent", new IdLocation(3210, 69, 34) },
            { "Chaos Ent", new IdLocation(3634, 18, 10) },
            { "SW 22", new IdLocation(559, 43, 26) },
            { "SW 36", new IdLocation(566, 28, 24) },
            { "SW 38", new IdLocation(568, 28, 38) },
            { "SW 43", new IdLocation(573, 22, 26) },
            { "MTG 10", new IdLocation(2096, 4, 7) },
            { "MTG 13", new IdLocation(2095, 55, 94) },
            { "MTG 16", new IdLocation(2092, 79, 6) },
            { "MTG 25", new IdLocation(2092, 57, 93) },
            { "CR 31", new IdLocation(5031, 6, 34) },
            { "Andor Ent", new IdLocation(10101, 15, 10) },
            { "Andor 80", new IdLocation(10180, 20, 20) },
            { "Andor 140", new IdLocation(10240, 15, 15) },
            { "AJ Ent", new IdLocation(8300, 121, 33) },
            { "AJ Skills", new IdLocation(8295, 12, 7) },
            { "Crystal Caves", new IdLocation(8314, 9, 95) },
            { "Yowien Territory", new IdLocation(8318, 50, 93) },
            { "YT Vines", new IdLocation(8358, 58, 1) },
            { "YT 24", new IdLocation(8368, 48, 24) },
            { "Noam", new IdLocation(10055, 0, 0) }, //REPLACE THIS POINT
            { "Mines", new IdLocation(2901, 15, 15) },
            { "Lost Ruins", new IdLocation(8995, 41, 36) },
            { "Plamit Ent", new IdLocation(9378, 40, 20) },
            { "Plamit Boss", new IdLocation(9376, 42, 47) },
            { "Chadul Mileth", new IdLocation(8432, 5, 8) },
            { "Water Dungeon", new IdLocation(6998, 11, 9) },
            { "Tavaly", new IdLocation(11500, 76, 90) },
            { "Nobis 2-5", new IdLocation(6534, 1, 36) },
            { "Nobis 2-11", new IdLocation(6537, 65, 1) },
            { "Nobis 3-5", new IdLocation(6538, 58, 73) },
            { "Nobis 3-11", new IdLocation(6541, 73, 4) }
        };
        #endregion

        #region Regex Patterns
        internal const string WHISPER_PATTERN = @"(\w+)([>""])(.*)";
        internal const string CAST_PATTERN = @"You cast (.+)";
        internal const string ANOTHER_CURSE_PATTERN = @"Another curse afflicts thee\. \[(.*)\]";
        internal const string DURABILITY_PATTERN = @"The durability of ([a-zA-Z 0-9]+) is now (\d+)%";
        internal const string LABOR_PATTERN = @"[a-zA-Z]+ works for you for 1 day";
        internal const string GROUP_PATTERN = @"[a-zA-Z]+ is [a-z]+ this group\.";
        #endregion

        #region Paths
        internal const string FRIENDS_PATH = @"data\friends.json";
        internal const string OPTIONS_PATH = @"data\options.json";
        internal const string MAP_CACHE_PATH = @"data\maps.dat";
        internal const string STAFF_META_PATH = @"data\staffMeta.json";
        #endregion

        #region Memory Locations
        internal const long FORCEJUMP_IP_OFFSET = 0x4333A2;
        internal const long OVERWRITE_IP_OFFSET = 0x4333C2;
        internal const long PORT_OFFSET = 0x4333E4;
        internal const long SKIP_INTRO_OFFSET = 0x42E61F;
        internal const long FORCEJUMP_INSTANCE_CHECK_OFFSET = 0x57A7D9;
        internal const long SKIP_LOAD_WALLS_OFFSET = 0x5FD885;
        internal const long AISLING_NAME_OFFSET = 0x73D910;
        #endregion

        #region Bot Data
        internal const int BOT_DELAY_MS = 10;
        internal const int DEFAULT_CAST_LIMIT = 3;
        internal static readonly TimeSpan QUARTER_SECOND = TimeSpan.FromMilliseconds(250);
        internal static readonly TimeSpan HALF_SECOND = TimeSpan.FromMilliseconds(500);
        internal static readonly TimeSpan ONE_SECOND = TimeSpan.FromSeconds(1);
        internal static readonly TimeSpan TWO_SECONDS = TimeSpan.FromSeconds(2);
        internal static readonly TimeSpan THREE_SECONDS = TimeSpan.FromSeconds(3);
        internal static readonly TimeSpan UNKNOWN_DURATION = TimeSpan.FromSeconds(30);

        internal static readonly IReadOnlyList<string> ANTI_CHEAT_MAP_KEYWORDS =
            new ReadOnlyCollection<string>(new[] { "arena", "loures battle Ring", "coliseum" });

        internal static readonly IReadOnlyList<string> CAST_WHILE_SLEEP_SPELLS =
            new ReadOnlyCollection<string>(new[] { "ao suain", "leafhopper chirp" });

        internal static readonly IReadOnlyList<string> BOW_SPELLS =
            new ReadOnlyCollection<string>(new[] { "star arrow", "frost arrow", "shock arrow", "volley", "barrage" });

        internal static readonly IReadOnlyList<string> BOW_SKILLS =
            new ReadOnlyCollection<string>(new[] { "arrow shot", "special arrow attack" });

        internal static readonly IReadOnlyList<string> BAREHAND_SKILLS =
            new ReadOnlyCollection<string>(new[] { "mass strike", "double rake", "tail sweep", "mantis kick", "high kick", "kick" });

        internal static readonly IReadOnlyList<string> DAGGER_SKILLS =
            new ReadOnlyCollection<string>(new[] { "stab twice", "stab and twist", "kidney shot" });

        internal static readonly IReadOnlyList<string> CLAW_SKILLS = new ReadOnlyCollection<string>(new[] { "claw slash" });
        #endregion

        #region Trash
        internal static readonly IReadOnlyList<string> KNOWN_RANGERS = new ReadOnlyCollection<string>(new[]
        {
            "justyce", "justice", "gargoyle", "justify", "herb", "hulk", "tormund", "evanora", "reyakeely", "ishikawa", "listen",
            "error", "firewind", "xerge", "duenanknute", "joeker", "trial", "angelique", "evokation", "malache", "martrim", "ukkyo",
            "etienne", "algiza", "topic", "kremline", "venezia", "dionia", "etna", "viveena", "ladieerror", "errorjr"
        });

        internal static readonly IReadOnlyList<string> DEFAULT_TRASH = new ReadOnlyCollection<string>(new[]
        {
            "amber necklace", "bone necklace", "gold jade necklace", "fior athar", "fior creag", "fior sal", "fior srad",
            "cordovan boots", "magma boots", "shagreen boots", "magus apollo", "magus diana", "magus gaea", "magus krono",
            "holy apollo", "holy gaea", "holy krono", "holy diana", "goblin helmet", "half talisman", "hy-brasyl belt",
            "hy-brasyl bracer", "hy-brasyl gauntlet", "iron greaves", "mythril greaves", "light belt", "blue potion", "purple potion",
            "passion flower"
        });
        #endregion

        #region Ability Data
        internal static readonly IReadOnlyList<string> KNOWN_DIONS = new ReadOnlyCollection<string>(new[]
        {
            "mor dion", "iron skin", "wings of protection", "dion", "stone skin", "glowing stone", "draco stance"
        });

        internal static readonly IReadOnlyList<string> KNOWN_HEALS = new ReadOnlyCollection<string>(new[]
        {
            "nuadhaich", "ard ioc", "mor ioc", "ioc", "beag ioc", "Cold Blood", "Spirit Essence"
        });

        internal static readonly IReadOnlyList<string> KNOWN_AITES =
            new ReadOnlyCollection<string>(new[] { "ard naomh aite", "mor naomh aite", "naomh aite", "beag naomh aite" });

        internal static readonly IReadOnlyList<string> KNOWN_FASNADURS =
            new ReadOnlyCollection<string>(new[] { "ard fas nadur", "mor fas nadur", "fas nadur", "beag fas nadur" });

        internal static readonly IReadOnlyList<string> KNOWN_CURSES = new ReadOnlyCollection<string>(new[]
        {
            "beag cradh", "cradh", "mor cradh", "ard cradh", "dark seal", "darker seal", "demise"
        });

        internal static readonly IReadOnlyList<string> KNOWN_CONTROLS =
            new ReadOnlyCollection<string>(new[] { "beag pramh", "pramh", "mesmerize", "suain" });

        public static readonly IReadOnlyList<string> KNOWN_ATTACKS1 = new ReadOnlyCollection<string>(new[]
        {
            "hail of feathers", "keeter", "groo", "torch", "mermaid", "star arrow", "barrage", "ard pian na dion", "mor pian na dion",
            "pian na dion", "ard deo searg", "deo searg", "deception of life", "dragon blast", "frost arrow", "beag athar lamh",
            "beag srad lamh", "athar lamh", "srad lamh", "howl"
        });

        public static readonly IReadOnlyList<string> KNOWN_ATTACKS2 = new ReadOnlyCollection<string>(new[]
        {
            "mor strioch pian gar", "cursed tune", "supernova shot", "volley", "unholy explosion", "mor deo searg gar", "deo searg gar",
            "shock arrow"
        });
        #endregion

        #region Casting Safety
        internal static readonly IReadOnlyList<ushort> INVISIBLE_SPRITES = new ReadOnlyCollection<ushort>(new ushort[]
        {
            676, 690, 691, 699, 700, 701, 532, 530, 528, 526, 492, 387, 289, 290, 292, 293, 294, 295, 296, 297, 298, 299, 253, 252, 195
        });

        internal static readonly IReadOnlyList<ushort> GREEN_BOROS = new ReadOnlyCollection<ushort>(new ushort[] { 553, 561, 62 });

        internal static readonly IReadOnlyList<ushort> RED_BOROS = new ReadOnlyCollection<ushort>(new ushort[] { 552, 561, 62 });

        internal static readonly IReadOnlyList<ushort> UNDESIRABLE_SPRITES =
            new ReadOnlyCollection<ushort>(new ushort[] { 563, 564, 565, 566, 439, 456, 53 });

        internal static readonly IReadOnlyDictionary<ushort, IReadOnlyList<ushort>> WHITE_LIST_BY_MAP_ID =
            new ReadOnlyDictionary<ushort, IReadOnlyList<ushort>>(new Dictionary<ushort, IReadOnlyList<ushort>>
            {
                {
                    7071, new ReadOnlyCollection<ushort>(new ushort[] { 559, 246, 250, 929 }) //battle of mount merry
                },
                {
                    10240, new ReadOnlyCollection<ushort>(new ushort[] { 542, 544 }) //andor bosses
                },
                {
                    2120, new ReadOnlyCollection<ushort>(new ushort[] { 876, 878 }) //mtg1 yule log bash
                },
                {
                    2088, new ReadOnlyCollection<ushort>(new ushort[] { 876, 878 }) //mtg2 yule log back
                },
                {
                    8111, new ReadOnlyCollection<ushort>(new ushort[] { 205 }) //blackstar boss on map 8111
                },
                {
                    8496, new ReadOnlyCollection<ushort>(new ushort[] { 164, 165, 166, 167 }) //zombie survival 1
                },
                { 8497, new ReadOnlyCollection<ushort>(new ushort[] { 164, 165, 166, 167 }) },
                { 8498, new ReadOnlyCollection<ushort>(new ushort[] { 164, 165, 166, 167 }) },
                {
                    8499, new ReadOnlyCollection<ushort>(new ushort[] { 164, 165, 166, 167 }) //zombie survival 4
                },
                {
                    8500, new ReadOnlyCollection<ushort>(new ushort[] { 46, 62, 814, 815 }) //macabre event
                },
                {
                    6999, new ReadOnlyCollection<ushort>(new ushort[] { 492 }) //energy sphere(boss) for water dungeon
                },
                {
                    509, new ReadOnlyCollection<ushort>(new ushort[] { 912, 69, 321, 363, 365, 366, 367 }) //arena event
                },
                {
                    8400, new ReadOnlyCollection<ushort>(new ushort[] { 262, 394 }) //giant floppy
                },
                {
                    10263, new ReadOnlyCollection<ushort>(new ushort[] { 454 }) //molten cube fire canyon
                },
                {
                    8994, new ReadOnlyCollection<ushort>(new ushort[] { 422 }) //lost ruins 2 grimes
                },
                {
                    8983, new ReadOnlyCollection<ushort>(new ushort[] { 404 }) //law shortcut
                },
                {
                    8980, new ReadOnlyCollection<ushort>(new ushort[] { 404 }) //lr7 law
                },
                {
                    10000, new ReadOnlyCollection<ushort>(new ushort[] { 422 }) //asilon town grimes
                },
                {
                    8989, new ReadOnlyCollection<ushort>(new ushort[] { 779, 782, 788 }) //lr4
                },
                {
                    8984, new ReadOnlyCollection<ushort>(new ushort[] { 784, 785 }) //lr6
                },
                {
                    9377, new ReadOnlyCollection<ushort>(new ushort[] { 692, 695 }) //plamit boss 1
                },
                { 9378, new ReadOnlyCollection<ushort>(new ushort[] { 692, 695 }) },
                { 9379, new ReadOnlyCollection<ushort>(new ushort[] { 692, 695 }) },
                { 9380, new ReadOnlyCollection<ushort>(new ushort[] { 692, 695 }) },
                { 9381, new ReadOnlyCollection<ushort>(new ushort[] { 692, 695 }) },
                { 9382, new ReadOnlyCollection<ushort>(new ushort[] { 692, 695 }) },
                { 9383, new ReadOnlyCollection<ushort>(new ushort[] { 692, 695 }) },
                {
                    9384, new ReadOnlyCollection<ushort>(new ushort[] { 692, 695 }) //plamit boss 8
                },
                {
                    6646, new ReadOnlyCollection<ushort>(new ushort[] { 318 }) //snek bosses
                },
                { 6647, new ReadOnlyCollection<ushort>(new ushort[] { 318 }) },
                { 6648, new ReadOnlyCollection<ushort>(new ushort[] { 318 }) },
                { 6649, new ReadOnlyCollection<ushort>(new ushort[] { 318 }) },
                { 6651, new ReadOnlyCollection<ushort>(new ushort[] { 316 }) },
                { 6652, new ReadOnlyCollection<ushort>(new ushort[] { 316 }) },
                { 6653, new ReadOnlyCollection<ushort>(new ushort[] { 316 }) },
                { 6654, new ReadOnlyCollection<ushort>(new ushort[] { 316 }) },
                { 6656, new ReadOnlyCollection<ushort>(new ushort[] { 207 }) },
                { 6657, new ReadOnlyCollection<ushort>(new ushort[] { 207 }) },
                { 6658, new ReadOnlyCollection<ushort>(new ushort[] { 207 }) },
                {
                    6659, new ReadOnlyCollection<ushort>(new ushort[] { 207 }) //snek bosses
                }
            });

        internal static readonly IReadOnlyDictionary<string, IReadOnlyList<ushort>> WHITE_LIST_BY_MAP_NAME =
            new ReadOnlyDictionary<string, IReadOnlyList<ushort>>(
                new Dictionary<string, IReadOnlyList<ushort>>(StringComparer.OrdinalIgnoreCase)
                {
                    {
                        "Crypt", new ReadOnlyCollection<ushort>(new ushort[] { 53 })
                    }, //allow spider only in crypt maps cuz spider spawn spell),
                    { "Shinewood Forest 3", new ReadOnlyCollection<ushort>(new ushort[] { 263, 266 }) }, //allow beetle/mantis in sw2 30+),
                    { "Shinewood Forest 4", new ReadOnlyCollection<ushort>(new ushort[] { 263, 266 }) }, //allow beetle/mantis in sw2 40+),
                    { "Aman Jungle", new ReadOnlyCollection<ushort>(new ushort[] { 856, 873, 874, 875 }) }, //allow frogs in aman jungle),
                    { "Yowien Territory", new ReadOnlyCollection<ushort>(new ushort[] { 634, 664 }) }, //allow specific yt mobs),
                    { "Beal na Carraige", new ReadOnlyCollection<ushort>(new ushort[] { 707, 780, 781 }) }, //allow giant things in bnc),
                    { "Cthonic Remains 4", new ReadOnlyCollection<ushort>(new ushort[] { 190, 210 }) }, //allow skele draco in cr40+),
                    { "Cthonic Remains 5", new ReadOnlyCollection<ushort>(new ushort[] { 190, 210 }) }, //allow skele draco in cr50+),
                    {
                        "Cursed Home", new ReadOnlyCollection<ushort>(new ushort[] { 609, 610, 611, 612 })
                    }, //allow casting on cursed home mobs),
                    {
                        "Muisir", new ReadOnlyCollection<ushort>(new ushort[] { 926, 933, 940, 953, 954, 955, 960 })
                    }, //allow casting on muisir mobs),
                    { "Chadul's Mileth", new ReadOnlyCollection<ushort>(new ushort[] { 401 }) }, //boss of all instances of chadul mileth),
                    { "Chadul's Abel", new ReadOnlyCollection<ushort>(new ushort[] { 400 }) }, //boss of all instances of chadul abel),
                    { "Chadul's Loures", new ReadOnlyCollection<ushort>(new ushort[] { 650 }) }, //boss of all instances of chadul loures),
                    { "Chadul's Piet", new ReadOnlyCollection<ushort>(new ushort[] { 397 }) }, //boss of all instances of chadul piet),
                    { "Blackstar Crypt 5", new ReadOnlyCollection<ushort>(new ushort[] { 401 }) }, //first boss of blackstar crypt),
                    { "Blackstar Crypt 11", new ReadOnlyCollection<ushort>(new ushort[] { 205 }) }, //second boss of blackstar crypt),
                    { "Blackstar Crypt Boss", new ReadOnlyCollection<ushort>(new ushort[] { 397 }) } //last boss of blackstar crypt),
                });

        internal static readonly IReadOnlyDictionary<string, IReadOnlyList<ushort>> BLACK_LIST_BY_MAP_NAME =
            new ReadOnlyDictionary<string, IReadOnlyList<ushort>>(
                new Dictionary<string, IReadOnlyList<ushort>>(StringComparer.OrdinalIgnoreCase)
                {
                    {
                        "Blackstar", new ReadOnlyCollection<ushort>(new ushort[] { 529 }) //dont allow casting on chickens in blackstar
                    }
                });
        #endregion
    
        internal const int GOLD_CALCULATOR_TOLERANCE = 250000;
}