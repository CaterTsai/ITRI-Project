namespace ITRI_Project.Data
{
    #region Basic
    public class RepBase
    {
        public RepBase()
        {
            Result = false;
            Msg = "";
        }
        public bool Result { get; set; }
        public string Msg { get; set; }
    }

    public class RepObject<T> : RepBase
        where T : new()
    {
        public T Data { get; set; }
        public RepObject() : base()
        {
            Data = new T();
        }
    }

    public class RepData<T> : RepBase
    {
        public T? Data { get; set; }
        public RepData() : base()
        {

        }
    }

    #endregion

    #region Data
    [Serializable]
    public class UserInfoRep
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Zodiac { get; set; }
        public string Birthday { get; set; }
        public List<int> PassNode { get; set; }

        public byte NowMapType { get; set; }

        public UserInfoRep()
        {
            ID = Name = Mail = Birthday = Zodiac = "";

            PassNode = new List<int>();

            NowMapType = 1;
        }
    }

    [Serializable]
    public class NodeInfo
    {
        public int Id { get; set; }
        public int NodeType { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }
        public string Contact { get; set; }
        public string Notes { get; set; }

        public NodeInfo()
        {
            Address = Title = Message = Contact = Notes = "";
            NodeType = 1;
            Longitude = Latitude = 0.0f;
        }
    }

    [Serializable]
    public class ScriptUnit
    {
        public int OrderId { get; set; }
        public string? Key { get; set; }
        public ConstParameter.ScriptType Type { get; set; }
        public string Question { get; set; }
        public string QuestionAudio { get; set; }
        public string Hints { get; set; }
        public List<string> VariableKey { get; set; }
        public bool HasFixedRep { get; set; }
        public string ScriptParameter { get; set; }

        public List<string> Response { get; set; }
        public List<string> ResponseAudio { get; set; }

        public ScriptUnit()
        {
            HasFixedRep = true;
            ScriptParameter = "";
            Question = QuestionAudio = Hints = "";
            VariableKey = new List<string>();
            Response = new List<string>();
            ResponseAudio = new List<string>();
        }
    }

    [Serializable]
    public class UploadResponse{
        public string Key { get; set; }
        public string Response { get; set; }
        public string ResponseAudio { get; set; }

        public UploadResponse()
        {
            Key = Response = ResponseAudio = "";
        }
    }

    [Serializable]
    public class NodeFinish
    {
        public bool IsFinish {get;set;}
        public int Hour { get; set; }

        public int Minutes { get; set; }

        public byte UserMapType { get; set; }

        public NodeFinish()
        {
            IsFinish = false;
            Hour = 24;
            Minutes = 59;
            UserMapType = 1;
        }
    }

    //Script Parameter  
    [Serializable]
    public class SDisplaySetting
    {
        public bool AutoNext { get; set; }

        public SDisplaySetting()
        {
            AutoNext = true;
        }
    }
    
    [Serializable]
    public class SMultiOption
    {
        public List<string> Options { get; set; }

        public SMultiOption()
        {
            Options = new List<string>();
        }
    }

    [Serializable]
    public class MultiTextUnit
    {
        public string key { get; set; }
        public string placeholder { get; set; }
        public MultiTextUnit()
        {
            key = placeholder = "";
        }

        public MultiTextUnit(string _key, string _placeholder)
        {
            key = _key;
            placeholder = _placeholder;
        }
    }

    [Serializable]
    public class SMultiTextInput{ 
        
        public List<MultiTextUnit> Field { get; set; }
        public SMultiTextInput()
            :base()
        {
            Field = new List<MultiTextUnit>();
        }
    }

    [Serializable]
    public class RatingUnit
    {
        public float Value { get; set; }
        public string Message { get; set; }

        public RatingUnit()
        {
            Message = "";
        }

        public RatingUnit(float val, string text)
        {
            Value = val;
            Message = text;
        }
    }

    [Serializable]
    public class SRatingScale
    {
        public List<RatingUnit> RatingScore { get; set; }
        public List<RatingUnit> Tips { get; set; }

        public SRatingScale(){
            RatingScore = new List<RatingUnit>();
            Tips = new List<RatingUnit>();
        }
    }

    [Serializable]
    public class SInfoCheckParam
    {
        public List<string> Options { get; set; }

        public SInfoCheckParam()
        {
            Options = new List<string>();
        }
    }

    [Serializable]
    public class AudioEffectUnit
    {
        public string AudioKey { get; set; }
        public int Position { get; set; }
        public float Start { get; set; }
        public float End { get; set; }
        public int lowPassFilter { get; set; }
        public int hightPassFilter { get; set; }
        public int hightPassPeak { get; set; }

        public float stereopanner { get; set; }
        public float attack { get; set; }
        public float release { get; set; }

    }

    #endregion

}
