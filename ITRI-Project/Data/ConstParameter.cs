namespace ITRI_Project.Data
{
    public class GenerateUnit
    {
        public string key { get; set; }
        public string format { get; set; }
        public string voiceType { get; set; }

        public GenerateUnit(string _key, string _format, string _voiceType)
        {
            key = _key;
            format = _format;
            voiceType = _voiceType;
        }
    }

    public class ConstParameter
    {
        public enum ScriptType : int
        {
            eDisplay = 1,
            eOption,
            eText,
            eMultiText,
            eRecode,
            eRating,
            eInfo,
            eLongVideo,
            eAudioPlay,
            eUnknow = 999
        }

        public const int TOTAL_NODE_NUM = 7;
        public const int ECHELON_NUM = 14;
        public const int ECHELON_TIME = 40;

        public const string AZURE_KEY = "0ac0dc14ec9a43228af7e26666f26a9c";
        public const string AZURE_AREA = "southeastasia";

        public static readonly Dictionary<String, GenerateUnit> GENERATE_NAME_QUESTION =
        new Dictionary<string, GenerateUnit>()
        {
            {"n1-1", new GenerateUnit("n1-1", "我是E，你是{0}吧？", "n1")},
            {"n2-1", new GenerateUnit("n2-1", "我是E，你是{0}吧？", "n2")},
            {"n3-1", new GenerateUnit("n3-1", "嗨{0}，你是在文林路15號、烏龍院這一條巷子跟我通話的吧？", "n3")},
            {"n4-1", new GenerateUnit("n4-1", "欸是{0}？你等一下我這邊有插撥。", "n4")},
            {"n5-1", new GenerateUnit("n5-1", "嗨{0}，是我E。哦...", "n5")}, 
        };

        public static readonly Dictionary<String, GenerateUnit> GENERATE_NAME_QUESTION_FIX =
        new Dictionary<string, GenerateUnit>()
        {
            
            {"n3-1", new GenerateUnit("n3-1", "嗨{0}，你是在文林路15號、烏龍院這一條巷子跟我通話的吧？", "n3")},
            {"n4-1", new GenerateUnit("n4-1", "欸是{0}？你等一下我這邊有插撥。", "n4")},
        };



        public static readonly Dictionary<String, GenerateUnit> GENERATE_ZODIAC_QUESTION =
        new Dictionary<string, GenerateUnit>()
        {
            {"n5-2", new GenerateUnit("n5-2", "你是{0}阿？", "n5")}
        };

        public static readonly Dictionary<String, GenerateUnit> GENERATE_NAME_RESPONSE =
        new Dictionary<string, GenerateUnit>()
        {
            {"n2-1-rep", new GenerateUnit("n2-1-rep", "{0}你好", "n2")},
            {"n3-1-rep", new GenerateUnit("n3-1-rep", "{0}，我認得你的聲音", "n3")},
            {"n6-5-rep", new GenerateUnit("n6-5-rep", "{0}密碼正確", "n6")},
        };

        public static readonly Dictionary<String, GenerateUnit> GENERATE_MAIL_RESPONSE =
        new Dictionary<string, GenerateUnit>()
        {
            {"n1-1-mail", new GenerateUnit("n1-1-mail", "{0}這是你註冊的Email嗎", "n1")},
            {"n2-1-mail", new GenerateUnit("n2-1-mail", "{0}這是你註冊的Email嗎", "n2")},
            {"n3-1-mail", new GenerateUnit("n3-1-mail", "{0}這是你註冊的Email嗎", "n3")},
        };

    }
}
